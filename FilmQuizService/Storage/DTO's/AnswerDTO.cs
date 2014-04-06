using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Storage.DTO_s
{
    [DataContract]
    public class AnswerDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Answer { get; set; }
    }
}
