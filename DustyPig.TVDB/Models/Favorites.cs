using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Favorites
    {
        public List<int> Series { get; set; } = new List<int>();

        public List<int> Episodes { get; set; } = new List<int>();

        public List<int> Artwork { get; set; } = new List<int>();

        public List<int> People { get; set; } = new List<int>();

        public List<int> Movies { get; set; } = new List<int>();

        public List<int> Lists { get; set; } = new List<int>();
    }
}
