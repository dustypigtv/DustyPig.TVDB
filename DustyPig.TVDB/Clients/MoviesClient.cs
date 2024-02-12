using DustyPig.TVDB.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class MoviesClient
    {
        private readonly Client _client;

        internal MoviesClient(Client client) => _client = client;

        public Task<Response<List<MovieBaseRecord>>> GetAllAsync(int page = 0, CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<MovieBaseRecord>>("movies", page, cancellationToken);

        public Task<Response<MovieBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<MovieBaseRecord>($"movies/{id}", cancellationToken);


        /// <summary>
        /// Returns a single <see cref="MovieExtendedRecord"/>
        /// </summary>
        /// <param name="translations">Whethero or not to include <see cref="TranslationExtended"/></param>
        /// <param name="shortened">Reduce the payload and returns the short version of this record without characters, artworks and trailers.</param>
        public Task<Response<MovieExtendedRecord>> GetExtendedAsync(int id, bool translations = false, bool shortened = false, CancellationToken cancellationToken = default)
        {
            string url = $"movies/{id}/extended?short={shortened}";
            if (translations)
                url += "&meta=translations";

            return _client.GetAsync<MovieExtendedRecord>(url, cancellationToken);
        }

        /// <summary>
        /// Search movies based on filter parameters
        /// </summary>
        /// <param name="country">Required. Country of origin</param>
        /// <param name="lang">Required. Original language</param>
        /// <param name="company">Production company</param>
        /// <param name="contentRating">Content ratign id base on a country</param>
        /// <param name="genre">Genre</param>
        /// <param name="filterSort">Sort by results</param>
        /// <param name="status">Status</param>
        /// <param name="year">Release year</param>
        public Task<Response<List<MovieBaseRecord>>> FilterAsync(string country, string lang, int? company = null, int? contentRating = null, int? genre = null, MovieFilterSort? filterSort = null, int? status = null, int? year = null, CancellationToken cancellationToken = default)
        {
            string url = $"movies/filter?country={Uri.EscapeDataString(country)}&lang={Uri.EscapeDataString(lang)}";

            if (company != null)
                url += $"&company={company}";

            if (contentRating != null)
                url += $"&contentRating={contentRating}";

            if (genre != null)
                url += $"&genre={genre}";

            if (filterSort != null)
                url += "&sort=" + filterSort.ConvertToString();

            if (status != null && status > 0 && status < 4)
                url += $"&status={status}";

            if (year != null)
                url += $"&year={year}";

            return _client.GetAsync<List<MovieBaseRecord>>(url, cancellationToken);
        }

        public Task<Response<MovieBaseRecord>> GetAsync(string slug, CancellationToken cancellationToken = default) =>
            _client.GetAsync<MovieBaseRecord>($"movies/slug/{slug}", cancellationToken);



        public Task<Response<Translation>> GetTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            _client.GetAsync<Translation>($"movies/{id}/translations/{language}", cancellationToken);

    }
}
