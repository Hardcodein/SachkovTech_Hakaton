var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов в контейнер DI
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; // Отключает автоматическую валидацию модели
    });

// Регистрация Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Warehouse API", Version = "v1" });
});

// Регистрация БД (лучше использовать AddDbContext)
builder.Services.AddDbContext<WareHouseDbContext>();

// Регистрация репозиториев и сервисов
builder.Services.AddTransient<IWareHouseRepository, WareHousesRepository>();
builder.Services.AddTransient<IWareHouseService, WareHouseService>();

var app = builder.Build();

// Миграции и инициализация БД (только для разработки)
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<WareHouseDbContext>();
    await dbContext.Database.EnsureCreatedAsync(); // Для прода лучше использовать миграции

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouse API v1");
    });
}

// Middleware pipeline
app.UseHttpsRedirection();
app.UseRouting(); // Явное добавление маршрутизации

// Настройка CORS (добавьте политику вместо UseCors() без параметров)
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication(); // Добавьте, если используете аутентификацию
app.UseAuthorization();

app.MapControllers();

app.Run();