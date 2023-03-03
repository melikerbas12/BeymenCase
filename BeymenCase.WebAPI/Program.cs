using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BeymenCase.Data.Context;
using BeymenCase.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration);
#region Swagger Settings
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SAHABT.Retro.WebApi", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // must be lower case
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
                    {securityScheme, new string[] { }}
    });
});
#endregion

#region Db Connection
builder.Services.AddDbContext<BeymenCaseDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));
var app = builder.Build();
using var scope = app.Services.CreateAsyncScope();
var beymenCaseDbContext = scope.ServiceProvider.GetRequiredService<BeymenCaseDbContext>();
beymenCaseDbContext.Database.MigrateAsync();
#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BeymenCase.Retro.WebApi v1"));
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
