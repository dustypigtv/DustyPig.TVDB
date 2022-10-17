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


        public Task<Response<MovieExtendedRecord>> GetExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"movies/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return _client.GetAsync<MovieExtendedRecord>(url, cancellationToken);
        }

        public Task<Response<List<MovieBaseRecord>>> FilterAsync(string country, string lang, int? company = null, int? contentRating = null, int? genre = null, FilterSort? filterSort = null, int? status = null, int? year = null, CancellationToken cancellationToken = default)
        {
            string url = $"movies/filter?country={Uri.EscapeDataString(country)}&lang={Uri.EscapeDataString(lang)}";
            
            if (company != null)
                url += $"&company={company}";
            
            if (contentRating != null)
                url += $"&contentRating={contentRating}";
            
            if (genre != null)
                url += $"&genre={genre}";
            
            if (filterSort != null)
            {
                switch (filterSort)
                {
                    case FilterSort.Name:
                        url += "&sort=name";
                        break;

                    case FilterSort.Score:
                        url += "&sort=score";
                        break;

                    case FilterSort.FirstAired:
                        url += "&sort=firstAired";
                        break;
                }
            }

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
