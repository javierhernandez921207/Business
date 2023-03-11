using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MiNegocio.Server.Models;
using MiNegocio.Shared.Models;

namespace MiNegocio.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Business> Business { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductInput> ProductInput { get; set; }

    }
}