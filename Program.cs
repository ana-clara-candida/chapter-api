using Chapter.WebApi.Contexts;
using Chapter.WebApi.Interfaces;
using Chapter.WebApi.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Chapter.WebApi" });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";

}).AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chapter-chave-autenticacao")),
        ClockSkew = TimeSpan.FromMinutes(60),
        ValidIssuer = "chapter.webApi",
        ValidAudience = "chapter.webApi"
       
    };
});


builder.Services.AddScoped<ChapterContext, ChapterContext>();
builder.Services.AddTransient<LivroRepository, LivroRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chapter.WebApi");
    c.RoutePrefix = String.Empty;
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    app.MapControllers();
});

app.Run();

