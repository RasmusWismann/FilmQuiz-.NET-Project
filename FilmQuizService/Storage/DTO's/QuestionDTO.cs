using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Storage.DTO_s
{
    [DataContract]
    public class QuestionDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public AnswerDTO Answer { get; set; }
        [DataMember]
        public List<AnswerDTO> FakeAnswers { get; set; }
    }
}
