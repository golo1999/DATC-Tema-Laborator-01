using Microsoft.WindowsAzure.Storage.Table;

namespace Models
{
    public class StudentEntity : TableEntity
    {
        public StudentEntity(string university, string pin)
        {
            this.PartitionKey = university;
            this.RowKey = pin;
        }

        public StudentEntity() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Year { get; set; }
        public string Faculty { get; set; }
    }
}