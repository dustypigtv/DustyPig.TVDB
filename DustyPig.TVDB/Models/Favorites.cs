using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Favorites
    {
        public List<int> Series { get; set; } = [];

        public List<int> Episodes { get; set; } = [];

        public List<int> Artwork { get; set; } = [];

        public List<int> People { get; set; } = [];

        public List<int> Movies { get; set; } = [];

        public List<int> Lists { get; set; } = [];
    }
}
