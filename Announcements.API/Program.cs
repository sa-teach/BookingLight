using Announcements.API.Data;
using Announcements.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseInMemoryDatabase("AnnouncementsDb"));

var app = builder.Build();

// 
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BookingDbContext>();

    if (!db.Announcements.Any())
    {
        // Id зафиксированы, чтобы вы могли использовать их в запросах к Bookings.API
        db.Announcements.AddRange(
            new Announcement
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Title = "Светлая студия у Красной площади",
                Description = "Уютная студия в центре Москвы, 5 минут пешком до метро.",
                PricePerNight = 5500m,
                City = "Москва"
            },
            new Announcement
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Title = "Квартира с видом на Неву",
                Description = "Двухкомнатная квартира на набережной, рядом Эрмитаж.",
                PricePerNight = 7200m,
                City = "Санкт-Петербург"
            },
            new Announcement
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Title = "Апартаменты у моря",
                Description = "Апартаменты с балконом, 100 метров до пляжа.",
                PricePerNight = 4800m,
                City = "Сочи"
            },
            new Announcement
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Title = "Лофт в историческом центре",
                Description = "Просторный лофт рядом с Казанским кремлём.",
                PricePerNight = 3900m,
                City = "Казань"
            });

        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
