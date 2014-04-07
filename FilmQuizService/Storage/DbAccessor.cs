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
                    // Setting game fields
                    var newGame = new Games()
                    {
                        Name = game.Name,
                        PlayerTurn = 1,
                        TurnNumber = 1,
                        Turns = game.Turns,
                    };

                    // Check if category is all or specific
                    if (game.Category == null)
                    {
                        newGame.Category = null;
                    }

                    // Creates game in db
                    dbContext.Games.Add(newGame);
                    dbContext.SaveChanges();

                    // Add players
                    string em = "";
                    AddPlayersToGame(game.Players, newGame.G_Id, out em);

                    // TODO - Add Questions

                    // Error handling
                    if (!string.IsNullOrEmpty(em))
                    {
                        errorMessage = em;
                        return null;
                    }

                    else
                    {
                        var getGame = GetGame(newGame.G_Id, out em);
                        if (!string.IsNullOrEmpty(em))
                        {
                            errorMessage = em;
                            return null;
                        }
                        else { errorMessage = null; return getGame; }
                    }
                }

                catch(Exception e)
                {
                    errorMessage = "Something went wrong on the server: " + e.Message;
                    return null;
                }
            }
        }

        public static GameDTO GetGame(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        private static void AddPlayersToGame(List<PlayerDTO> players, int gameId, out string errorMessage)
        {
            using (var dbContext = new FilmQuizDBEntities())
            {
                try
                {
                    foreach (var p in players)
                    {
                        var newPlayer = new Players
                        {
                            Name = p.Name,
                            Game = gameId,
                            Points = 0,
                        };
                        dbContext.Players.Add(newPlayer);
                    }
                    dbContext.SaveChanges();

                    errorMessage = null;
                }

                catch(Exception e)
                {
                    errorMessage = "Something went wrong on the server: " + e.Message;
                }
            }
        }
    }
}
