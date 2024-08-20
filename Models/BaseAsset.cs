namespace Military_Asset_Management_client.Models
{
    public abstract class BaseAsset
    {
        public int Id { get; set; } // מזההייחודילכלנכס
        public string? Name { get; set; } // שםהנכס
        public string? AssetType { get; set; } //- סוגהנכס)לדוגמה : "Vehicle", "Weapon", "Personnel")
        public string? Status { get; set; } // מצבהנכס)לדוגמה : "Active", "Inactive", "Maintenance")       
    }
    public class Vehicle : BaseAsset
    {
        public string? Model { get; set; } // - דגםהרכב
        public string? LicensePlate { get; set; } // - מספררישוי
        public string? OperationalStatus { get; set; } // - מצבתפעולי)לדוגמה : "Operational", "Under ,Repair")
    }
}
