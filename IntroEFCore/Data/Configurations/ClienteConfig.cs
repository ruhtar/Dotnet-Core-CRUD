using IntroEFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IntroEFCore.Data.Configurations
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");  //Dá nome a tabela do Modelo em questão.
            builder.HasKey(p => p.Id); //Informa qual é a chave primária da entidade cliente.
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired(); //Informa qual o tipo de dados que a coluna Nome vai receber. Também informa que é um valor não-nulo.
            builder.Property(p => p.Telefone).HasColumnType("CHAR(11)");
            builder.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(p => p.Cidade).HasMaxLength(60).IsRequired();
            builder.HasIndex(i => i.Telefone).HasDatabaseName("idx_cliente_telefone");
            //Cria um index para a coluna
        }
    }
}
