namespace Eedu.Data.Enums;

public enum RoomStatus
{
    Available = 1,      // Room is available for assignment
    Occupied = 2,      // Room is currently occupied
    UnderMaintenance = 3,  // Room is under maintenance
    Reserved = 4,      // Room is reserved for upcoming assignment
    OutOfService = 5   // Room is out of service
}

