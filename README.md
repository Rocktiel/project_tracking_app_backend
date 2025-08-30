# Mini Proje Takip Uygulaması Backend

### Proje Tanımı

Kullanıcıların basit projeler ve bu projelere ait görevler oluşturabileceği bir web uygulamasının backend kısmı.

Bu proje C# .NET 9 ile yazılmıştır.

---

## Gereksinimler

- **.NET SDK**: 9.0 veya üzeri

---

## Dosya Yapısı

```bash
├── MiniProject.sln
│
├── MiniProject.Api (Sunum Katmanı - Controller'lar)
│   ├── Controllers
│   │   └── ProjectController.cs
│   │   └── TaskController.cs
│   ├── Program.cs
│   └── appsettings.json
│
├── MiniProject.Application (İş Mantığı Katmanı - Service'ler)
│   ├── Services
│   │   ├── IProjectService.cs
│   │   ├── ProjectService.cs
│   │   ├── ITaskService.cs
│   │   └── TaskService.cs
│   ├── DTOs
│   │   ├── CreateProjectDto.cs
│   │   ├── CreateTaskDto.cs
│   │   ├── ProjectDto.cs
│   │   └── TaskDto.cs
│
└── MiniProject.Persistence (Veri Erişim Katmanı - Repository'ler)
    ├── Contexts
    │   └── DatabaseContext.cs
    ├── Repositories
    │   ├── IProjectRepository.cs
    │   └── ProjectRepository.cs
    │   ├── ITaskRepository.cs
    │   └── TaskRepository.cs
    ├── Migrations
    └── Entities
        └── Project.cs
        └── Task.cs
```

## API Endpointleri

### **Project**

- `GET      /api/project` – Tüm projeleri getirir
- `GET      /api/project/{id}` – ID'ye göre proje getirir
- `POST     /api/project` – Yeni proje oluşturur
- `PUT      /api/project/{id}` – Projeyi günceller
- `DELETE   /api/project/{id}` – Projeyi siler

### **Task**

- `GET      /api/task` – Tüm görevleri getirir
- `GET      /api/task/{id}` – ID'ye göre görev getirir
- `POST     /api/task` – Yeni görev oluşturur
- `DELETE   /api/task/{id}` – Görevi siler
- `PATCH    /api/task/{id}` – Görev durumunu günceller
- `GET      /api/task/project/{projectId}` – Belirli projeye ait görevleri getirir

---

## Backend Kurulumu (.NET 9)

1. Repo klonlayın veya zip olarak indirin:

```bash
git clone https://https://github.com/Rocktiel/project_tracking_app_backend.git
cd MiniProject.Api
```

2. Gerekli NuGet paketlerini yükleyin::

```bash
dotnet restore
```

3. Uygulamayı çalıştır:

```bash
dotnet run
```

### Uygulama https://localhost:5053 üzerinde çalışıcaktır.

### Swagger Dokümantasyonu için:

```bash
http://localhost:5053/swagger
```
