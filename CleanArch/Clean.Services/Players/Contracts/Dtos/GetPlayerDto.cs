using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.Players.Contracts.Dtos
{
    public class GetPlayerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int  BirthDate { get; set; }
        public string TeamTitle { get; set; }
    }
}
