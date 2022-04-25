using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteWGlobal.Domain.Models;

namespace TesteWGlobal.Repository.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(c => c.Sobrenome).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(c => c.DataNascimento).HasColumnType("DATE").IsRequired();
            builder.Property(c => c.Rg).HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(c => c.Cpf).HasColumnType("VARCHAR(11)").IsRequired();
            builder.Property(c => c.Endereco).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(c => c.DataCadastro).HasColumnType("TIMESTAMP").IsRequired();
            builder.Property(c => c.Ativo).HasColumnType("SMALLINT").IsRequired();

            builder.HasIndex(c => c.Cpf).IsUnique();
        }
    }
}
