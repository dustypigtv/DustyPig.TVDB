using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class CompaniesClient
    {
        private readonly Client _client;

        internal CompaniesClient(Client client) => _client = client;

        public Task<Response<List<Company>>> GetAllCompaniesAsync(int page = 0, CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<Company>>("companies", page, cancellationToken);


        public Task<Response<List<CompanyType>>> GetAllTypesAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<CompanyType>>("companies/types", cancellationToken);


        public Task<Response<Company>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<Company>($"companies/{id}", cancellationToken);

    }
}
