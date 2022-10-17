namespace DustyPig.TVDB.Models
{
    public class EntityUpdate
    {
        public string EntityType { get; set; }

        public string Method { get; set; }

        public int RecordId { get; set; }

        public long TimeStamp { get; set; }

        /// <summary>Only present for episodes records</summary>
        public int SeriesId { get; set; }
    }

}
