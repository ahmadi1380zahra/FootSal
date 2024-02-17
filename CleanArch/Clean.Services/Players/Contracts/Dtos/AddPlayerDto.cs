using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Players.Contracts.Dtos
{
    public class AddPlayerDto
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}
