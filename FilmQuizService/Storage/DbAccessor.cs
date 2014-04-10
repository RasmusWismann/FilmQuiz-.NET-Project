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
                    .SingleOrDefault();

                    errorMessage = null;
                    return ModelCategoryToDTO(category);
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
                    else
                    {
                        newGame.Category = game.Category.Id; 
                    }

                    // Creates game in db
                    dbContext.Games.Add(newGame);
                    dbContext.SaveChanges();

                    // Add players
                    string em = "";
                    AddPlayersToGame(game.Players, newGame.G_Id, out em);

                    if (!string.IsNullOrEmpty(em))
                    {
                        errorMessage = em;
                        return null;
                    }

                    else
                    {
                        // Add questions
                        AddQuestionsToGame(newGame.G_Id, out em, newGame.Category);

                        if (!string.IsNullOrEmpty(em))
                        {
                            errorMessage = em;
                            return null;
                        }

                        else
                        {
                            // Returns a fresh copy from the db, of the newly created game
                            var getGame = GetGame(newGame.G_Id, out em);
                            if (!string.IsNullOrEmpty(em))
                            {
                                errorMessage = em;
                                return null;
                            }
                            else { errorMessage = null; return getGame; }
                        }

                        
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

            using (var dbContext = new FilmQuizDBEntities())
            {
                try
                {
                    var game = dbContext.Games
                        .Include("Categories")
                        .Include("Players")
                        .Include("Questions")
                        .Include("Questions.Answers1")
                        .Where(g => g.G_Id == id)
                        .SingleOrDefault();

                    var gameResult = ModelGameToDTO(game);

                    errorMessage = null;
                    return gameResult;
                }

                catch (Exception e)
                {
                    errorMessage = "Something went wrong on the server: " + e.Message;
                    return null;
                }
            }
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
                            Number = p.Number,
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

        private static void AddQuestionsToGame(int gameId, out string errorMessage, int? categoryId = null)
        {
            using (var dbContext = new FilmQuizDBEntities())
            {
                try
                {

                    var game = dbContext.Games
                        .Where(g => g.G_Id == gameId)
                        .SingleOrDefault();

                    List<Questions> questions;

                    if (categoryId != null)
                    {
                        questions = dbContext.Questions
                            .Where(q => q.Category == categoryId)
                            .ToList();
                    }
                    else
                    {
                        questions = dbContext.Questions.ToList();
                    }

                    game.Questions = questions;

                    dbContext.SaveChanges();

                    errorMessage = null;
                }

                catch (Exception e)
                {
                    errorMessage = "Something went wrong on the server: " + e.Message;
                }
            }
        }

        private static CategoryDTO ModelCategoryToDTO(Categories category)
        {
            return new CategoryDTO
            {
                Id = category.C_Id,
                Name = category.Name
            };
        }

        private static PlayerDTO ModelPlayerToDTO(Players player) 
        {
            return new PlayerDTO
            {
                Id = player.P_Id,
                Name = player.Name,
                Number = player.Number,
                Points = player.Points
            };
        }

        private static QuestionDTO ModelQuestionToDTO(Questions question)
        {
            var questionResult = new QuestionDTO
            {
                Answer = ModelAnswerToDTO(question.Answers),
                Id = question.Q_Id,
                Category = ModelCategoryToDTO(question.Categories),
                Question = question.Question
            };

            var fakeAnswers = new List<AnswerDTO>();

            foreach (var a in question.Answers1)
            {
                fakeAnswers.Add(ModelAnswerToDTO(a));
            }

            questionResult.FakeAnswers = fakeAnswers;

            return questionResult;
        }

        private static AnswerDTO ModelAnswerToDTO(Answers answer)
        {
            return new AnswerDTO
            {
                Answer = answer.Answer,
                Id = answer.A_Id
            };
        }
        private static GameDTO ModelGameToDTO(Games game)
        {
            var gameResult = new GameDTO
            {
                Id = game.G_Id,
                Name = game.Name,
                PlayerTurn = game.PlayerTurn,
                TurnNumber = game.TurnNumber,
                Turns = game.Turns
            };

            var players = new List<PlayerDTO>();

            foreach (var p in game.Players)
            {
                players.Add(ModelPlayerToDTO(p));
            }

            var questions = new List<QuestionDTO>();

            foreach (var q in game.Questions)
            {
                questions.Add(ModelQuestionToDTO(q));
            }

            gameResult.Players = players;
            gameResult.Questions = questions;

            if (game.Categories == null)
            {
                gameResult.Category = null;
            }
            else
            {
                gameResult.Category = ModelCategoryToDTO(game.Categories);
            }

            return gameResult;
        }
    }
}
