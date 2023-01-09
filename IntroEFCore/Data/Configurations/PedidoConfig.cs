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
    public class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Status).HasConversion<string>();
            builder.Property(p => p.TipoFrete).HasConversion<int>();
            builder.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");
            //Configura o relacionamento das tabelas
            builder.HasMany(p => p.Itens) //Muitos Itens para Um pedido (Muitos para um, N-1)
            .WithOne(p => p.Pedido).OnDelete(DeleteBehavior.Cascade); //Deleção em cascata. Ao deletar um pedido, todos os itens dele serão deletados também
        }
    }
}
