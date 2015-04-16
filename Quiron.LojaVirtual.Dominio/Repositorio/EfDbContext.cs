using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext: DbContext 
    {
        public DbSet<Produto> Produtos { get; set; }

        //Sobreescrevendo, retira pluralização, por exemplo produto para produtos
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Cria mapeamento de produto para produtos
            modelBuilder.Entity<Produto>().ToTable("Produtos");

        }
    }
}
