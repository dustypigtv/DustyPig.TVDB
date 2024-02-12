namespace DustyPig.TVDB.Models
{
    public class EntityUpdate
    {
        public string EntityType { get; set; }

        public int MethodInt { get; set; }

        public string Method { get; set; }

        public string ExtraInfo { get; set; }

        public int UserId { get; set; }

        public string RecordType { get; set; }

        public int RecordId { get; set; }

        public int TimeStamp { get; set; }

        /// <summary>Only present for episodes records</summary>
        public int? SeriesId { get; set; }

        public int MergeToId { get; set; }

        public string MergeToEntityType { get; set; }
    }

}
