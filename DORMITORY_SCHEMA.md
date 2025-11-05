# Dormitory Management Database Schema

## Overview
This document describes the database schema for a university dormitory management system. The schema follows the existing project patterns using Entity Framework Core, soft-deletable entities, versioning, and multi-tenancy support.

## Entity Relationship Diagram

```
University
  ├── Dormitory (1:N)
      ├── Floor (1:N)
      │   └── Room (1:N)
      │       ├── RoomAssignment (N:M with User)
      │       ├── RoomAmenity (1:N)
      │       ├── RoomInspection (1:N)
      │       ├── MaintenanceRequest (1:N)
      │       └── FurnitureItem (1:N)
      └── Room (1:N) [direct relationship]
```

## Entities

### Core Entities

#### 1. Dormitory
Represents a dormitory building within a university.

**Properties:**
- `Id` (Guid) - Primary key
- `Name` (string) - Name of the dormitory
- `Address` (string) - Physical address
- `Description` (string) - Description of the dormitory
- `Capacity` (int) - Total capacity in terms of beds
- `ContactPhone` (string) - Contact phone number
- `ContactEmail` (string) - Contact email
- `IsActive` (bool) - Whether the dormitory is currently active
- `UniversityId` (Guid) - Foreign key to University
- `TenantId` (string) - Multi-tenancy identifier
- Standard audit fields: `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`, `Version`

**Relationships:**
- Belongs to one `University`
- Has many `Floors`
- Has many `Rooms` (direct and via Floor)

**Indexes:**
- Unique index on (`UniversityId`, `Name`)

---

#### 2. Floor
Represents a floor within a dormitory building.

**Properties:**
- `Id` (Guid) - Primary key
- `FloorNumber` (int) - Floor number (e.g., 1, 2, 3)
- `Name` (string) - Floor name (e.g., "First Floor", "Ground Floor")
- `Description` (string) - Description of the floor
- `Capacity` (int) - Total capacity in terms of beds
- `DormitoryId` (Guid) - Foreign key to Dormitory
- `TenantId` (string) - Multi-tenancy identifier
- Standard audit fields

**Relationships:**
- Belongs to one `Dormitory`
- Has many `Rooms`

**Indexes:**
- Unique index on (`DormitoryId`, `FloorNumber`)

---

#### 3. Room
Represents an individual room within a dormitory.

**Properties:**
- `Id` (Guid) - Primary key
- `Number` (string) - Room number (e.g., "101", "2A-15")
- `Type` (RoomType enum) - Type of room (Single, Double, Triple, Quad, Suite)
- `Status` (RoomStatus enum) - Current status (Available, Occupied, UnderMaintenance, Reserved, OutOfService)
- `Capacity` (int) - Maximum number of occupants
- `CurrentOccupancy` (int) - Current number of occupants
- `Area` (decimal) - Room area in square meters
- `Description` (string) - Description of the room
- `HasPrivateBathroom` (bool) - Whether room has private bathroom
- `HasKitchen` (bool) - Whether room has kitchen facilities
- `IsAccessible` (bool) - Whether room is accessible for disabled students
- `FloorId` (Guid) - Foreign key to Floor
- `DormitoryId` (Guid) - Foreign key to Dormitory
- `TenantId` (string) - Multi-tenancy identifier
- Standard audit fields

**Relationships:**
- Belongs to one `Floor`
- Belongs to one `Dormitory`
- Has many `RoomAssignments`
- Has many `RoomAmenities`
- Has many `RoomInspections`
- Has many `MaintenanceRequests`
- Has many `FurnitureItems`

**Indexes:**
- Unique index on (`FloorId`, `Number`)

---

#### 4. RoomAssignment
Represents the assignment of a student to a room.

**Properties:**
- `Id` (Guid) - Primary key
- `StartDate` (DateTime) - Assignment start date
- `EndDate` (DateTime?) - Assignment end date (null if currently active)
- `Status` (AssignmentStatus enum) - Assignment status (Pending, Active, Completed, Cancelled, Suspended)
- `Notes` (string) - Additional notes
- `MonthlyFee` (decimal) - Monthly fee for the room
- `UserId` (Guid) - Foreign key to User (student)
- `RoomId` (Guid) - Foreign key to Room
- `AssignedById` (Guid?) - Foreign key to User (admin/staff who assigned)
- `TenantId` (string) - Multi-tenancy identifier
- Standard audit fields

