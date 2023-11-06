using AspNetCoreRateLimit;
using challenge.Filters;
using challenge.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NETChallenge.Data;
using NETChallenge.Dto;
using NETChallenge.Middlewares;
using NETChallenge.Services;
using NETChallenge.Services.Validaciones;
using Newtonsoft.Json;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

    // Agrega un esquema de seguridad personalizado
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Necesita autorizarse para utilizar el servicio",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });

    var filePath = Path.Combine(AppContext.BaseDirectory, "YourApi.xml");
    c.IncludeXmlComments(filePath);
});

//seguridad
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>(); 
builder.Services.AddInMemoryRateLimiting();

builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NETChallengeConnection"));
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AccionService>(); 
builder.Services.AddScoped<AuditoriaService>();
builder.Services.AddScoped<EstadoOrdenDeInversionService>(); 
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<OrdenDeInversionService>(); 
builder.Services.AddScoped<OrdenDeInversionTipoOperacionService>(); 
builder.Services.AddScoped<OrdenDeInversionValidadorService>(); 
builder.Services.AddScoped<TipoDeActivoService>(); 
builder.Services.AddScoped<TipoOperacionAuditoriaService>(); 
builder.Services.AddScoped<TokenUserFilter>();
builder.Services.AddScoped<UsuarioService>(); 
builder.Services.AddScoped<UsuarioValidadorService>();
builder.Services.AddScoped<ValidadorDeNumerosService>();

var jwtKey = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JWT:SecretKey").Value);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ContextDB>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ApiExceptionMiddleware>();
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        var json = JsonConvert.SerializeObject(new AnswerApi
        {
            StatusCode = HttpStatusCode.Unauthorized,
            IsSuccess = false,
            Message = "Necesita autenticarse para utilizar el servicio"
        });
        await context.Response.WriteAsync(json);
    }
});
app.UseAuthentication();
app.UseAuthorization();
app.UseIpRateLimiting();
app.MapControllers();
app.Run();
