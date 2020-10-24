using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_ServiceA.Models
{
    public class BoardGameRequest
    {
        public string Title { get; set; }
        public string PublishingCompany { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
    }
}
