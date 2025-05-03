using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class FootballDbContext : IdentityDbContext<User>
{
    public DbSet<Team> FootballTeams { get; set; }
    public DbSet<Player> FootballPlayers { get; set; }
    public DbSet<FavoriteItem> FavoriteItems { get; set; }

    public FootballDbContext() { }
    public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options)
    {
        //this.Database.EnsureDeleted();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            var str = "workstation id=shop-db.mssql.somee.com;packet size=4096;user id=wladnaz_SQLLogin_1;pwd=qsyiy5d3ff;data source=shop-db.mssql.somee.com;persist security info=False;initial catalog=shop-db;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(str);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(x => new { x.LoginProvider, x.ProviderKey });
        
        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasKey(x => new { x.UserId, x.RoleId });
        
        modelBuilder.Entity<IdentityUserToken<string>>()
            .HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
        
        modelBuilder.Entity<FavoriteItem>()
            .HasKey(x => new { x.UserId, x.TeamId });
        
        modelBuilder.Entity<Team>().HasData(
            new Team { Id = 1, Logo = "https://upload.wikimedia.org/wikipedia/en/4/47/FC_Barcelona_%28crest%29.svg", Name = "FC Barcelona", Country = "Spain" },
            new Team { Id = 2, Logo = "https://upload.wikimedia.org/wikipedia/en/5/56/Real_Madrid_CF.svg", Name = "Real Madrid", Country = "Spain" },
            new Team { Id = 3, Logo = "https://upload.wikimedia.org/wikipedia/en/7/7a/Manchester_United_FC_crest.svg", Name = "Manchester United", Country = "England" },
            new Team { Id = 4, Logo = "https://upload.wikimedia.org/wikipedia/en/e/eb/Manchester_City_FC_badge.svg", Name = "Manchester City", Country = "England" },
            new Team { Id = 5, Logo = "https://upload.wikimedia.org/wikipedia/en/0/0c/Liverpool_FC.svg", Name = "Liverpool", Country = "England" },
            new Team { Id = 6, Logo = "https://upload.wikimedia.org/wikipedia/en/a/a7/Paris_Saint-Germain_F.C..svg", Name = "Paris Saint-Germain", Country = "France" },
            new Team { Id = 7, Logo = "https://upload.wikimedia.org/wikipedia/en/c/c5/Bayern_Munich_logo_%282017%29.svg", Name = "Bayern Munich",Country = "Germany" },
            new Team { Id = 8, Logo = "https://upload.wikimedia.org/wikipedia/en/6/67/Borussia_Dortmund_logo.svg", Name = "Borussia Dortmund", Country = "Germany" },
            new Team { Id = 9, Logo = "https://upload.wikimedia.org/wikipedia/en/d/d2/Juventus_FC_2017_logo.svg", Name = "Juventus", Country = "Italy" },
            new Team { Id = 10, Logo = "https://upload.wikimedia.org/wikipedia/en/0/05/Inter_Milan_2021_logo.svg", Name = "Inter Milan", Country = "Italy" },
            new Team { Id = 11, Logo = "https://upload.wikimedia.org/wikipedia/commons/d/d0/Logo_of_AC_Milan.svg", Name = "AC Milan", Country = "Italy" },
            new Team { Id = 12, Logo = "https://upload.wikimedia.org/wikipedia/en/5/53/Arsenal_FC.svg", Name = "Arsenal", Country = "England" },
            new Team { Id = 13, Logo = "https://upload.wikimedia.org/wikipedia/en/c/cc/Chelsea_FC.svg", Name = "Chelsea", Country = "England" },
            new Team { Id = 14, Logo = "https://upload.wikimedia.org/wikipedia/en/f/f4/Atletico_Madrid_2017_logo.svg", Name = "Atletico Madrid", Country = "Spain" },
            new Team { Id = 15, Logo = "https://upload.wikimedia.org/wikipedia/en/2/28/SSC_Napoli.svg", Name = "Napoli", Country = "Italy" },
            new Team { Id = 16, Logo = "https://upload.wikimedia.org/wikipedia/en/0/04/AS_Roma_logo_%282017%29.svg", Name = "AS Roma", Country = "Italy" },
            new Team { Id = 17, Logo = "https://upload.wikimedia.org/wikipedia/en/b/b4/Tottenham_Hotspur.svg", Name = "Tottenham Hotspur", Country = "England" },
            new Team { Id = 18, Logo = "https://upload.wikimedia.org/wikipedia/en/8/86/Sevilla_FC_logo.svg", Name = "Sevilla", Country = "Spain" },
            new Team { Id = 19, Logo = "https://upload.wikimedia.org/wikipedia/en/a/a5/RB_Leipzig_2014_logo.svg", Name = "RB Leipzig", Country = "Germany" },
            new Team { Id = 20, Logo = "https://upload.wikimedia.org/wikipedia/en/7/7f/Ajax_Amsterdam.svg", Name = "Ajax", Country = "Netherlands" }
        );
        
        modelBuilder.Entity<Player>().HasData(
            new Player { Id = 1, FirstName = "Lionel", LastName = "Messi", Goals = 750, Number = 10, Birthdate = new DateTime(1987, 6, 24), TeamId = 6 }, // PSG
            new Player { Id = 2, FirstName = "Cristiano", LastName = "Ronaldo", Goals = 800, Number = 7, Birthdate = new DateTime(1985, 2, 5), TeamId = 9 }, // Juventus
            new Player { Id = 3, FirstName = "Neymar", LastName = "Jr", Goals = 350, Number = 11, Birthdate = new DateTime(1992, 2, 5), TeamId = 6 }, // PSG
            new Player { Id = 4, FirstName = "Kylian", LastName = "Mbappe", Goals = 250, Number = 7, Birthdate = new DateTime(1998, 12, 20), TeamId = 6 }, // PSG
            new Player { Id = 5, FirstName = "Robert", LastName = "Lewandowski", Goals = 500, Number = 9, Birthdate = new DateTime(1988, 8, 21), TeamId = 7 }, // Bayern Munich
            new Player { Id = 6, FirstName = "Kevin", LastName = "De Bruyne", Goals = 150, Number = 17, Birthdate = new DateTime(1991, 6, 28), TeamId = 4 }, // Man City
            new Player { Id = 7, FirstName = "Erling", LastName = "Haaland", Goals = 200, Number = 9, Birthdate = new DateTime(2000, 7, 21), TeamId = 8 }, // Dortmund
            new Player { Id = 8, FirstName = "Mohamed", LastName = "Salah", Goals = 300, Number = 11, Birthdate = new DateTime(1992, 6, 15), TeamId = 5 }, // Liverpool
            new Player { Id = 9, FirstName = "Virgil", LastName = "van Dijk", Goals = 50, Number = 4, Birthdate = new DateTime(1991, 7, 8), TeamId = 5 }, // Liverpool
            new Player { Id = 10, FirstName = "Sergio", LastName = "Ramos", Goals = 100, Number = 4, Birthdate = new DateTime(1986, 3, 30), TeamId = 6 }, // PSG
            new Player { Id = 11, FirstName = "Karim", LastName = "Benzema", Goals = 400, Number = 9, Birthdate = new DateTime(1987, 12, 19), TeamId = 2 }, // Real Madrid
            new Player { Id = 12, FirstName = "Luka", LastName = "Modric", Goals = 120, Number = 10, Birthdate = new DateTime(1985, 9, 9), TeamId = 2 }, // Real Madrid
            new Player { Id = 13, FirstName = "Harry", LastName = "Kane", Goals = 350, Number = 10, Birthdate = new DateTime(1993, 7, 28), TeamId = 17 }, // Tottenham
            new Player { Id = 14, FirstName = "Son", LastName = "Heung-min", Goals = 200, Number = 7, Birthdate = new DateTime(1992, 7, 8), TeamId = 17 }, // Tottenham
            new Player { Id = 15, FirstName = "Bruno", LastName = "Fernandes", Goals = 180, Number = 8, Birthdate = new DateTime(1994, 9, 8), TeamId = 3 }, // Man Utd
            new Player { Id = 16, FirstName = "Marcus", LastName = "Rashford", Goals = 150, Number = 10, Birthdate = new DateTime(1997, 10, 31), TeamId = 3 }, // Man Utd
            new Player { Id = 17, FirstName = "Antoine", LastName = "Griezmann", Goals = 250, Number = 7, Birthdate = new DateTime(1991, 3, 21), TeamId = 14 }, // Atletico Madrid
            new Player { Id = 18, FirstName = "Paulo", LastName = "Dybala", Goals = 150, Number = 21, Birthdate = new DateTime(1993, 11, 15), TeamId = 16 }, // Roma
            new Player { Id = 19, FirstName = "Romelu", LastName = "Lukaku", Goals = 250, Number = 9, Birthdate = new DateTime(1993, 5, 13), TeamId = 10 }, // Inter Milan
            new Player { Id = 20, FirstName = "Joshua", LastName = "Kimmich", Goals = 100, Number = 6, Birthdate = new DateTime(1995, 2, 8), TeamId = 7 }, // Bayern Munich
            new Player { Id = 21, FirstName = "Alphonso", LastName = "Davies", Goals = 50, Number = 19, Birthdate = new DateTime(2000, 11, 2), TeamId = 7 }, // Bayern Munich
            new Player { Id = 22, FirstName = "Jadon", LastName = "Sancho", Goals = 90, Number = 25, Birthdate = new DateTime(2000, 3, 25), TeamId = 3 }, // Man Utd
            new Player { Id = 23, FirstName = "Jack", LastName = "Grealish", Goals = 80, Number = 10, Birthdate = new DateTime(1995, 9, 10), TeamId = 4 }, // Man City
            new Player { Id = 24, FirstName = "Phil", LastName = "Foden", Goals = 100, Number = 47, Birthdate = new DateTime(2000, 5, 28), TeamId = 4 }, // Man City
            new Player { Id = 25, FirstName = "Pedri", LastName = "", Goals = 50, Number = 8, Birthdate = new DateTime(2002, 11, 25), TeamId = 1 }, // Barcelona
            new Player { Id = 26, FirstName = "Gavi", LastName = "", Goals = 40, Number = 30, Birthdate = new DateTime(2004, 8, 5), TeamId = 1 }, // Barcelona
            new Player { Id = 27, FirstName = "Declan", LastName = "Rice", Goals = 60, Number = 41, Birthdate = new DateTime(1999, 1, 14), TeamId = 12 }, // Arsenal
            new Player { Id = 28, FirstName = "Jude", LastName = "Bellingham", Goals = 70, Number = 22, Birthdate = new DateTime(2003, 6, 29), TeamId = 2 }, // Real Madrid
            new Player { Id = 29, FirstName = "Vinicius", LastName = "Jr", Goals = 90, Number = 20, Birthdate = new DateTime(2000, 7, 12), TeamId = 2 }, // Real Madrid
            new Player { Id = 30, FirstName = "Eduardo", LastName = "Camavinga", Goals = 50, Number = 12, Birthdate = new DateTime(2002, 11, 10), TeamId = 2 } // Real Madrid
        );
    }
}