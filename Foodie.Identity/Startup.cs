//using Foode.Identity.Infrastructure;
//using Foodie.Common.Api.Middlewares;
//using Foodie.Common.Api.Settings;
//using Foodie.Common.Application.Behaviours;
//using Foodie.Common.Infrastructure.Authentication;
//using Foodie.Common.Infrastructure.Hangfire;
//using Foodie.Emails;
//using Foodie.Identity.API.Grpc;
//using Foodie.Identity.Application;
//using Foodie.Shared.Behaviours;
//using MediatR;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.OpenApi.Models;

//namespace Foodie.Identity
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddIdentityApplication();
//            services.AddIdentityInfrastructure(Configuration);
//            services.ConfigureApplicationSettings(Configuration, SettingsType.JwtToken, SettingsType.Smtp);
//            services.AddJwtAuthentication(Configuration);
//            services.AddEmails();
//            services.AddHangfire(Configuration);

//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuditableBehaviour<,>));
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ApplicationUserLocationBehaviour<,>));
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ApplicationUserIdBehaviour<,>));

//            services.AddControllers();
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Foodie.Identity", Version = "v1" });
//            });



//            services.AddAutoMapper(typeof(Startup));
//            services.AddGrpc();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseSwagger();
//                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foodie.Identity v1"));
//            }

//            app.UseMiddleware<ExceptionMiddleware>();

//            app.UseHttpsRedirection();

//            app.UseRouting();

//            app.UseAuthentication();
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapGrpcService<IdentityGrpcService>();
//                endpoints.MapControllers();
//            });
//        }
//    }
//}
