using IPMA_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// =======================
// Serviços
// =======================

// Controllers
builder.Services.AddControllers();

// HttpClient + Repository
builder.Services.AddHttpClient<Repository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// =======================
// Pipeline HTTP
// =======================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
