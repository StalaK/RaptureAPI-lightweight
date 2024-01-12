
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace RaptureAPI_lightweight;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<RaptureData>();

        builder.Services.AddRateLimiter(_ =>
        {
            _.AddFixedWindowLimiter("ratelimit", options =>
            {
                options.PermitLimit = 100;
                options.Window = TimeSpan.FromSeconds(60);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 5;
            });
        });

        var app = builder.Build();

        app.UseRateLimiter();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.RegisterEndpoints();

        app.Run();
    }
}

