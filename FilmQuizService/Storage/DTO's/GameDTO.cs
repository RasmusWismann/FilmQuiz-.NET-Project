﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Storage.DTO_s
{
    [DataContract]
    public class GameDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Turns { get; set; }
        [DataMember]
        public int PlayerTurn { get; set; }
        [DataMember]
        public int TurnNumber { get; set; }
        [DataMember]
        public CategoryDTO Category { get; set; }
        [DataMember]
        public List<PlayerDTO> Players { get; set; }
        [DataMember]
        public List<QuestionDTO> Questions { get; set; }


    }
}
