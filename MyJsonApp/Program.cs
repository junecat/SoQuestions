
using Microsoft.OpenApi.Models;

namespace MyJsonApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ����������� ��������
        builder.Services.AddControllers(); // ���������� ��������� ������������

        // �������� Swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My JSON App API",
                Version = "v1",
                Description = "������ ������� ASP.NET Core � ������������ ������������ JSON �����."
            });
        });



        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        // builder.Services.AddOpenApi();


        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My JSON App V1"); // ���������� ��������
        });

        // �������� ������������ ��������
        // app.UseHttpsRedirection();
        app.UseRouting();

        // ������������� � ������������
        app.UseEndpoints(endpoints => endpoints.MapControllers());

        // ������ ����������
        app.Run();
    }
}
