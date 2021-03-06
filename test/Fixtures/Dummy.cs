﻿using System;
using System.Runtime.Serialization;
using PipServices3.Commons.Data;

namespace PipServices3.MySql.Persistence
{
    [DataContract]
    public class Dummy : IStringIdentifiable
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "create_time_utc")]
        public DateTime CreateTimeUtc { get; set; }

        [DataMember(Name = "sub_dummy")]
        public SubDummy SubDummy { get; set; } = new SubDummy();
    }
}
