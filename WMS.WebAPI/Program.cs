using WMS.Infrastructure.DependencyInjection;
namespace WMS.WebAPI
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
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddGiaBaoDI(builder.Configuration);
            builder.Services.AddLeHuyDI(builder.Configuration);
            builder.Services.AddQuocBaoDI(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(Program));
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

            app.UseCors(o =>
            {
                o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });


            app.Run();
        }
    }
}
