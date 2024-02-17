using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Entities
{
    public class Team
    {
        public Team()
        {
            Players = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Color MainColor { get; set; }
        public Color SubColor { get; set; }

        public List<Player> Players { get; set; }
    }
    public enum Color
    {
        white=1,
        red=2,
        blue=3,
        yellow=4
    }
}
