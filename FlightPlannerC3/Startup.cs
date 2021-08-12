using FlightPlannerC3.Authentication;
using FlightPlannerC3.Core.Models;
using FlightPlannerC3.Core.Services;
using FlightPlannerC3.Data;
using FlightPlannerC3.Services;
using FlightPlannerC3.Services.Validators;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FlightPlannerC3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<FlightPlannerDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("flight-planner"));
            });
            services.AddTransient<IFlightPlannerDbContext, FlightPlannerDbContext>();
            services.AddTransient<IDbService, DbService>();
            services.AddTransient<IEntityService<Flight>, EntityService<Flight>>();
            services.AddTransient<IEntityService<Airport>, EntityService<Airport>>();
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<IAirportService, AirportService>();
            services.AddTransient<IInputValidator, DatesIntervalInputValidator>();
            services.AddTransient<IInputValidator, DepartureDateInputValidator>();
            services.AddTransient<IInputValidator, ArrivalDateInputValidator>();
            services.AddTransient<IInputValidator, AirportFromInputValidator>();
            services.AddTransient<IInputValidator, AirportToInputValidator>();
            services.AddTransient<IInputValidator, AirportCodesInputValidator>();
            services.AddTransient<IInputValidator, CarrierInputValidator>();
            services.AddTransient<IIsNotInStorageValidator, IsNotInStorageValidator>();
            services.AddTransient<IInputValidator, IsToAndFromAirportsDifferent>();
            services.AddTransient<IAirportService, AirportService>();

            services.AddAuthentication("BasicAuthenticationHandler")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthenticationHandler", null);
            
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
