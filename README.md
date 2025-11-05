# E-edu

E-edu — це сучасна електронна система, розроблена для комплексної підтримки навчального процесу у вищих навчальних закладах, таких як університети та коледжі. Система автоматизує ключові адміністративні та освітні процеси, забезпечуючи зручний доступ до інформації для студентів, викладачів, деканату та адміністрації.

E-edu дозволяє ефективно організовувати навчальний процес, підвищує прозорість та контроль за академічною успішністю, а також спрощує взаємодію між усіма учасниками освітнього процесу.

---

## Architecture: Feature-Based Modular Monolith

The application follows a **Feature-Based Modular Monolith** architecture, where each feature is organized into separate projects/modules. This approach provides separation of concerns, maintainability, scalability, and future migration path to microservices.

---

## Project Structure

```
Eedu/
├── Eedu.Core/                          # Shared abstractions & interfaces
├── Eedu.Data/                          # Shared data layer (entities, DbContext)
├── Eedu.Infrastructure.Shared/         # Shared infrastructure (repositories, common services)
│
├── Eedu.Features.Structure/             # University structure feature
│   ├── Eedu.Features.Structure.Application/
│   ├── Eedu.Features.Structure.Infrastructure/
│   └── Eedu.Features.Structure.Api/
│
├── Eedu.Features.LearningProcess/      # Learning process feature
│   ├── Eedu.Features.LearningProcess.Application/
│   ├── Eedu.Features.LearningProcess.Infrastructure/
│   └── Eedu.Features.LearningProcess.Api/
│
├── Eedu.Features.Schedules/            # Schedules feature
│   ├── Eedu.Features.Schedules.Application/
│   ├── Eedu.Features.Schedules.Infrastructure/
│   └── Eedu.Features.Schedules.Api/
│
├── Eedu.Features.Groups/               # Groups feature
│   ├── Eedu.Features.Groups.Application/
│   ├── Eedu.Features.Groups.Infrastructure/
│   └── Eedu.Features.Groups.Api/
│
├── Eedu.Features.Dormitories/          # Dormitories feature
│   ├── Eedu.Features.Dormitories.Application/
│   ├── Eedu.Features.Dormitories.Infrastructure/
│   └── Eedu.Features.Dormitories.Api/
│
├── Eedu.Features.Notifications/        # Notifications feature (shared across all)
│   ├── Eedu.Features.Notifications.Application/
│   ├── Eedu.Features.Notifications.Infrastructure/
│   └── Eedu.Features.Notifications.Api/
│
├── Eedu.Features.Identity/             # Identity & Authentication feature
│   ├── Eedu.Features.Identity.Application/
│   ├── Eedu.Features.Identity.Infrastructure/
│   └── Eedu.Features.Identity.Api/
│
└── Eedu.Api/                            # Main API Gateway/Host
```

---

## Feature Modules

### 1. Eedu.Features.Structure
**Purpose**: Manages university organizational structure

**Entities**: University, Faculty, Specialty

**API Endpoints**:
- `/api/structure/universities`
- `/api/structure/faculties`
- `/api/structure/specialties`

**Dependencies**: Eedu.Core, Eedu.Data, Eedu.Features.Notifications

---

### 2. Eedu.Features.LearningProcess
**Purpose**: Manages academic learning process

**Entities**: Subject, Lesson, Mark, Report

**API Endpoints**:
- `/api/learning/subjects`
- `/api/learning/lessons`
- `/api/learning/marks`
- `/api/learning/reports`

**Dependencies**: Eedu.Core, Eedu.Data, Eedu.Features.Structure, Eedu.Features.Notifications

---

### 3. Eedu.Features.Schedules
**Purpose**: Manages class schedules and timetables

**Entities**: Schedule, SchedulePeriod

**API Endpoints**:
- `/api/schedules`
- `/api/schedules/periods`
- `/api/schedules/conflicts`

**Dependencies**: Eedu.Core, Eedu.Data, Eedu.Features.Structure, Eedu.Features.LearningProcess, Eedu.Features.Notifications

---

### 4. Eedu.Features.Groups
**Purpose**: Manages student groups and group interactions

**Entities**: Group, UserGroup, GroupInvite, Post, PostComment, PostReaction, GroupPost, UserGroupRole

**API Endpoints**:
- `/api/groups`
- `/api/groups/{id}/posts`
- `/api/groups/{id}/invites`
- `/api/groups/{id}/members`

**Dependencies**: Eedu.Core, Eedu.Data, Eedu.Features.Structure, Eedu.Features.Notifications

---

### 5. Eedu.Features.Dormitories
**Purpose**: Manages dormitory and housing operations

**Entities**: Dormitory, Floor, Room, RoomAssignment, RoomAmenity, RoomInspection, MaintenanceRequest, RoomFee, FurnitureItem

**API Endpoints**:
- `/api/dormitories`
- `/api/dormitories/{id}/rooms`
- `/api/dormitories/rooms/{id}/assignments`
- `/api/dormitories/maintenance`
- `/api/dormitories/payments`

**Dependencies**: Eedu.Core, Eedu.Data, Eedu.Features.Structure, Eedu.Features.Notifications

---

### 6. Eedu.Features.Notifications ⭐ (Shared Module)
**Purpose**: Unified notification system accessible across all features

**Entities**: Notification, NotificationDelivery, NotificationTemplate, UserNotificationSettings

**API Endpoints**:
- `/api/notifications`
- `/api/notifications/templates`
- `/api/notifications/settings`
- `/api/notifications/{id}/mark-read`

