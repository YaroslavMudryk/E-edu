namespace Eedu.Data.Enums;

public enum AssignmentStatus
{
    Pending = 1,      // Assignment is pending approval
    Active = 2,       // Student is actively assigned to room
    Completed = 3,    // Assignment has ended (student moved out)
    Cancelled = 4,    // Assignment was cancelled
    Suspended = 5     // Assignment is temporarily suspended
}

