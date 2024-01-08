using Microsoft.OpenApi.Models;

namespace _7YA_HVOYA.API.Infrastructures
{
    static internal class DocumentExtensions
    {
        public static void GetSwaggerDocument(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Storage", new OpenApiInfo { Title = "Сущность склада", Version = "v1" });
                c.SwaggerDoc("Accommodation", new OpenApiInfo { Title = "Сущность размещения", Version = "v1" });
                c.SwaggerDoc("Cart", new OpenApiInfo { Title = "Сущность корзины", Version = "v1" });
                c.SwaggerDoc("Order", new OpenApiInfo { Title = "Сущность заказа", Version = "v1" });
                c.SwaggerDoc("Client", new OpenApiInfo { Title = "Сущность клиента", Version = "v1" });
                c.SwaggerDoc("Thing", new OpenApiInfo { Title = "Сущность вещи", Version = "v1" });

                var filePath = Path.Combine(AppContext.BaseDirectory, "7YA-HVOYA.API.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        public static void GetSwaggerDocumentUI(this WebApplication app)
        {
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("Storage/swagger.json", "Склады");
                x.SwaggerEndpoint("Accommodation/swagger.json", "Размещения");
                x.SwaggerEndpoint("Cart/swagger.json", "Корзина");
                x.SwaggerEndpoint("Order/swagger.json", "Заказы");
                x.SwaggerEndpoint("Client/swagger.json", "Клиенты");
                x.SwaggerEndpoint("Thing/swagger.json", "Вещи");
            });
        }
    }
}
