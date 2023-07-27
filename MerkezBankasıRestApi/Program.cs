using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MerkezBankasıRestApi.Services;
using MerkezBankasıRestApi.Data;
using MerkezBankasıRestApi.Kurlar;
using Hangfire;

namespace MerkezBankasıRestApi
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
            builder.Services.AddHangfire(config => config
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
		        .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
			builder.Services.AddHangfireServer();
			builder.Services.AddScoped<IMerkezBankasi, MerkezBankasiServisi>();
            builder.Services.AddDbContext<DataContext>();

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

			app.UseHangfireDashboard();

			app.MapHangfireDashboard();

			RecurringJob.AddOrUpdate<IMerkezBankasi>(x => x.AutoRun(), "00 30 15 ? * *",TimeZoneInfo.Local);

			app.Run();
        }
    }
}