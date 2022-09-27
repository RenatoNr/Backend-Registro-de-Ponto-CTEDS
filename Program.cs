using Registro_de_Ponto_CTEDS.Context;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Repositories;

namespace Registro_de_Ponto_CTEDS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Adicionando o contexto do banco de dados
            builder.Services.AddDbContext<AppDbContext>();
            //Serviço de Injeção das dependencias 
            builder.Services.AddScoped<IUser, UserRepository>();
            builder.Services.AddScoped<IEmployee, EmployeeRepository>();
            builder.Services.AddScoped<IClock, ClockRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}