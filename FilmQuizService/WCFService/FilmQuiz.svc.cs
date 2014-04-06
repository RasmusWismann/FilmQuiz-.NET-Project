using Storage;
using Storage.DTO_s;
using Storage.DTO_s.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    public class FilmQuiz : IFilmQuiz
    {
        public ResponseDTO<CategoryDTO> GetCategory(int id)
        {
            string errorMessage = "";
            var result = DbAccessor.GetCategory(id, out errorMessage);

            if (string.IsNullOrEmpty(errorMessage))
            {
                return new ResponseDTO<CategoryDTO>
                {
                    ErrorMessage = errorMessage,
                    Status = Status.Failure,
                    Data = null
                };
            }
            else 
            {
                return new ResponseDTO<CategoryDTO> 
                {
                    ErrorMessage = null,
                    Status = Status.Success,
                    Data = result
                };
            }
        }

        public ResponseDTO<List<CategoryDTO>> GetAllCategories()
        {
            string errorMessage = "";
            var result = DbAccessor.GetCategories(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage))
            {
                return new ResponseDTO<List<CategoryDTO>>
                {
                    ErrorMessage = errorMessage,
                    Status = Status.Failure,
                    Data = null
                };
            }
            else
            {
                return new ResponseDTO<List<CategoryDTO>>
                {
                    ErrorMessage = null,
                    Status = Status.Success,
                    Data = result
                };
            }
        }

        public ResponseDTO<GameDTO> CreateNewGame(GameDTO game)
        {
            throw new NotImplementedException();
        }
    }
    
}
