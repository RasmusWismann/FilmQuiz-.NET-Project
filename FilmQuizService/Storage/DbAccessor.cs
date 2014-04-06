using Storage.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class DbAccessor
    {
        public static CategoryDTO GetCategory(int id, out string errorMessage)
        {
            using (var dbContext = new FilmQuizDBEntities())
            {
                try
                {
                    var category = dbContext.Categories
                    .Where(c => c.C_Id == id)
                    .Single();

                    errorMessage = null;
                    return new CategoryDTO
                    {
                        Id = category.C_Id,
                        Name = category.Name
                    };
                }
                catch (Exception e)
                {
                    errorMessage = "Something went wrong on the server: " + e.Message;
                    return null;
                }
            }
        }

        public static List<CategoryDTO> GetCategories(out string errorMessage)
        {
            using (var dbContext = new FilmQuizDBEntities())
            {
                try
                {
                    var catList = new List<CategoryDTO>();
                    foreach (Categories c in dbContext.Categories)
                    {
                        catList.Add(new CategoryDTO
                        {
                            Id = c.C_Id,
                            Name = c.Name
                        }
                        );
                    }

                    errorMessage = null;
                    return catList;
                }
                catch (Exception e) 
                {
                    errorMessage = "Something went wrong on the server: " + e.Message;
                    return null;
                }
                
            }
        }

        public static GameDTO CreateNewGame(GameDTO game, out string errorMessage)
        {
            using (var dbContext = new FilmQuizDBEntities())
            {
                try
                {
                    errorMessage = null;
                    return null;
                }
                catch(Exception e)
                {
                    errorMessage = "Something went wrong on the server: " + e.Message;
                    return null;
                }
            }
            

        }

        //public static CategoryDTO AddNewCategory(CategoryDTO cat)
        //{
        //    using (var dbContext = new FilmQuizDBEntities())
        //    {
        //        var category = new Categories 
        //        {
        //            Name = cat.Name
        //        };

        //        dbContext.Categories.Add(category);
        //        dbContext.SaveChanges();

        //        return new CategoryDTO
        //        {
        //            Id = category.C_Id,
        //            Name = category.Name
        //        };
        //    }
        //}

        //public static CategoryDTO EditCategory(CategoryDTO cat)
        //{
        //    using (var dbContext = new FilmQuizDBEntities())
        //    {
        //        var category = dbContext.Categories
        //            .Where(c => c.C_Id == cat.Id)
        //            .Single();
                
        //        category.Name = cat.Name;

        //        dbContext.SaveChanges();

        //        return new CategoryDTO
        //        {
        //            Id = category.C_Id,
        //            Name = category.Name
        //        };
        //    }
        //}

        

        //public static void DeleteCategory(int id)
        //{
        //    using (var dbContext = new FilmQuizDBEntities())
        //    {
        //        var category = dbContext.Categories
        //            .Where(c => c.C_Id == id)
        //            .Single();

        //        dbContext.Categories.Remove(category);
        //        dbContext.SaveChanges();
        //    }
        //}

        
    }
}
