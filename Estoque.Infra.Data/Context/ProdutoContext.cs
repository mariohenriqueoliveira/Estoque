using Estoque.Domain.Entities;
using Estoque.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Estoque.Infra.Data.Context
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Produto>(new ProdutoMap().Configure);
        }
    }
}
