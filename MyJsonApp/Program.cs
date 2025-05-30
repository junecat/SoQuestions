
using Microsoft.OpenApi.Models;

namespace MyJsonApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

	// Вешаюсь на определенный хост/порт
	builder.WebHost.UseUrls("http://0.0.0.0:5000", "https://0.0.0.0:5001");

        // Регистрация сервисов
        builder.Services.AddControllers(); // Подключаем поддержку контроллеров

        // Включаю Swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My JSON App API",
                Version = "v1",
                Description = "Пример проекта ASP.NET Core с возвращением статического JSON файла."
            });
        });



        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        // builder.Services.AddOpenApi();


        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My JSON App V1"); // Отображаем документ
        });

        // Конвейер обработчиков запросов
        // app.UseHttpsRedirection();
        app.UseRouting();

        // Маршрутизация к контроллерам
        app.UseEndpoints(endpoints => endpoints.MapControllers());

        // Запуск приложения
        app.Run();
    }
}
