using IntroEFCore.Data.Configurations;
using IntroEFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroEFCore.Data
{
    internal class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;Database=CursoEFCore;Uid=root;Pwd=1234;", new MySqlServerVersion(new Version(8, 0)));
        }


        public DbSet<Pedido> Pedidos { get; set; } //Precisa disso?? Sim precisa
        public DbSet<Produto> Produtos { get; set; } //Precisa disso?? Pra persistir os dados
        public DbSet<Cliente> Clientes { get; set; } //Precisa disso?? E Interagir com o banco de usados, vc usa essas instancias


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ClienteConfig()); -> Forma manual
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
