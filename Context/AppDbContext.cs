using Microsoft.EntityFrameworkCore;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Models;
using BC = BCrypt.Net.BCrypt;

namespace Registro_de_Ponto_CTEDS.Context
{
    public class AppDbContext : DbContext
    {
        //Configuração do Entity Framework e referencias aos models para criar o contexto do banco de dados

        public string DbPath;
        public DbSet<Employee> employees { get; set; }
        public DbSet<Clock> clocks { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<WorkDay> workdays { get; set; }

        public AppDbContext() : base()
        {

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            DbPath = System.IO.Path.Join(baseDir, "registro-ponto.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(CreateAdminUser());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

       
        private static User CreateAdminUser()
        {
            string passwordHash = BC.HashPassword("password");
            return new User { Id=1, Cpf="0000", IsAdmin=true, Name="Admin", Password= passwordHash };   
        }

    }
}
