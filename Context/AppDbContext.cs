﻿using Microsoft.EntityFrameworkCore;
using Registro_de_Ponto_CTEDS.Models;

namespace Registro_de_Ponto_CTEDS.Context
{
    public class AppDbContext : DbContext
    {
        //Configuração do Entity Framework e referencias aos models para criar o contexto do banco de dados

        public string DbPath;
        public DbSet<Employee> employees { get; set; }
        public DbSet<Clock> clocks { get; set; }
        public DbSet<User> users { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = System.IO.Path.Join(path, "registro-ponto.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    }
}