using UBGWebApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace UBGWebApp.Data
{
    public static class TestDatabaseCommands
    {
        public static void Test(TestContext context)
        {
            context.Database.EnsureCreated();

            if (context.Tests.Any())
            {
                Console.WriteLine("There are, indeed, Tests in the db");
            }
            else
            {
                Console.WriteLine("There are, unfortunately, no Tests in the db");
            }

            var tests = new TestModel[]
            {
                new TestModel{Author="Test1", Description="Test1", Name="Test1", Title="Test1", Url="Test1"},
                new TestModel{Author="Test2", Description="Test2", Name="Test2", Title="Test2", Url="Test2"},
                new TestModel{Author="Test3", Description="Test3", Name="Test3", Title="Test3", Url="Test3"},
                new TestModel{Author="Test4", Description="Test4", Name="Test4", Title="Test4", Url="Test4"}
            };

            context.Tests.AddRange(tests);
            context.SaveChanges();
        }
    }
}
