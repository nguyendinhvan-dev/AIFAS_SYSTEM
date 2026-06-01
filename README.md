<div align="right">

<table>
<tr>

</td>
<td width="40%" align="center">
  
    
**XEM THÊM CÁC DỰ ÁN KHÁC**
  
 >
  
[![GitHub Profile](https://img.shields.io/badge/GitHub-Profile-blue?style=for-the-badge&logo=github)](https://github.com/nguyendinhvan-dev)

</td>
</tr>
</table>

</div>


<div align="center">

# 🧠 AIFAS_SYSTEM

### AI Fear Analytics System - Hệ thống Phân tích Lo ngại về AI

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8-purple.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019%2B-red.svg)](https://www.microsoft.com/en-us/sql-server)
[![GitHub Stars](https://img.shields.io/github/stars/nguyendinhvan-dev/AIFAS_SYSTEM?style=social)](https://github.com/nguyendinhvan-dev/AIFAS_SYSTEM/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/nguyendinhvan-dev/AIFAS_SYSTEM?style=social)](https://github.com/nguyendinhvan-dev/AIFAS_SYSTEM/network/members)

**🚀 Live Demo:** [nguyendinhvan-dev.github.io/AIFAS_SYSTEM](https://nguyendinhvan-dev.github.io/AIFAS_SYSTEM)

Hệ thống hoàn chỉnh tích hợp **Kho Dữ liệu**, **OLAP/Data Mining SSAS** và **Web API** để phân tích và dự đoán mức độ lo ngại về AI dựa trên dữ liệu khảo sát.

</div>

---

## ✨ Tính năng nổi bật

| 🎯 Tính năng | 📝 Mô tả |
|------------|----------|
| 🔍 **Pipeline Dữ Liệu** | Từ CSDL nguồn → Kho dữ liệu → CSDL khai phá → SSAS → Web API |
| 🤖 **3 Thuật toán AI** | Decision Tree, Logistic Regression, Clustering |
| 📊 **OLAP đa chiều** | Truy vấn nhanh với SQL Server Analysis Services |
| 🌐 **Web API hiện đại** | ASP.NET Core 8 Minimal API |
| 🎨 **Giao diện đẹp** | Responsive UI với dark theme |
| 📈 **ETL tự động** | SQL Server Integration Services (SSIS) |

---

## 🎬 Demo

Truy cập **[nguyendinhvan-dev.github.io/AIFAS_SYSTEM](https://nguyendinhvan-dev.github.io/AIFAS_SYSTEM)** để xem demo trực tiếp!

**🔗 Quick Links:**
- [Trang Chủ](https://nguyendinhvan-dev.github.io/AIFAS_SYSTEM/index.html)
- [Ứng Dụng Dự Báo](https://nguyendinhvan-dev.github.io/AIFAS_SYSTEM/ungdung.html)
- [Phân Tích Dữ Liệu](https://nguyendinhvan-dev.github.io/AIFAS_SYSTEM/phantich.html)

---

## 🚀 Quick Start

### 1️⃣ Clone Repository
```bash
git clone https://github.com/nguyendinhvan-dev/AIFAS_SYSTEM.git
cd AIFAS_SYSTEM
```

### 2️⃣ Cài đặt SQL Server & SSAS
- Cài đặt **SQL Server Database Engine**
- Cài đặt **SQL Server Analysis Services**
- (Tùy chọn) Cài đặt **SQL Server Integration Services**

### 3️⃣ Chạy Database Scripts
```sql
-- 1. Tạo CSDL nguồn
-- Chạy file: AIFAS_SOURCE.sql

-- 2. Tạo kho dữ liệu (Star Schema)
-- Chạy file: AIFAS_STAR.sql

-- 3. Tạo CSDL khai phá
-- Chạy file: SQLQuery3.sql
```

### 4️⃣ Deploy SSAS Project
- Mở `AIFAS_SSAS/AIFAS_SSAS.sln` trong Visual Studio/SSDT
- Deploy lên instance SSAS của bạn

### 5️⃣ Chạy Web API
```bash
cd AIFAS_WebApi
dotnet run
```

🎉 Xong! Truy cập `http://localhost:5xxx` để sử dụng.

---

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

| Category | Technology |
|----------|-----------|
| 💾 **Database** | Microsoft SQL Server (Database Engine) |
| 🧠 **OLAP/Data Mining** | SQL Server Analysis Services (SSAS) |
| 🔄 **ETL** | SQL Server Integration Services (SSIS) |
| 🌐 **Web API** | ASP.NET Core 8 (Minimal API) |
| 🎨 **Frontend** | HTML5, CSS3, JavaScript |
| 🤖 **Data Mining** | Decision Tree, Logistic Regression, Clustering |
| 📝 **Query Languages** | DMX (Data Mining Extensions), MDX (Multidimensional Expressions) |

---

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

## 🚀 Hướng dẫn cài đặt chi tiết

### 1️⃣ Cài đặt SQL Server và SSAS

- Cài đặt **SQL Server Database Engine**
- Cài đặt **SQL Server Analysis Services**
- (Tùy chọn) Cài đặt **SQL Server Integration Services** cho ETL

### 2️⃣ Tạo và nạp dữ liệu

```sql
-- Chạy các script theo thứ tự:
-- 1. AIFAS_SOURCE.sql - Tạo CSDL nguồn
-- 2. AIFAS_STAR.sql - Tạo kho dữ liệu
-- 3. SQLQuery3.sql - Tạo CSDL khai phá
```

### 3️⃣ Deploy dự án SSAS

- Mở solution `AIFAS_SSAS/AIFAS_SSAS.sln` trong Visual Studio/SSDT
- Deploy dự án lên instance SSAS
- Xác nhận tên catalog (ví dụ: `AIFAS_SSAS`)
- Kiểm tra các mining models: `DECISION_TREE`, `LOGISTIC_REGRESSION`, `CLUSTERING`

### 4️⃣ Cấu hình Web API

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

### 5️⃣ Chạy Web API

```bash
cd AIFAS_WebApi
dotnet run
```

🎉 Mở trình duyệt tại URL hiển thị (thường `http://localhost:5xxx`)

## 📡 API Endpoints

### 🔍 GET `/api/health`
Kiểm tra API hoạt động

**Response:**
```json
{
  "ok": true
}
```

### 🤖 POST `/api/predict`
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

### 🌳 1. Decision Tree (DECISION_TREE)
- Dự đoán Fear Level với xác suất High/Medium/Low
- Không sử dụng cột Overall Fear Score
- Phù hợp cho phân loại nhanh

### 📈 2. Logistic Regression (LOGISTIC_REGRESSION)
- Dự đoán Fear Level với xác suất High/Medium/Low
- Sử dụng đầy đủ các feature bao gồm Overall Fear Score
- Chính xác cao cho dữ liệu tuyến tính

### 🔮 3. Clustering (CLUSTERING)
- Phân nhóm người dùng dựa trên các đặc điểm
- Trả về Cluster ID và Probability
- Phát hiện pattern trong dữ liệu

## 🌐 Giao diện Web

Hệ thống cung cấp các trang:

| Trang | Mô tả | Link |
|-------|-------|------|
| 🏠 **trangchu.html** | Trang chủ giới thiệu hệ thống | [Xem](https://nguyendinhvan-dev.github.io/AIFAS_SYSTEM/index.html) |
| 🤖 **ungdung.html** | Ứng dụng dự đoán với form nhập liệu | [Xem](https://nguyendinhvan-dev.github.io/AIFAS_SYSTEM/ungdung.html) |
| 📊 **phantich.html** | Trang phân tích kết quả | [Xem](https://nguyendinhvan-dev.github.io/AIFAS_SYSTEM/phantich.html) |
| 📝 **baiviet-*.html** | Các bài viết về AI và lo ngại | [Xem](https://nguyendinhvan-dev.github.io/AIFAS_SYSTEM/baiviet.html) |
| 📧 **lienhe.html** | Trang liên hệ | [Xem](https://nguyendinhvan-dev.github.io/AIFAS_SYSTEM/lienhe.html) |

## 🔧 Xử lý lỗi kết nối SSAS

Nếu gặp lỗi 502 khi gọi API, kiểm tra:

| Kiểm tra | Chi tiết |
|----------|----------|
| ✅ **Dịch vụ SSAS** | SQL Server Analysis Services đang chạy |
| ✅ **Chuỗi kết nối** | Đúng Data Source và Initial Catalog |
| ✅ **Instance SSAS** | Đúng (ví dụ: `SERVER\\SSASMD`) |
| ✅ **Kiểm tra bằng SSMS** | Sử dụng SQL Server Management Studio |

📄 Xem file `AIFAS_WebApi/SSAS_KET_NOI.txt` để biết chi tiết.

## 📊 Schema Database

### 💾 CSDL Nguồn (AIFAS_SOURCE)
- Bảng `AI_FEAR_SURVEY`: Chứa dữ liệu khảo sát gốc

### 🏪 Kho Dữ Liệu (AIFAS_STAR)
- `DimPerson`: Chiều thông tin cá nhân
- `DimContext`: Chiều bối cảnh sử dụng AI
- `DimTime`: Chiều thời gian
- `FactAIFear`: Bảng sự kiện chứa các chỉ số sợ hãi

### 🔬 CSDL Khai Phá (AIFAS_DM)
- Bảng `DATASET`: Dữ liệu huấn luyện cho SSAS

## 🤝 Đóng góp

Contributions are welcome! Vui lòng:

1. 🍴 Fork repository
2. 🌿 Tạo branch mới (`git checkout -b feature/AmazingFeature`)
3. 💾 Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. 📤 Push to branch (`git push origin feature/AmazingFeature`)
5. 🔀 Mở Pull Request

## 📄 License

Dự án được phân phối dưới license MIT. Xem file [LICENSE](LICENSE) để biết chi tiết.

## 👨‍💻 Tác giả

**Nguyễn Đình Văn** - Môn Chuyên Đề Cơ Sở Dữ Liệu

## 📚 Tài liệu tham khảo

- [Microsoft Learn - SQL Server Documentation](https://learn.microsoft.com/en-us/sql/)
- [Microsoft Learn - Analysis Services](https://learn.microsoft.com/en-us/analysis-services/)
- [DMX Syntax Reference](https://learn.microsoft.com/en-us/analysis-services/data-mining/dmx/data-mining-extensions-dmx-reference)

## 📞 Liên hệ

Nếu có câu hỏi hoặc vấn đề, vui lòng mở Issue trên GitHub.

---

<div align="center">

**⭐ Nếu bạn thích dự án này, hãy cho tôi một Star! ⭐**

[![GitHub Stars](https://img.shields.io/github/stars/nguyendinhvan-dev/AIFAS_SYSTEM?style=social)](https://github.com/nguyendinhvan-dev/AIFAS_SYSTEM/stargazers)




Made with ❤️ by Nguyễn Đình Văn

</div>
