# AIFAS_SYSTEM - AI Fear Analytics System

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![.NET](https://img.shields.io/badge/.NET-8-purple.svg)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019%2B-red.svg)

Hệ thống phân tích khảo sát lo ngại về AI (AI Fear Analytics System) - Tích hợp kho dữ liệu, OLAP/Data Mining SSAS và ứng dụng Web dự đoán mức độ lo ngại về AI.

## 📋 Tổng quan

AIFAS_SYSTEM là một hệ thống hoàn chỉnh minh họa pipeline dữ liệu từ:
- **CSDL nguồn** → **Kho dữ liệu (Star Schema)** → **CSDL khai phá** → **SSAS Data Mining** → **Web API** → **Giao diện Web**

Hệ thống sử dụng các thuật toán Data Mining (Decision Tree, Logistic Regression, Clustering) để dự đoán mức độ lo ngại về AI dựa trên dữ liệu khảo sát.

## 🏗️ Kiến trúc hệ thống

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│  CSDL Nguồn     │    │  Kho Dữ Liệu    │    │  CSDL Khai Phá │
│  AIFAS_SOURCE   │───▶│  AIFAS_STAR     │───▶│  AIFAS_DM      │
└─────────────────┘    └─────────────────┘    └────────┬────────┘
                                                        │
                                                        ▼
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│  Giao diện Web  │◀───│   Web API       │◀───│  SSAS Mining    │
│  (HTML/JS)      │    │  (.NET 8)       │    │  Models         │
└─────────────────┘    └─────────────────┘    └─────────────────┘
```

## 🛠️ Công nghệ sử dụng

- **Database**: Microsoft SQL Server (Database Engine)
- **OLAP/Data Mining**: SQL Server Analysis Services (SSAS)
- **ETL**: SQL Server Integration Services (SSIS)
- **Web API**: ASP.NET Core 8 (Minimal API)
- **Frontend**: HTML5, CSS3, JavaScript
- **Data Mining Algorithms**: Decision Tree, Logistic Regression, Clustering
- **Query Languages**: DMX (Data Mining Extensions), MDX (Multidimensional Expressions)

## 📁 Cấu trúc dự án

```
AIFAS_SYSTEM/
├── AIFAS_SOURCE.sql          # Script tạo CSDL nguồn
├── AIFAS_STAR.sql            # Script tạo kho dữ liệu (Star Schema)
├── SQLQuery3.sql             # Script tạo CSDL khai phá
├── AIFAS_DM.mdx              # Truy vấn MDX/DMX mẫu
├── AIFAS_SSAS/               # Dự án SSAS (Analysis Services)
│   ├── AIFAS_SSAS.sln
│   └── README.md
├── ETL_AIFAS/                # Gói SSIS (ETL)
│   ├── ETL_AIFAS.sln
│   └── ETL_AIFAS/
├── AIFAS_WebApi/             # Web API (.NET 8)
│   ├── Program.cs            # Main API logic
│   ├── appsettings.json      # Cấu hình kết nối SSAS
│   ├── SSAS_KET_NOI.txt      # Hướng dẫn kết nối SSAS
│   └── AIFAS_WebApi.csproj
├── scripts/                  # Scripts hỗ trợ
│   └── gen_bao_cao_docx.py   # Tạo báo cáo Word
├── trangchu.html             # Trang chủ
├── ungdung.html              # Trang ứng dụng dự đoán
├── phantich.html             # Trang phân tích
├── baiviet*.html             # Các bài viết
├── lienhe.html               # Trang liên hệ
├── AI_Fear_Survey_REAL.xls   # Dữ liệu khảo sát mẫu
├── Nhom11_225CCSDL07.docx    # Báo cáo đồ án
└── .gitignore                # Git ignore rules
```

## 🚀 Hướng dẫn cài đặt

### 1. Cài đặt SQL Server và SSAS

- Cài đặt SQL Server Database Engine
- Cài đặt SQL Server Analysis Services
- (Tùy chọn) Cài đặt SQL Server Integration Services cho ETL

### 2. Tạo và nạp dữ liệu

```sql
-- Chạy các script theo thứ tự:
-- 1. AIFAS_SOURCE.sql - Tạo CSDL nguồn
-- 2. AIFAS_STAR.sql - Tạo kho dữ liệu
-- 3. SQLQuery3.sql - Tạo CSDL khai phá
```

### 3. Deploy dự án SSAS

- Mở solution `AIFAS_SSAS/AIFAS_SSAS.sln` trong Visual Studio/SSDT
- Deploy dự án lên instance SSAS
- Xác nhận tên catalog (ví dụ: `AIFAS_SSAS`)
- Kiểm tra các mining models: `DECISION_TREE`, `LOGISTIC_REGRESSION`, `CLUSTERING`

### 4. Cấu hình Web API

- Mở file `AIFAS_WebApi/appsettings.json`
- Cập nhật `Ssas:ConnectionString` với thông tin SSAS của bạn:

```json
{
  "Ssas": {
    "ConnectionString": "Data Source=YOUR_SERVER\\SSAS_INSTANCE;Initial Catalog=AIFAS_SSAS;Integrated Security=SSPI;Connect Timeout=60;"
  }
}
```

- Hoặc sử dụng biến môi trường: `SSAS_CONNECTION_STRING`

### 5. Chạy Web API

```bash
cd AIFAS_WebApi
dotnet run
```

- Mở trình duyệt tại URL hiển thị (thường `http://localhost:5xxx`)

## 📡 API Endpoints

### GET /api/health
Kiểm tra API hoạt động

**Response:**
```json
{
  "ok": true
}
```

### POST /api/predict
Dự đoán mức độ lo ngại về AI

**Request Body:**
```json
{
  "age": 25,
  "gender": "Male",
  "education": "Bachelor",
  "occupation": "Engineer",
  "aiFamiliarity": "Very Familiar",
  "aiUsageFrequency": "Daily",
  "country": "Vietnam",
  "incomeLevel": "Medium",
  "jobLossFear": 7.5,
  "privacyFear": 8.0,
  "safetyFear": 6.5,
  "socialImpactFear": 7.0,
  "overallFearScore": 7.25
}
```

**Response:**
```json
{
  "decisionTree": {
    "predictedLabel": "High",
    "high": 0.65,
    "medium": 0.25,
    "low": 0.10
  },
  "logisticRegression": {
    "predictedLabel": "High",
    "high": 0.70,
    "medium": 0.20,
    "low": 0.10
  },
  "clustering": {
    "clusterLabel": "Cluster 1",
    "probability": 0.85
  }
}
```

## 🎯 Các mô hình Data Mining

### 1. Decision Tree (DECISION_TREE)
- Dự đoán Fear Level với xác suất High/Medium/Low
- Không sử dụng cột Overall Fear Score

### 2. Logistic Regression (LOGISTIC_REGRESSION)
- Dự đoán Fear Level với xác suất High/Medium/Low
- Sử dụng đầy đủ các feature bao gồm Overall Fear Score

### 3. Clustering (CLUSTERING)
- Phân nhóm người dùng dựa trên các đặc điểm
- Trả về Cluster ID và Probability

## 🌐 Giao diện Web

Hệ thống cung cấp các trang:

- **trangchu.html** - Trang chủ giới thiệu hệ thống
- **ungdung.html** - Ứng dụng dự đoán với form nhập liệu
- **phantich.html** - Trang phân tích kết quả
- **baiviet-*.html** - Các bài viết về AI và lo ngại
- **lienhe.html** - Trang liên hệ

## 🔧 Xử lý lỗi kết nối SSAS

Nếu gặp lỗi 502 khi gọi API, kiểm tra:

1. Dịch vụ SQL Server Analysis Services đang chạy
2. Chuỗi kết nối đúng Data Source và Initial Catalog
3. Instance SSAS đúng (ví dụ: `SERVER\\SSASMD`)
4. Kiểm tra bằng SQL Server Management Studio (SSMS)

Xem file `AIFAS_WebApi/SSAS_KET_NOI.txt` để biết chi tiết.

## 📊 Schema Database

### CSDL Nguồn (AIFAS_SOURCE)
- Bảng `AI_FEAR_SURVEY`: Chứa dữ liệu khảo sát gốc

### Kho Dữ Liệu (AIFAS_STAR)
- `DimPerson`: Chiều thông tin cá nhân
- `DimContext`: Chiều bối cảnh sử dụng AI
- `DimTime`: Chiều thời gian
- `FactAIFear`: Bảng sự kiện chứa các chỉ số sợ hãi

### CSDL Khai Phá (AIFAS_DM)
- Bảng `DATASET`: Dữ liệu huấn luyện cho SSAS

## 🤝 Đóng góp

Contributions are welcome! Vui lòng:
1. Fork repository
2. Tạo branch mới (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Mở Pull Request

## 📄 License

Dự án được phân phối dưới license MIT. Xem file [LICENSE](LICENSE) để biết chi tiết.

## 👨‍💻 Tác giả

Nhóm 11 - Môn Chuyên Đề Cơ Sở Dữ Liệu

## 📚 Tài liệu tham khảo

- [Microsoft Learn - SQL Server Documentation](https://learn.microsoft.com/en-us/sql/)
- [Microsoft Learn - Analysis Services](https://learn.microsoft.com/en-us/analysis-services/)
- [DMX Syntax Reference](https://learn.microsoft.com/en-us/analysis-services/data-mining/dmx/data-mining-extensions-dmx-reference)

## 🌟 Tính năng nổi bật

- ✅ Pipeline dữ liệu hoàn chỉnh từ nguồn đến khai phá
- ✅ Tích hợp 3 thuật toán Data Mining khác nhau
- ✅ Web API hiện đại với .NET 8
- ✅ Giao diện Web responsive
- ✅ Hỗ trợ truy vấn OLAP đa chiều
- ✅ ETL tự động với SSIS
- ✅ Tài liệu chi tiết và script sẵn sàng

## 📞 Liên hệ

Nếu có câu hỏi hoặc vấn đề, vui lòng mở Issue trên GitHub.
