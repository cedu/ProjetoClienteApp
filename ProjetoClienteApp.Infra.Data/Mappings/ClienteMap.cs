using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoClienteApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClienteApp.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //nome da tabela no banco de dados
            builder.ToTable("CLIENTE");

            //chave primária da tabela Cliente
            builder.HasKey(c => c.Id);

            //mapeamento dos demais campos da tabela
            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasColumnName("EMAIL").IsRequired();
            builder.Property(c => c.Cpf).HasColumnName("CPF").HasMaxLength(14).IsRequired();
            builder.Property(c => c.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();
            builder.Property(c => c.DataHoraUltimaAtualizacao).HasColumnName("DATAHORAULTIMAATUALIZACAO").IsRequired();

            //criando um índice para tornar o campo do CPF único na tabela
            builder.HasIndex(c => c.Cpf).IsUnique();
        }
    }
}
