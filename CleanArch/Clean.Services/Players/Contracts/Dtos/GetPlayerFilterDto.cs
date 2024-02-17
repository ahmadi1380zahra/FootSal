using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Players.Contracts.Dtos
{
    public class GetPlayerFilterDto
    {
        public string ?FullName { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
    }
}
