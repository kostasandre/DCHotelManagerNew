// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="">
//   
// </copyright>
// <summary>
//   The startup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Web.Api
{
    #region

    using DCHotelManagerCore.Lib.DbContext;
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    #endregion

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">
        /// The env.
        /// </param>
        public Startup(IHostingEnvironment env)
        {
            var builder =
                new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfigurationRoot Configuration { get; }
        
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        /// <param name="loggerFactory">
        /// The logger factory.
        /// </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<DataBaseContext>();            
            services.AddApplicationInsightsTelemetry(this.Configuration);
            services.AddTransient<IEntityRepository<Hotel>, HotelRepository>();
            services.AddTransient<IEntityRepository<Room>, RoomRepository>();
            services.AddTransient<IEntityRepository<RoomType>, RoomTypeRepository>();
            services.AddTransient<IEntityRepository<Customer>, CustomerRepository>();
            services.AddTransient<IEntityRepository<Picture>, PictureRepository>();

            // Add framework services.
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }
    }
}