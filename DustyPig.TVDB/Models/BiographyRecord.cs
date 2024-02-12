namespace DustyPig.TVDB.Models
{
    /// <summary>
    /// Swagger calls this 'Biography', but since c# doesn't allow a property to have the same name as the containing class, I renamed this to 'BiographyRecord'
    /// </summary>
    public class BiographyRecord
    {
        public string Biography { get; set; }

        public string Language { get; set; }
    }

}
