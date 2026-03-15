# Feedback API

基于 ASP.NET Core 9.0 Web API 搭建的后端服务，参考 NewTOEFL backend 的文件夹结构。

## 项目结构

```
Feedback/
└── backend/
    ├── controller/     # API 控制器
    ├── dto/            # 数据传输对象与 AutoMapper 配置
    ├── model/          # 领域模型
    ├── repo/           # 数据访问层 (DbContext)
    ├── service/        # 业务逻辑服务
    ├── viewmodel/      # 视图模型
    ├── Migrations/     # EF Core 迁移
    ├── Program.cs
    ├── backend.csproj
    └── appsettings.Development.json
```

## 运行要求

- .NET 9.0 SDK
- MySQL 8.x

## 快速开始

1. 配置数据库连接字符串（`appsettings.Development.json`）：

```json
{
  "ConnectionStrings": {
    "Default": "server=localhost;database=Feedback;user=root;password=你的密码;CharSet=utf8mb4;Connect Timeout=10000;TreatTinyAsBoolean=true"
  }
}
```

2. 创建数据库并运行迁移：

```bash
cd backend
dotnet ef database update
```

3. 启动 API：

```bash
dotnet run --project backend.csproj
```

API 默认监听 `http://localhost:5001`，Swagger UI 位于根路径 `/`。

## API 端点

- `GET /health` - 健康检查
- `GET /api/voc` - 词汇检查 (VOC)
- `GET /api/listening` - 听力检查 (Listening)
- `GET /api/listening-sentence-detail` - 听力句子明细 (ListeningSentenceDetail)
