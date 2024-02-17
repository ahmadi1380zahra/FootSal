using Clean.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Teams.Contracts.Dtos
{
    public class UpdateTeamDto
    {
        public string Name { get; set; }
        public Color MainColor { get; set; }
        public Color SubColor { get; set; }
    }
}