**Relationships:**
- Belongs to one `User` (student)
- Belongs to one `Room`
- Belongs to one `User` (assigned by - admin/staff)
- Has many `RoomFees`

**Indexes:**
- Unique filtered index on (`UserId`, `RoomId`, `StartDate`) where Status IN (Pending, Active, Suspended)

---

#### 5. RoomAmenity
Represents amenities available in a room.

**Properties:**
- `Id` (Guid) - Primary key
- `Name` (string) - Name of amenity (e.g., "WiFi", "Air Conditioning", "Refrigerator")
- `Description` (string) - Description of the amenity
- `IsAvailable` (bool) - Whether the amenity is currently available
- `RoomId` (Guid) - Foreign key to Room
- `TenantId` (string) - Multi-tenancy identifier
- Standard audit fields

**Relationships:**
- Belongs to one `Room`

---

#### 6. RoomInspection
Represents room inspections performed by staff.

**Properties:**
- `Id` (Guid) - Primary key
- `InspectionDate` (DateTime) - Date of inspection
- `ScheduledDate` (DateTime?) - Scheduled inspection date
- `Status` (InspectionStatus enum) - Inspection status (Scheduled, InProgress, Passed, Failed, RequiresFollowUp)
- `Notes` (string) - Inspection notes
- `Findings` (string) - Detailed findings (JSON or text)
- `Score` (int?) - Optional scoring (e.g., 1-100)
- `RequiresFollowUp` (bool) - Whether follow-up is required
- `FollowUpDate` (DateTime?) - Follow-up date if required
- `RoomId` (Guid) - Foreign key to Room
- `InspectedById` (Guid) - Foreign key to User (inspector)
- `TenantId` (string) - Multi-tenancy identifier
- Standard audit fields

**Relationships:**
- Belongs to one `Room`
- Belongs to one `User` (inspector)

---

#### 7. MaintenanceRequest
Represents maintenance requests for rooms.

**Properties:**
- `Id` (Guid) - Primary key
- `Title` (string) - Request title
- `Description` (string) - Detailed description
- `Status` (MaintenanceStatus enum) - Request status (Pending, InProgress, Completed, Cancelled)
- `Priority` (string) - Priority level (Low, Medium, High, Urgent)
- `RequestDate` (DateTime) - Date request was made
- `CompletedDate` (DateTime?) - Date maintenance was completed
- `ResolutionNotes` (string) - Notes about resolution
- `Cost` (decimal?) - Cost of maintenance
- `RoomId` (Guid) - Foreign key to Room
- `RequestedById` (Guid) - Foreign key to User (requester)
- `AssignedToId` (Guid?) - Foreign key to User (maintenance staff)
- `TenantId` (string) - Multi-tenancy identifier
- Standard audit fields

**Relationships:**
- Belongs to one `Room`
- Belongs to one `User` (requester)
- Belongs to one `User` (assigned maintenance staff)

---

#### 8. RoomFee
Represents fees/payments associated with room assignments.

**Properties:**
- `Id` (Guid) - Primary key
- `Description` (string) - Fee description (e.g., "Monthly Rent", "Utilities", "Deposit")
- `Amount` (decimal) - Fee amount
- `DueDate` (DateTime) - Payment due date
- `PaidDate` (DateTime?) - Date payment was made
- `Status` (PaymentStatus enum) - Payment status (Pending, Paid, Overdue, Cancelled, Refunded)
- `PaymentMethod` (string) - Payment method (Cash, Bank Transfer, Credit Card, etc.)
- `TransactionReference` (string) - Transaction reference number
- `Notes` (string) - Additional notes
- `RoomAssignmentId` (Guid) - Foreign key to RoomAssignment
- `ProcessedById` (Guid?) - Foreign key to User (staff who processed payment)
- `TenantId` (string) - Multi-tenancy identifier
- Standard audit fields

**Relationships:**
- Belongs to one `RoomAssignment`
- Belongs to one `User` (processed by)

---

#### 9. FurnitureItem
Represents furniture and equipment in rooms.

**Properties:**
- `Id` (Guid) - Primary key
- `Name` (string) - Item name (e.g., "Bed", "Desk", "Chair", "Wardrobe")
- `Description` (string) - Description of the item
- `SerialNumber` (string) - Serial number (optional)
- `Condition` (string) - Condition status (New, Good, Fair, Poor)
- `PurchaseDate` (DateTime?) - Date item was purchased
- `PurchasePrice` (decimal?) - Purchase price
- `IsAvailable` (bool) - Whether item is currently available
- `RoomId` (Guid) - Foreign key to Room
- `TenantId` (string) - Multi-tenancy identifier
- Standard audit fields

