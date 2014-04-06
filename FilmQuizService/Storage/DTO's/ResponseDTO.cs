﻿using Storage.DTO_s.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Storage.DTO_s
{
    [DataContract]
    public class ResponseDTO<T>
    {
        [DataMember]
        public Status Status { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public T Data { get; set; }
    }
}
