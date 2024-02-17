using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Players.Contracts.Dtos
{
    public class UpdatePlayerDto
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TeamId { get; set; }
    }
}