**Relationships:**
- Belongs to one `Room`

**Indexes:**
- Unique filtered index on `SerialNumber` where SerialNumber IS NOT NULL

---

## Enums

### RoomType
- `Single` (1) - Single occupancy room
- `Double` (2) - Double occupancy room
- `Triple` (3) - Triple occupancy room
- `Quad` (4) - Quad occupancy room
- `Suite` (5) - Suite with multiple rooms

### RoomStatus
- `Available` (1) - Room is available for assignment
- `Occupied` (2) - Room is currently occupied
- `UnderMaintenance` (3) - Room is under maintenance
- `Reserved` (4) - Room is reserved for upcoming assignment
- `OutOfService` (5) - Room is out of service

### AssignmentStatus
- `Pending` (1) - Assignment is pending approval
- `Active` (2) - Student is actively assigned to room
- `Completed` (3) - Assignment has ended (student moved out)
- `Cancelled` (4) - Assignment was cancelled
- `Suspended` (5) - Assignment is temporarily suspended

### MaintenanceStatus
- `Pending` (1) - Request is pending
- `InProgress` (2) - Maintenance is in progress
- `Completed` (3) - Maintenance is completed
- `Cancelled` (4) - Request was cancelled

### InspectionStatus
- `Scheduled` (1) - Inspection is scheduled
- `InProgress` (2) - Inspection is in progress
- `Passed` (3) - Room passed inspection
- `Failed` (4) - Room failed inspection
- `RequiresFollowUp` (5) - Inspection requires follow-up

### PaymentStatus
- `Pending` (1) - Payment is pending
- `Paid` (2) - Payment is completed
- `Overdue` (3) - Payment is overdue
- `Cancelled` (4) - Payment was cancelled
- `Refunded` (5) - Payment was refunded

---

## Design Patterns

### Base Models
All entities inherit from `BaseModel<TId>` which provides:
- `Id` (Guid)
- `CreatedAt` (DateTime)
- `CreatedBy` (string)
- `UpdatedAt` (DateTime)
- `UpdatedBy` (string)
- `Version` (int) - Optimistic concurrency control

### Multi-Tenancy
All dormitory entities implement `ITenantEntity`:
- `TenantId` (string) - Identifies the university (tenant)

### Relationships
- **University → Dormitory**: One-to-Many
- **Dormitory → Floor**: One-to-Many
- **Dormitory → Room**: One-to-Many (direct)
- **Floor → Room**: One-to-Many
- **Room → RoomAssignment**: One-to-Many
- **User → RoomAssignment**: One-to-Many (as student)
- **User → RoomAssignment**: One-to-Many (as assigner/admin)
- **RoomAssignment → RoomFee**: One-to-Many
- **Room → RoomAmenity**: One-to-Many
- **Room → RoomInspection**: One-to-Many
- **Room → MaintenanceRequest**: One-to-Many
- **Room → FurnitureItem**: One-to-Many

---

## Use Cases Supported

1. **Room Management**
   - Create and manage dormitory buildings
   - Organize rooms by floors
   - Track room capacity and occupancy
   - Manage room types and amenities

2. **Student Assignment**
   - Assign students to rooms
   - Track assignment history
   - Handle room transfers
   - Monitor occupancy levels

3. **Maintenance Management**
   - Submit maintenance requests
   - Assign maintenance staff
   - Track maintenance status and costs
   - Schedule follow-ups

4. **Room Inspections**
   - Schedule room inspections
   - Record inspection findings
   - Track inspection scores
   - Manage follow-up inspections

5. **Financial Management**
   - Record room fees and payments
   - Track payment status
   - Handle refunds
   - Generate payment reports

6. **Inventory Management**
   - Track furniture and equipment
   - Monitor item conditions
   - Manage serial numbers
   - Track purchase history

---

## Notes

- All entities support soft-delete where appropriate (via `ISoftDeletable`)
- All entities are versioned for optimistic concurrency control
- Multi-tenancy is supported through `TenantId` field
- Foreign key relationships use `DeleteBehavior.Restrict` to prevent accidental deletions
- Unique indexes prevent duplicate assignments and room numbers
- Filtered indexes are used for conditional uniqueness constraints

