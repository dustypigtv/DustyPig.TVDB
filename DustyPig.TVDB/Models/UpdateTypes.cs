using System.Runtime.Serialization;

namespace DustyPig.TVDB.Models
{
    public enum UpdateTypes
    {
        [EnumMember(Value = @"artwork")]
        Artwork = 0,

        [EnumMember(Value = @"award_nominees")]
        AwardNominees = 1,

        [EnumMember(Value = @"companies")]
        Companies = 2,

        [EnumMember(Value = @"episodes")]
        Episodes = 3,

        [EnumMember(Value = @"lists")]
        Lists = 4,

        [EnumMember(Value = @"people")]
        People = 5,

        [EnumMember(Value = @"seasons")]
        Seasons = 6,

        [EnumMember(Value = @"series")]
        Series = 7,

        [EnumMember(Value = @"seriespeople")]
        SeriesPeople = 8,

        [EnumMember(Value = @"artworktypes")]
        ArtworkTypes = 9,

        [EnumMember(Value = @"award_categories")]
        AwardCategories = 10,

        [EnumMember(Value = @"awards")]
        Awards = 11,

        [EnumMember(Value = @"company_types")]
        CompanyTypes = 12,

        [EnumMember(Value = @"content_ratings")]
        Contentratings = 13,

        [EnumMember(Value = @"countries")]
        Countries = 14,

        [EnumMember(Value = @"entity_types")]
        EntityTypes = 15,

        [EnumMember(Value = @"genres")]
        Genres = 16,

        [EnumMember(Value = @"languages")]
        Languages = 17,

        [EnumMember(Value = @"movies")]
        Movies = 18,

        [EnumMember(Value = @"movie_genres")]
        MovieGenres = 19,

        [EnumMember(Value = @"movie_status")]
        MovieStatus = 20,

        [EnumMember(Value = @"peopletypes")]
        PeopleTypes = 21,

        [EnumMember(Value = @"seasontypes")]
        SeasonTypes = 22,

        [EnumMember(Value = @"sourcetypes")]
        SourceTypes = 23,

        [EnumMember(Value = @"tag_options")]
        TagOptions = 24,

        [EnumMember(Value = @"tags")]
        Tags = 25,

        [EnumMember(Value = @"translatedcharacters")]
        TranslatedCharacters = 26,

        [EnumMember(Value = @"translatedcompanies")]
        TranslatedCompanies = 27,

        [EnumMember(Value = @"translatedepisodes")]
        TranslatedEpisodes = 28,

        [EnumMember(Value = @"translatedlists")]
        TranslatedLists = 29,

        [EnumMember(Value = @"translatedmovies")]
        TranslatedMovies = 30,

        [EnumMember(Value = @"translatedpeople")]
        TranslatedPeople = 31,

        [EnumMember(Value = @"translatedseasons")]
        TranslatedSeasons = 32,

        [EnumMember(Value = @"translatedserierk")]
        TranslatedSerierk = 33,
    }

}
