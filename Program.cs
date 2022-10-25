using Microsoft.AspNetCore.Http.Features;
using Quartz;
using Registro_de_Ponto_CTEDS.Context;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Repositories;
using Registro_de_Ponto_CTEDS.Services;

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

            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;
            });

            //Adicionando o contexto do banco de dados
            builder.Services.AddDbContext<AppDbContext>();
            //Serviço de Injeção das dependencias 
            builder.Services.AddScoped<IUser, UserRepository>();
            builder.Services.AddScoped<IEmployee, EmployeeRepository>();
            builder.Services.AddScoped<IClock, ClockRepository>();
            builder.Services.AddScoped<IWorkDay, WorkDayRepository>();

            //Adicionado CronJOB para verificar faltas

            builder.Services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionScopedJobFactory();
                var cronJob = new JobKey("CronJob");
                q.AddJob<CronJob>(opt => opt.WithIdentity(cronJob));

                q.AddTrigger(opt => opt
                .ForJob(cronJob)
                .WithIdentity("CronJob-trigger")
                .WithCronSchedule("0 0 11 * * ?")); //Executa a função verificar faltas todo dia às 11:00 da noite
            }
            );
            builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
           // builder.Services.AddQuartzServer(opt => opt.WaitForJobsToComplete = true);

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