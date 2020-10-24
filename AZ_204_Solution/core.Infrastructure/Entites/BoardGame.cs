﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace core.Infrastructure.Entites
{
    public class BoardGame
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string Title { get; set; }
        public string PublishingCompany { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
    }
}
