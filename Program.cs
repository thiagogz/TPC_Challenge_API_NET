using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Repository;
using TPC_Challenge_API_NET.Repository.Interface;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Firebase
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("firebase-credentials.json") // Altere para o caminho correto do arquivo JSON
});

// Adiciona serviços ao container
builder.Services.AddDbContext<DataContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Registra repositórios
builder.Services.AddScoped<ICampanhaRepository, CampanhaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IClusterRepository, ClusterRepository>();
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<ICreditRepository, CreditRepository>();
builder.Services.AddScoped<ICreditCompraRepository, CreditCompraRepository>();
builder.Services.AddScoped<ILojaRepository, LojaRepository>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
builder.Services.AddScoped<IPontoRepository, PontoRepository>();
builder.Services.AddScoped<IPontosCompraRepository, PontosCompraRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserClusterRepository, UserClusterRepository>();
builder.Services.AddScoped<IUsermasterRepository, UsermasterRepository>();
builder.Services.AddScoped<IUserPdvRepository, UserPdvRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// Configuração da Autenticação e Autorização com JWT do Firebase
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/lessoftnet";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/lessoftnet",
            ValidateAudience = true,
            ValidAudience = "lessoftnet",
            ValidateLifetime = true
        };
    });

builder.Services.AddControllers();

// Configuração do Swagger para Autorização JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "LesSoft - A TPC Solution",
        Description = "API desenvolvida pelo grupo Think, Plan & Code para manuseio de dados do aplicativo LesSoft",
        Contact = new OpenApiContact
        {
            Name = "Think, Plan & Code",
            Email = "thinkplancode@gmail.com.br"
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira o token JWT Firebase com Bearer [token]",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar autenticação e autorização
app.UseAuthentication();
app.UseAuthorization(); // Certifique-se de incluir isso!

app.MapControllers();

app.Run();
