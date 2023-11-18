using AdessoTournamentApplication.APP.Abstract;
using AdessoTournamentApplication.Data;
using AdessoTournamentApplication.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoTournamentApplication.APP.Concrete
{
    public class GroupTeamService : IGroupTeamService
    {
        private readonly AdtDbContext _context;

        public GroupTeamService(AdtDbContext context)
        {
            _context = context;
        }
        public void CreateGroups(int numberOfGroups, int teamsPerGroup)
        {
            var countries = _context.Countries.ToList();
            var groups = _context.Groups.ToList();
            var teams = _context.Teams.ToList();

            if (countries.Count == 0)
            {
                Console.WriteLine("Veritabanında ülkeler bulunamadı.");
                return;
            }

            if (groups.Count == 0)
            {
                Console.WriteLine("Veritabanında gruplar bulunamadı.");
                return;
            }

            if (teams.Count == 0)
            {
                Console.WriteLine("Veritabanında takımlar bulunamadı.");
                return;
            }

            if (numberOfGroups > groups.Count)
            {
                Console.WriteLine("Grup sayısı, belirlenen grup sayısından az olduğu için işlem gerçekleştirilemiyor.");
                return;
            }

            // Ülkeleri rastgele sırayla al
            var shuffledCountries = countries.OrderBy(x => Guid.NewGuid()).ToList();

            // Belirli sayıda grup oluştur
            for (int i = 0; i < numberOfGroups; i++)
            {
                var group = groups[i];

                // Belirli sayıda takım oluştur
                for (int j = 0; j < teamsPerGroup; j++)
                {
                    var countryIndex = (i * teamsPerGroup + j) % countries.Count; // Farklı ülkeleri sağlamak için indeks hesapla
                    var selectedCountry = shuffledCountries[countryIndex];

                    // Veritabanındaki takımları ve grupları çek
                    var team = teams.FirstOrDefault(t => t.CountryId == selectedCountry.CountryId);
                    if (team == null)
                    {
                        Console.WriteLine($"Ülkeden uygun takım bulunamadı: {selectedCountry.Name}");
                        continue;
                    }

                    // Oluşturulan takımı gruba ekle
                    var groupTeam = new GroupTeam
                    {
                        Group = group,
                        Team = team
                    };

                    _context.GroupTeams.Add(groupTeam);
                }
            }

            _context.SaveChanges();
        }
        public void Create8Groups(int numberOfGroups, int teamsPerGroup)
        {
            var countries = _context.Countries.ToList();
            var groups = _context.Groups.ToList();

            if (countries.Count == 0)
            {
                Console.WriteLine("Veritabanında ülkeler bulunamadı.");
                return;
            }

            if (groups.Count == 0)
            {
                Console.WriteLine("Veritabanında gruplar bulunamadı.");
                return;
            }

            if (numberOfGroups > groups.Count)
            {
                Console.WriteLine("Grup sayısı, belirlenen grup sayısından az olduğu için işlem gerçekleştirilemiyor.");
                return;
            }

            if (teamsPerGroup > countries.Count)
            {
                Console.WriteLine("Her grupta farklı ülkelerden takım oluşturmak için yeterli sayıda ülke bulunmamaktadır.");
                return;
            }

            // Her grupta 8 farklı ülke kullanarak takımları oluştur
            for (int i = 0; i < numberOfGroups; i++)
            {
                var group = groups[i];

                // Belirli sayıda takım oluştur
                for (int j = 0; j < teamsPerGroup; j++)
                {
                    // Farklı ülkeleri sağlamak için indeks hesapla
                    var countryIndex = (i * teamsPerGroup + j) % countries.Count;
                    var selectedCountry = countries[countryIndex];

                    // Veritabanında seçilen ülkeden uygun takımı çek
                    var team = _context.Teams.FirstOrDefault(t => t.CountryId == selectedCountry.CountryId);

                    if (team == null)
                    {
                        Console.WriteLine($"Ülkeden uygun takım bulunamadı: {selectedCountry.Name}");
                        continue;
                    }

                    // Oluşturulan takımı gruba ekle
                    var groupTeam = new GroupTeam
                    {
                        Group = group,
                        Team = team
                    };

                    _context.GroupTeams.Add(groupTeam);
                }
            }

            _context.SaveChanges();
        }

    }
}