**Integration**: All features can inject `INotificationService` to send notifications

**Key Features**:
- Multi-channel delivery (In-App, Email, Push, SMS)
- Notification templates
- User preferences
- Unified access across all features

---

### 7. Eedu.Features.Identity
**Purpose**: Authentication and authorization

**Entities**: User, Role, Permission, Session, RefreshToken, MFA, Device, Contact, Password, Ban, etc.

**API Endpoints**:
- `/api/identity/auth/login`
- `/api/identity/auth/register`
- `/api/identity/users`
- `/api/identity/roles`
- `/api/identity/permissions`

**Dependencies**: Eedu.Core, Eedu.Data, Eedu.Features.Notifications

---

## Layer Structure per Feature

Each feature module follows the same layered architecture:

```
Feature.Module/
├── Application/              # Business logic layer
│   ├── Services/            # Application services
│   ├── DTOs/                # Data Transfer Objects
│   ├── Mappings/            # AutoMapper profiles
│   ├── Validators/          # FluentValidation validators
│   └── Interfaces/          # Feature-specific service interfaces
│
├── Infrastructure/          # Data access layer
│   ├── Repositories/       # Repository implementations
│   └── Configurations/     # EF Core configurations
│
└── Api/                     # Presentation layer
    ├── Controllers/         # API controllers
    ├── Middleware/          # Feature-specific middleware
    └── Filters/             # Feature-specific filters
```

---

## Notification Integration Pattern

### Service Interface
```csharp
public interface INotificationService
{
    Task<Result<NotificationDto>> SendNotificationAsync(
        Guid recipientId,
        NotificationType type,
        string title,
        string message,
        NotificationPriority priority = NotificationPriority.Normal,
        Guid? relatedEntityId = null,
        string? relatedEntityType = null,
        Guid? tenantId = null);
}
```

### Usage in Features
All features can inject `INotificationService` to send notifications:

```csharp
// Example: In LearningProcess feature
public class SubjectService
{
    private readonly INotificationService _notificationService;
    
    public async Task CreateSubjectAsync(CreateSubjectDto dto)
    {
        // Create subject...
        await _notificationService.SendNotificationAsync(
            recipientId: dto.TeacherId,
            type: NotificationType.SubjectCreated,
            title: "New Subject Created",
            message: $"Subject {subject.Title} has been created",
            tenantId: subject.TenantId);
    }
}
```

---

## Dependency Graph

```
Eedu.Api
  ├── Eedu.Features.Structure
  │   └── Eedu.Features.Notifications ⭐
  ├── Eedu.Features.LearningProcess
  │   ├── Eedu.Features.Structure
  │   └── Eedu.Features.Notifications ⭐
  ├── Eedu.Features.Schedules
  │   ├── Eedu.Features.Structure
  │   ├── Eedu.Features.LearningProcess
  │   └── Eedu.Features.Notifications ⭐
  ├── Eedu.Features.Groups
  │   ├── Eedu.Features.Structure
  │   └── Eedu.Features.Notifications ⭐
  ├── Eedu.Features.Dormitories
  │   ├── Eedu.Features.Structure
  │   └── Eedu.Features.Notifications ⭐
  ├── Eedu.Features.Notifications ⭐
  └── Eedu.Features.Identity
      └── Eedu.Features.Notifications ⭐

All Features
  ├── Eedu.Core
  ├── Eedu.Data
  └── Eedu.Infrastructure.Shared
```

---

## Benefits

- ✅ **Separation of Concerns** - Each feature is self-contained
- ✅ **Independent Development** - Teams can work on different features
- ✅ **Scalability** - Can scale features independently
- ✅ **Maintainability** - Easier to understand and maintain
- ✅ **Testability** - Features can be tested in isolation
- ✅ **Unified Notifications** - Shared notification system across all features
- ✅ **Future-Ready** - Easy migration path to microservices

---

## Database Strategy

**Approach**: Single `EduDbContext` shared by all features
- Transactional consistency across features
- Easy to query across features
- Simpler deployment

**Future**: Can split into separate databases per feature if needed

---

## API Routing Strategy

Feature-based routing:
```
/api/structure/universities
/api/learning/subjects
/api/schedules
/api/groups
/api/dormitories
/api/notifications
/api/identity/users
```

---

## Основні користувачі системи

- Студенти
- Викладачі
- Деканат
- Адміністрація навчального закладу

---

## Переваги використання E-edu

- Централізований доступ до навчальної інформації
- Зменшення паперового документообігу
- Оперативне оновлення даних
- Підвищення прозорості та відповідальності
- Можливість аналітики та звітності

---

## Основний функціонал системи

- Розклад занять: формування, перегляд та оновлення розкладу для студентів і викладачів
- Електронний журнал: ведення обліку відвідуваності, оцінок, домашніх завдань
- Облік відсутності студентів: фіксація та аналіз пропусків занять
- Структура університету: відображення факультетів, кафедр, груп, викладачів
- Списки студентів: перегляд, редагування та експорт списків студентів по групах
- Особові справи студентів: зберігання особистої інформації, академічної історії, заяв, наказів
- Відомості: формування та зберігання залікових, екзаменаційних та інших відомостей
- Функціонал для деканату: адміністрування навчального процесу, створення звітів, управління академічними відпустками, переведеннями, відрахуваннями
- Гуртожитки: управління кімнатами, призначення студентів, обслуговування
- Сповіщення: уніфікована система сповіщень для всіх функцій

---

E-edu сприяє цифровій трансформації навчального закладу, робить освітній процес більш ефективним, прозорим та зручним для всіх учасників.