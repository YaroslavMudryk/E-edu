namespace Eedu.Data.Enums;

public enum NotificationType
{
    // Academic notifications
    GradePosted = 1,
    AssignmentDue = 2,
    LessonScheduled = 3,
    LessonCancelled = 4,
    ScheduleChanged = 5,
    ReportPublished = 6,
    SubjectCreated = 7,
    
    // Group notifications
    GroupInvite = 10,
    GroupPost = 11,
    GroupComment = 12,
    GroupReaction = 13,
    
    // Dormitory notifications
    RoomAssignment = 20,
    MaintenanceRequest = 21,
    MaintenanceCompleted = 22,
    RoomInspection = 23,
    PaymentDue = 24,
    PaymentReceived = 25,
    
    // System notifications
    PasswordChanged = 30,
    SecurityAlert = 31,
    AccountActivity = 32,
    SystemAnnouncement = 33,
    
    // General
    Announcement = 40,
    DeadlineReminder = 41,
    Custom = 99
}

