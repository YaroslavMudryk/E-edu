namespace Eedu.Data.Enums;

public enum InspectionStatus
{
    Scheduled = 1,    // Inspection is scheduled
    InProgress = 2,  // Inspection is in progress
    Passed = 3,      // Room passed inspection
    Failed = 4,      // Room failed inspection
    RequiresFollowUp = 5  // Inspection requires follow-up
}

