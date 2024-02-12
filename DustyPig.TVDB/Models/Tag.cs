using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Tag
    {
        public bool AllowsMultiple { get; set; }

        public string HelpText { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<TagOption> Options { get; set; } = [];
    }

}
