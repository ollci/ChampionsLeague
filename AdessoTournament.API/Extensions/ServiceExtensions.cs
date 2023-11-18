using AdessoTournamentApplication.APP.Abstract;
using AdessoTournamentApplication.APP.Concrete;
using AdessoTournamentApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace AdessoTournament.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            var migrationAssembly = typeof(AdtDbContext).Namespace;
            services.AddDbContext<AdtDbContext>(options =>
                { options.UseNpgsql(configuration.GetConnectionString("TournamentDatabase"), n => { n.MigrationsAssembly(migrationAssembly); }); });
        }



        public static async Task DbSeeder(this IHost host)
        {
            using (var serviceScope = host.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AdtDbContext>();
                context.Database.Migrate();
            }
        }

        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IGroupTeamService, GroupTeamService>();
        }
    }
}
