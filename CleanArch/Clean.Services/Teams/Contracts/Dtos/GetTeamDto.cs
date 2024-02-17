using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Teams.Contracts.Dtos
{
    public class GetTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainColor { get; set; }
        public string SubColor { get; set; }
    }
}
