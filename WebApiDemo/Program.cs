using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using WebApiDemo.Abstractions.Context;
using WebApiDemo.Persistence;
using WebApiDemo.Swagger;

namespace WebApiDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Host.ConfigureAppConfiguration((con) =>
            //{
            //    con.AddJsonFile("appsettings.local.json", optional: true);
            //});

            // Add services to the container.

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(connectionString, providerOptions =>
            //    {
            //        providerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            //    });
            //});


            #region Swagger
            builder.Services.AddSwaggerGen(c =>
            {


                c.OperationFilter<DefaultResponseOperationFilter>();
                c.OperationFilter<AuthResponseOperationFilter>();


                //c.IncludeXmlComments(string.Format(@"{0}\WebAPIOnionArchitecture.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WebAPIOnionArchitecture",
                });

                //c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Insert JWT token with the \"Bearer \" prefix",
                //    Name = HeaderNames.Authorization,
                //    Type = SecuritySchemeType.ApiKey
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = JwtBearerDefaults.AuthenticationScheme
                //            }
                //        },
                //        Array.Empty<string>()
                //    }
                //});

                c.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date-time",
                    Example = new OpenApiString(new DateTime(2022, 04, 08, 16, 22, 0).ToString("yyyy-MM-ddTHH:mm:ssZ"))
                });

                c.UseAllOfToExtendReferenceSchemas();

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            { 

                #region Swagger
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();
                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {

                    c.InjectStylesheet("/Resources/themes/3.x/theme-material.css");
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIOnionArchitecture");
                });
                #endregion

            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                // TODO: create if not exist
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}