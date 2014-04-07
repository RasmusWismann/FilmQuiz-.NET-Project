using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        private static FilmQuizServiceReferenceLocal.FilmQuizClient Client = 
        new FilmQuizServiceReferenceLocal.FilmQuizClient();

        static void Main(string[] args)
        {
            Client.Open();
            System.Console.ReadKey();
            Client.Close();
        }

        private static void TestGetAllCategories() 
        {
            var response = Client.GetAllCategories();

            foreach (var c in response.Data)
            {
                Console.WriteLine(c.Name);
                Console.WriteLine(c.Id);
            }
        }

        private static void TestGetCategory()
        {
            var response = Client.GetCategory(4);

            Console.WriteLine(response.Data.Name);
            Console.WriteLine(response.Data.Id);
        }
    }
}
