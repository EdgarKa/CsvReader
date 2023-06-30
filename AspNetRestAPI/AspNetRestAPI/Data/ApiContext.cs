using AspNetRestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetRestAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
    }
}
