using Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Estoque.Infra.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(prop => prop.ProdutoId);

            builder.Property(prop => prop.DescricaoProduto)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("DescricaoProduto")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.SituacaoProduto)
               .HasConversion(prop => (bool)prop, prop => prop)
               .IsRequired()
               .HasColumnName("SituacaoProduto");

            builder.Property(prop => prop.DataFabricacao)
                .HasConversion(prop => (DateTime)prop, prop => prop)
                .IsRequired()
                .HasColumnName("DataFabricacao");

            builder.Property(prop => prop.DataValidade)
               .HasConversion(prop => (DateTime)prop, prop => prop)
               .IsRequired()
               .HasColumnName("DataValidade");

            builder.Property(prop => prop.CodigoFornecedor)
               .HasConversion(prop => (int)prop, prop => prop)
               .IsRequired()
               .HasColumnName("CodigoFornecedor");

            builder.Property(prop => prop.DescricaoFornecedor)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("DescricaoFornecedor")
               .HasColumnType("varchar(100)");

            builder.Property(prop => prop.CNPJFornecedor)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("CNPJFornecedor");

            builder.Property(prop => prop.IsDeleted)
               .HasConversion(prop => (bool)prop, prop => prop)
               .IsRequired()
               .HasColumnName("IsDeleted");
        }

    }
}
