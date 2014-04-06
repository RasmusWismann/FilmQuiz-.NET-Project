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
            System.Console.ReadKey();
        }

        private void TestGetAllCategories() 
        {
            var catList = Client.GetAllCategories();

            foreach (var c in catList)
            {
                Console.WriteLine(c.Name);
                Console.WriteLine(c.Id);
            }
        }

        private void TestGetCategory()
        {
            Client.GetCategory(4);
            
        }
    }
}
