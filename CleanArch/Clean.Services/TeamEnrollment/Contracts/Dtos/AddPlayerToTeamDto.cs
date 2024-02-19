using Clean.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.TeamEnrollment.Contracts.Dtos
{
    public class AddPlayerToTeamDto
    {
        public int PlayerId { get; set; }
        public PlayerPost PlayerPost { get; set; }
    }
}
