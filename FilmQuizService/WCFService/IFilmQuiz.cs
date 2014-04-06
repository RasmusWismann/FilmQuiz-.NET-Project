using System;
using Storage.DTO_s;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    [ServiceContract]
    public interface IFilmQuiz
    {
        [OperationContract]
        ResponseDTO<CategoryDTO> GetCategory(int id);

        [OperationContract]
        ResponseDTO<List<CategoryDTO>> GetAllCategories();

        [OperationContract]
        ResponseDTO<GameDTO> CreateNewGame(GameDTO game);
    }
}
