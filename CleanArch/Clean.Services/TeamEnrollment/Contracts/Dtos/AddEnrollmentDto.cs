using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.TeamEnrollment.Contracts.Dtos
{
    public class AddEnrollmentDto
    {
        public int TeamId { get; set; }
        public List<AddPlayerToTeamDto> AddPlayerToTeamDtos { get; set; }
    }
}
