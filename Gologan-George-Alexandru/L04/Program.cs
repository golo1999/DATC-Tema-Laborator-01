using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Models;

namespace L04
{
    class Program
    {
        private static CloudTableClient tableClient;
        private static CloudTable studentsTable;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Task.Run(async () => { await Initialize(); })
                .GetAwaiter()
                .GetResult();
        }

        static async Task Initialize()
        {
            string storageConnectionString = "";

            var account = CloudStorageAccount.Parse(storageConnectionString);

            tableClient = account.CreateCloudTableClient();
            studentsTable = tableClient.GetTableReference("students");

            await studentsTable.CreateIfNotExistsAsync();
            await AddNewStudent();
            await GetAllStudents();
        }

        private static async Task GetAllStudents()
        {
            Console.WriteLine("University\tPIN\tName\tEmail\tPhone\tYear");

            TableQuery<StudentEntity> query = new TableQuery<StudentEntity>();

            TableContinuationToken token = null;

            do
            {
                TableQuerySegment<StudentEntity> resultSegment = await studentsTable.ExecuteQuerySegmentedAsync(query, token);

                token = resultSegment.ContinuationToken;

                foreach (StudentEntity entity in resultSegment.Results)
                {
                    Console.WriteLine("{0}\t{1}\t{2} {3}\t{4}\t{5}\t{6}", entity.PartitionKey, entity.RowKey,
                    entity.FirstName, entity.LastName, entity.Email, entity.PhoneNumber, entity.Year);
                }
            } while (token != null);
        }

        private static async Task AddNewStudent()
        {
            var student = new StudentEntity("UPT", "1690609666112");

            student.FirstName = "Gigel";
            student.LastName = "Borcan";
            student.Email = "gigel@gmail.com";
            student.Year = 1;
            student.PhoneNumber = "0769112666";
            student.Faculty = "AC";

            var insertOperation = TableOperation.Insert(student);

            await studentsTable.ExecuteAsync(insertOperation);
        }
    }
}
