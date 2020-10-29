using System;

namespace ChallanManagement.API
{
    public class Challan
    {
        public long ChallanId { get; set; }
        public string MobileNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string Offence { get; set; }
        public string OffencePlace { get; set; }
        public long Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Status { get; set; }
    }
}
