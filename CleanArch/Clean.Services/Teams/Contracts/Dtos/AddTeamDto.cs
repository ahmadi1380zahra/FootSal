using Clean.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Teams.Contracts.Dtos
{
    public class AddTeamDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Color MainColor { get; set; }
        [Required]
        public Color SubColor { get; set; }
    }
}
