using Hotel_Manegment.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School_Manegment.Data;
using School_Manegment.Data.Interface;
using School_Manegment.Data.Repository;
using School_Manegment.Models;
using School_Manegment.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Services Register Karein
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherEducationRepository, TeacherEducationRepository>();
builder.Services.AddScoped<ITeacherExperienceRepository, TeacherExperienceRepository>();
builder.Services.AddScoped<ITeacherLoginDetailRepository, TeacherLoginDetailRepository>();

builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<SetupService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<EncryptionService>();
builder.Services.AddScoped<TeacherService>();
builder.Services.AddScoped<TeacherEducationSevice>();
builder.Services.AddScoped<TeacherExperienceService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

    // Cookie se JWT Token extract karne ki logic
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("jwtToken"))
            {
                context.Token = context.Request.Cookies["jwtToken"];
            }
            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            // Direct Login Page redirect jab Unauthorized Request aye (401 ke bajaye)
            context.HandleResponse();
            context.Response.Redirect("/Autantication/Login");
            return Task.CompletedTask;
        }
    };
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    await context.Database.MigrateAsync();

    var setupService = scope.ServiceProvider
        .GetRequiredService<SetupService>();

    await setupService.AddLogin();
}


// 2. Middleware Pipeline Configure Karein
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 API");
        // Is line se localhost:port/ par direct Swagger khulega
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// 3. MVC route (MapControllerRoute) ko hata kar MapControllers use karein
app.MapControllers();

app.Run();