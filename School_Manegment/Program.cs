using Hotel_Manegment.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using School_Manegment.Data;
using School_Manegment.Data.Interface;
using School_Manegment.Data.Repository;
using School_Manegment.Models;
using School_Manegment.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:30000", "http://localhost:5174", "http://localhost:5173", "http://localhost:30001")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Conn")
    ));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherEducationRepository, TeacherEducationRepository>();
builder.Services.AddScoped<ITeacherExperienceRepository, TeacherExperienceRepository>();
builder.Services.AddScoped<ITeacherLoginDetailRepository, TeacherLoginDetailRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISCH_ClassSectionRepository, SCH_ClassSectionRepository>();
builder.Services.AddScoped<ISCH_ClassRepository, SCH_ClassRepository>();
builder.Services.AddScoped<IStudentClassRepository, StudentClassRepository>();
builder.Services.AddScoped<ISys_DetailRepository, Sys_DetailRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
// 1. Generic Repository ko register karna (Open Generics)

// 2. Unit of Work ko register karna



builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<SetupService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<EncryptionService>();
builder.Services.AddScoped<TeacherService>();
builder.Services.AddScoped<TeacherEducationSevice>();
builder.Services.AddScoped<TeacherExperienceService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<ISCH_ClassSectionService>();
builder.Services.AddScoped<Sys_DetailService>();
builder.Services.AddScoped(typeof(GenericService<>), typeof(GenericService<>));


builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(options =>
{
    // JWT Bearer definition
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token"
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
            Array.Empty<string>()
        }
    });
});



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
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

        IssuerSigningKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:Key"]
                )
            )
    };


    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("jwtToken"))
            {
                context.Token =
                    context.Request.Cookies["jwtToken"];
            }

            return Task.CompletedTask;
        },


        OnChallenge = context =>
        {
            context.HandleResponse();

            context.Response.Redirect(
                "/Autantication/Login"
            );

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "V1 API"
        );

        // Swagger directly opens on localhost
        c.RoutePrefix = string.Empty;
    });
}
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();