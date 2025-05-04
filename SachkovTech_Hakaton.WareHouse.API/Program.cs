var builder = WebApplication.CreateBuilder(args);

// ���������� �������� � ��������� DI
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; // ��������� �������������� ��������� ������
    });

// ����������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Warehouse API", Version = "v1" });
});

// ����������� �� (����� ������������ AddDbContext)
builder.Services.AddDbContext<WareHouseDbContext>();

// ����������� ������������ � ��������
builder.Services.AddTransient<IWareHouseRepository, WareHousesRepository>();
builder.Services.AddTransient<IWareHouseService, WareHouseService>();

var app = builder.Build();

// �������� � ������������� �� (������ ��� ����������)
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<WareHouseDbContext>();
    await dbContext.Database.EnsureCreatedAsync(); // ��� ����� ����� ������������ ��������

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouse API v1");
    });
}

// Middleware pipeline
app.UseHttpsRedirection();
app.UseRouting(); // ����� ���������� �������������

// ��������� CORS (�������� �������� ������ UseCors() ��� ����������)
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication(); // ��������, ���� ����������� ��������������
app.UseAuthorization();

app.MapControllers();

app.Run();