using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AnalysisServices.AdomdClient;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(o =>
{
    o.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    o.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

var connStr = Environment.GetEnvironmentVariable("SSAS_CONNECTION_STRING")
    ?? app.Configuration["Ssas:ConnectionString"]
    ?? throw new InvalidOperationException(
        "Thiếu kết nối SSAS: đặt Ssas:ConnectionString trong appsettings.json hoặc biến môi trường SSAS_CONNECTION_STRING. Xem AIFAS_WebApi/SSAS_KET_NOI.txt.");

var repoRoot = Path.GetFullPath(Path.Combine(app.Environment.ContentRootPath, ".."));
var staticFiles = new PhysicalFileProvider(repoRoot);

app.UseDefaultFiles(new DefaultFilesOptions
{
    FileProvider = staticFiles,
    DefaultFileNames = ["trangchu.html"],
});
app.UseStaticFiles(new StaticFileOptions { FileProvider = staticFiles });

app.MapPost("/api/predict", (PredictionRequest body) =>
{
    try
    {
        using var conn = new AdomdConnection(connStr);
        conn.Open();

        var dt = RunDmx(conn, DmxBuilder.DecisionTree(body));
        var lr = RunDmx(conn, DmxBuilder.LogisticRegression(body));
        var cl = RunDmx(conn, DmxBuilder.Clustering(body));

        return Results.Ok(new PredictResponse(
            MapTree(dt),
            MapTree(lr),
            MapCluster(cl)));
    }
    catch (Exception ex)
    {
        return Results.Json(
            new { error = ex.Message, detail = ex.InnerException?.Message },
            statusCode: StatusCodes.Status502BadGateway);
    }
});

app.MapGet("/api/health", () => Results.Ok(new { ok = true }));

app.Run();

static IReadOnlyDictionary<string, object?> RunDmx(AdomdConnection conn, string dmx)
{
    using var cmd = new AdomdCommand(dmx, conn);
    using var reader = cmd.ExecuteReader();
    if (!reader.Read())
        throw new InvalidOperationException("DMX không trả về dòng kết quả.");
    var row = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
    for (var i = 0; i < reader.FieldCount; i++)
    {
        var name = reader.GetName(i);
        row[name] = reader.IsDBNull(i) ? null : reader.GetValue(i);
    }
    return row;
}

static TreeResult MapTree(IReadOnlyDictionary<string, object?> row)
{
    static double D(object? v) => v is null or DBNull ? 0 : Convert.ToDouble(v, CultureInfo.InvariantCulture);
    static string? S(object? v) => v is null or DBNull ? null : Convert.ToString(v, CultureInfo.InvariantCulture);

    return new TreeResult(
        PredictedLabel: S(row.GetValueOrDefault("PredictedLabel")),
        High: D(row.GetValueOrDefault("High")),
        Medium: D(row.GetValueOrDefault("Medium")),
        Low: D(row.GetValueOrDefault("Low")));
}

static ClusterResult MapCluster(IReadOnlyDictionary<string, object?> row)
{
    static double D(object? v) => v is null or DBNull ? 0 : Convert.ToDouble(v, CultureInfo.InvariantCulture);
    static string? S(object? v) => v is null or DBNull ? null : Convert.ToString(v, CultureInfo.InvariantCulture);

    return new ClusterResult(
        ClusterLabel: S(row.GetValueOrDefault("ClusterId")),
        Probability: D(row.GetValueOrDefault("ClusterProb")));
}

internal static class DmxBuilder
{
    public static string DecisionTree(PredictionRequest r)
    {
        var sel = $"""
            SELECT
              Predict([Fear Level]) AS PredictedLabel,
              PredictProbability([Fear Level], 'High') AS High,
              PredictProbability([Fear Level], 'Medium') AS Medium,
              PredictProbability([Fear Level], 'Low') AS Low
            FROM [DECISION_TREE]
            NATURAL PREDICTION JOIN
            ({CommonInput(r, includeOverall: false)}) AS t
            """;
        return sel;
    }

    public static string LogisticRegression(PredictionRequest r)
    {
        return $"""
            SELECT
              Predict([Fear Level]) AS PredictedLabel,
              PredictProbability([Fear Level], 'High') AS High,
              PredictProbability([Fear Level], 'Medium') AS Medium,
              PredictProbability([Fear Level], 'Low') AS Low
            FROM [LOGISTIC_REGRESSION]
            NATURAL PREDICTION JOIN
            ({CommonInput(r, includeOverall: true)}) AS t
            """;
    }

    public static string Clustering(PredictionRequest r)
    {
        return $"""
            SELECT
              Cluster() AS ClusterId,
              ClusterProbability() AS ClusterProb
            FROM [CLUSTERING]
            NATURAL PREDICTION JOIN
            ({CommonInput(r, includeOverall: true)}) AS t
            """;
    }

    /// <summary>
    /// Cột khớp với Mining Structure AIFAS_DATASET (tên có khoảng trắng).
    /// DECISION_TREE trong project của bạn không gồm cột Overall Fear Score — không đưa vào khi includeOverall=false.
    /// </summary>
    static string CommonInput(PredictionRequest r, bool includeOverall)
    {
        var parts = new List<string>
        {
            $"SELECT {Lit(r.Age)} AS [Age], {Lit(r.Gender)} AS [Gender], {Lit(r.Education)} AS [Education], " +
            $"{Lit(r.Occupation)} AS [Occupation], {Lit(r.AiFamiliarity)} AS [AI Familiarity], " +
            $"{Lit(r.AiUsageFrequency)} AS [AI Usage Frequency], {Lit(r.Country)} AS [Country], " +
            $"{Lit(r.IncomeLevel)} AS [Income Level], {Lit(r.JobLossFear)} AS [Job Loss Fear], " +
            $"{Lit(r.PrivacyFear)} AS [Privacy Fear], {Lit(r.SafetyFear)} AS [Safety Fear], " +
            $"{Lit(r.SocialImpactFear)} AS [Social Impact Fear]",
        };
        if (includeOverall)
            parts.Add($", {Lit(r.OverallFearScore)} AS [Overall Fear Score]");
        return string.Concat(parts) + " ";
    }

    static string Lit(string? s)
    {
        if (string.IsNullOrEmpty(s)) return "NULL";
        return $"'{s.Replace("'", "''", StringComparison.Ordinal)}'";
    }

    static string Lit(double d) => d.ToString(CultureInfo.InvariantCulture);
}

public sealed record PredictionRequest(
    double Age,
    string Gender,
    string Education,
    string Occupation,
    string AiFamiliarity,
    string AiUsageFrequency,
    string Country,
    string IncomeLevel,
    double JobLossFear,
    double PrivacyFear,
    double SafetyFear,
    double SocialImpactFear,
    double OverallFearScore);

public sealed record TreeResult(string? PredictedLabel, double High, double Medium, double Low);

public sealed record ClusterResult(string? ClusterLabel, double Probability);

public sealed record PredictResponse(
    TreeResult DecisionTree,
    TreeResult LogisticRegression,
    ClusterResult Clustering);
