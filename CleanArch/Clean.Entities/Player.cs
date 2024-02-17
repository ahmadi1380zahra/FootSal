using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
    public enum PlayerPost
    {
        defender,
        attacker,
        keeper
    }
}
