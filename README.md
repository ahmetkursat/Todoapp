# TodoApi - Clean Architecture .NET Web API

.NET 8 Web API projesi - Clean Architecture prensipleriyle geliştirilmiş Todo uygulaması.

## 🏗️ Mimari

- **Core Layer**: Domain entities ve interfaces
- **Application Layer**: Business logic, DTOs, services
- **Infrastructure Layer**: Data access, EF Core, repositories
- **API Layer**: Controllers, middleware, DI configuration

## 🚀 Teknolojiler

- .NET 8
- Entity Framework Core
- SQLite
- AutoMapper
- Swagger/OpenAPI

## 📋 Özellikler

- ✅ Todo CRUD işlemleri
- ✅ Tamamlanmış/Bekleyen todo filtreleme
- ✅ Data validation
- ✅ Global exception handling
- ✅ Clean Architecture
- ✅ Repository Pattern
- ✅ Dependency Injection

## 🛠️ Kurulum

1. Repository'yi klonla:
```bash
git clone https://github.com/KULLANICI_ADIN/TodoApi.git
cd TodoApi
```

2. Database migration'ı çalıştır:
```bash
cd TodoApi.API
dotnet ef database update --project ../TodoApi.Infrastructure
```

3. Projeyi çalıştır:
```bash
dotnet run
```

4. Swagger UI'a git:
```
https://localhost:5001/swagger
```

## 📡 API Endpoints

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | /api/todos | Tüm todoları listele |
| GET | /api/todos/{id} | Todo detayı |
| GET | /api/todos/completed | Tamamlanmış todoları listele |
| GET | /api/todos/pending | Bekleyen todoları listele |
| POST | /api/todos | Yeni todo oluştur |
| PUT | /api/todos/{id} | Todo güncelle |
| DELETE | /api/todos/{id} | Todo sil |

## 📦 Proje Yapısı
```
TodoApi/
├── TodoApi.Core/              # Domain layer
│   ├── Entities/
│   └── Interfaces/
├── TodoApi.Application/       # Business logic
│   ├── DTOs/
│   ├── Interfaces/
│   ├── Services/
│   └── Mappings/
├── TodoApi.Infrastructure/    # Data access
│   ├── Data/
│   └── Repositories/
└── TodoApi.API/              # Presentation layer
    ├── Controllers/
    └── Middleware/
```

## 🧪 Test
```bash
# Unit testler (ileride eklenecek)
dotnet test
```

## 📝 Geliştirme

1. Develop branch'inden yeni feature branch oluştur:
```bash
git checkout develop
git checkout -b feature/yeni-ozellik
```

2. Değişikliklerini commit et:
```bash
git add .
git commit -m "feat: yeni özellik açıklaması"
```

3. Push ve PR oluştur:
```bash
git push origin feature/yeni-ozellik
```

## 📄 Lisans

MIT

## 👤 Geliştirici

https://github.com/ahmetkursat
