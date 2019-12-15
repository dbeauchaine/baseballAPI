using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BaseballAPI.RepositoryModels
{
    public partial class BaseballDBContext : DbContext, IBaseballDBContext
    {
        public BaseballDBContext()
        {
        }

        public BaseballDBContext(DbContextOptions<BaseballDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllstarFull> AllstarFull { get; set; }
        public virtual DbSet<Appearances> Appearances { get; set; }
        public virtual DbSet<AwardsManagers> AwardsManagers { get; set; }
        public virtual DbSet<AwardsPlayers> AwardsPlayers { get; set; }
        public virtual DbSet<AwardsShareManagers> AwardsShareManagers { get; set; }
        public virtual DbSet<AwardsSharePlayers> AwardsSharePlayers { get; set; }
        public virtual DbSet<Batting> Batting { get; set; }
        public virtual DbSet<BattingPost> BattingPost { get; set; }
        public virtual DbSet<CollegePlaying> CollegePlaying { get; set; }
        public virtual DbSet<Fielding> Fielding { get; set; }
        public virtual DbSet<FieldingOf> FieldingOf { get; set; }
        public virtual DbSet<FieldingOfsplit> FieldingOfsplit { get; set; }
        public virtual DbSet<FieldingPost> FieldingPost { get; set; }
        public virtual DbSet<HallOfFame> HallOfFame { get; set; }
        public virtual DbSet<HomeGames> HomeGames { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<ManagersHalf> ManagersHalf { get; set; }
        public virtual DbSet<Parks> Parks { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Pitching> Pitching { get; set; }
        public virtual DbSet<PitchingPost> PitchingPost { get; set; }
        public virtual DbSet<Salaries> Salaries { get; set; }
        public virtual DbSet<Schools> Schools { get; set; }
        public virtual DbSet<SeriesPost> SeriesPost { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<TeamsFranchises> TeamsFranchises { get; set; }
        public virtual DbSet<TeamsHalf> TeamsHalf { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BaseballDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllstarFull>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.GameNum })
                    .HasName("AllstarFull$Index_2BD68208_C8B4_4347");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.GameNum).HasColumnName("gameNum");

                entity.Property(e => e.GameId)
                    .HasColumnName("gameID")
                    .HasMaxLength(12);

                entity.Property(e => e.Gp).HasColumnName("GP");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.StartingPos).HasColumnName("startingPos");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Appearances>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.TeamId, e.PlayerId })
                    .HasName("Appearances$Index_70924BF9_C76C_4076");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.G1b).HasColumnName("G_1b");

                entity.Property(e => e.G2b).HasColumnName("G_2b");

                entity.Property(e => e.G3b).HasColumnName("G_3b");

                entity.Property(e => e.GAll).HasColumnName("G_all");

                entity.Property(e => e.GBatting).HasColumnName("G_batting");

                entity.Property(e => e.GC).HasColumnName("G_c");

                entity.Property(e => e.GCf).HasColumnName("G_cf");

                entity.Property(e => e.GDefense).HasColumnName("G_defense");

                entity.Property(e => e.GDh).HasColumnName("G_dh");

                entity.Property(e => e.GLf).HasColumnName("G_lf");

                entity.Property(e => e.GOf).HasColumnName("G_of");

                entity.Property(e => e.GP).HasColumnName("G_p");

                entity.Property(e => e.GPh).HasColumnName("G_ph");

                entity.Property(e => e.GPr).HasColumnName("G_pr");

                entity.Property(e => e.GRf).HasColumnName("G_rf");

                entity.Property(e => e.GSs).HasColumnName("G_ss");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<AwardsManagers>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.AwardId, e.LgId, e.PlayerId })
                    .HasName("AwardsManagers$Index_5B79AD08_A7C1_426E");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.AwardId)
                    .HasColumnName("awardID")
                    .HasMaxLength(75);

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(10);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(100);

                entity.Property(e => e.Tie)
                    .HasColumnName("tie")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<AwardsPlayers>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.AwardId, e.LgId, e.PlayerId })
                    .HasName("AwardsPlayers$Index_99C7A5A6_27CA_44FC");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.AwardId)
                    .HasColumnName("awardID")
                    .HasMaxLength(255);

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(100);

                entity.Property(e => e.Tie)
                    .HasColumnName("tie")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<AwardsShareManagers>(entity =>
            {
                entity.HasKey(e => new { e.AwardId, e.YearId, e.LgId, e.PlayerId })
                    .HasName("AwardsShareManagers$Index_4D947987_0BEF_4B9B");

                entity.Property(e => e.AwardId)
                    .HasColumnName("awardID")
                    .HasMaxLength(25);

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(10);

                entity.Property(e => e.PointsMax).HasColumnName("pointsMax");

                entity.Property(e => e.PointsWon).HasColumnName("pointsWon");

                entity.Property(e => e.VotesFirst).HasColumnName("votesFirst");
            });

            modelBuilder.Entity<AwardsSharePlayers>(entity =>
            {
                entity.HasKey(e => new { e.AwardId, e.YearId, e.LgId, e.PlayerId })
                    .HasName("AwardsSharePlayers$Index_020E6DB1_95E2_44F1");

                entity.Property(e => e.AwardId)
                    .HasColumnName("awardID")
                    .HasMaxLength(25);

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.PointsMax).HasColumnName("pointsMax");

                entity.Property(e => e.PointsWon).HasColumnName("pointsWon");

                entity.Property(e => e.VotesFirst).HasColumnName("votesFirst");
            });

            modelBuilder.Entity<Batting>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint })
                    .HasName("Batting$Index_7170BE9D_268A_46B8");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.HasOne(e => e.Player)
                    .WithMany()
                    .HasForeignKey(e => e.PlayerId);

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");

                entity.Property(e => e.Ab).HasColumnName("AB");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.GBatting).HasColumnName("G_batting");

                entity.Property(e => e.Gidp).HasColumnName("GIDP");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Ibb).HasColumnName("IBB");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.Rbi).HasColumnName("RBI");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sh).HasColumnName("SH");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.X2b).HasColumnName("2B");

                entity.Property(e => e.X3b).HasColumnName("3B");
            });
                

            modelBuilder.Entity<BattingPost>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.Round, e.PlayerId })
                    .HasName("BattingPost$Index_8C81D106_6E96_4318");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Round)
                    .HasColumnName("round")
                    .HasMaxLength(10);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.Ab).HasColumnName("AB");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.Gidp).HasColumnName("GIDP");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Ibb).HasColumnName("IBB");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.Rbi).HasColumnName("RBI");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sh).HasColumnName("SH");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e._2b).HasColumnName("2B");

                entity.Property(e => e._3b).HasColumnName("3B");
            });

            modelBuilder.Entity<CollegePlaying>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PlayerId)
                    .IsRequired()
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.SchoolId)
                    .HasColumnName("schoolID")
                    .HasMaxLength(15);

                entity.Property(e => e.YearId).HasColumnName("yearID");
            });

            modelBuilder.Entity<Fielding>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint, e.Pos })
                    .HasName("Fielding$Index_97751AED_0076_4367");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");

                entity.Property(e => e.Pos)
                    .HasColumnName("POS")
                    .HasMaxLength(2);

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.Dp).HasColumnName("DP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.Pb).HasColumnName("PB");

                entity.Property(e => e.Po).HasColumnName("PO");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.Wp).HasColumnName("WP");

                entity.Property(e => e.Zr).HasColumnName("ZR");
            });

            modelBuilder.Entity<FieldingOf>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint })
                    .HasName("FieldingOF$Index_8983CB74_6371_424E");

                entity.ToTable("FieldingOF");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");
            });

            modelBuilder.Entity<FieldingOfsplit>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint, e.Pos })
                    .HasName("FieldingOFsplit$Index_97751AED_0076_4367");

                entity.ToTable("FieldingOFsplit");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");

                entity.Property(e => e.Pos)
                    .HasColumnName("POS")
                    .HasMaxLength(2);

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.Dp).HasColumnName("DP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.Pb).HasColumnName("PB");

                entity.Property(e => e.Po).HasColumnName("PO");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.Wp).HasColumnName("WP");

                entity.Property(e => e.Zr).HasColumnName("ZR");
            });

            modelBuilder.Entity<FieldingPost>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Round, e.Pos })
                    .HasName("FieldingPost$Index_E1DA201A_3B38_486D");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Round)
                    .HasColumnName("round")
                    .HasMaxLength(10);

                entity.Property(e => e.Pos)
                    .HasColumnName("POS")
                    .HasMaxLength(2);

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.Dp).HasColumnName("DP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.Pb).HasColumnName("PB");

                entity.Property(e => e.Po).HasColumnName("PO");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.Tp).HasColumnName("TP");
            });

            modelBuilder.Entity<HallOfFame>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.Yearid, e.VotedBy })
                    .HasName("HallOfFame$PrimaryKey");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(10);

                entity.Property(e => e.Yearid).HasColumnName("yearid");

                entity.Property(e => e.VotedBy)
                    .HasColumnName("votedBy")
                    .HasMaxLength(64);

                entity.Property(e => e.Ballots).HasColumnName("ballots");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(20);

                entity.Property(e => e.Inducted)
                    .HasColumnName("inducted")
                    .HasMaxLength(1);

                entity.Property(e => e.Needed).HasColumnName("needed");

                entity.Property(e => e.NeededNote)
                    .HasColumnName("needed_note")
                    .HasMaxLength(25);

                entity.Property(e => e.Votes).HasColumnName("votes");
            });

            modelBuilder.Entity<HomeGames>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.Games).HasColumnName("games");

                entity.Property(e => e.Leaguekey)
                    .HasColumnName("leaguekey")
                    .HasMaxLength(255);

                entity.Property(e => e.Openings).HasColumnName("openings");

                entity.Property(e => e.Parkkey)
                    .HasColumnName("parkkey")
                    .HasMaxLength(255);

                entity.Property(e => e.Spanfirst)
                    .HasColumnName("spanfirst")
                    .HasMaxLength(255);

                entity.Property(e => e.Spanlast)
                    .HasColumnName("spanlast")
                    .HasMaxLength(255);

                entity.Property(e => e.Teamkey)
                    .HasColumnName("teamkey")
                    .HasMaxLength(255);

                entity.Property(e => e.Yearkey).HasColumnName("yearkey");
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.TeamId, e.Inseason })
                    .HasName("Managers$Index_836DE8E8_FEBD_469A");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.Inseason).HasColumnName("inseason");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(10);

                entity.Property(e => e.PlyrMgr)
                    .HasColumnName("plyrMgr")
                    .HasMaxLength(1);

                entity.Property(e => e.Rank).HasColumnName("rank");
            });

            modelBuilder.Entity<ManagersHalf>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.TeamId, e.PlayerId, e.Half })
                    .HasName("ManagersHalf$Index_C2906EEF_9F52_4968");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(10);

                entity.Property(e => e.Half).HasColumnName("half");

                entity.Property(e => e.Inseason).HasColumnName("inseason");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.Rank).HasColumnName("rank");
            });

            modelBuilder.Entity<Parks>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(255);

                entity.Property(e => e.Parkalias)
                    .HasColumnName("parkalias")
                    .HasMaxLength(255);

                entity.Property(e => e.Parkkey)
                    .HasColumnName("parkkey")
                    .HasMaxLength(255);

                entity.Property(e => e.Parkname)
                    .HasColumnName("parkname")
                    .HasMaxLength(255);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId });

                entity.Property(e => e.Bats)
                    .HasColumnName("bats")
                    .HasMaxLength(255);

                entity.Property(e => e.BbrefId)
                    .HasColumnName("bbrefID")
                    .HasMaxLength(255);

                entity.Property(e => e.BirthCity)
                    .HasColumnName("birthCity")
                    .HasMaxLength(255);

                entity.Property(e => e.BirthCountry)
                    .HasColumnName("birthCountry")
                    .HasMaxLength(255);

                entity.Property(e => e.BirthDay).HasColumnName("birthDay");

                entity.Property(e => e.BirthMonth).HasColumnName("birthMonth");

                entity.Property(e => e.BirthState)
                    .HasColumnName("birthState")
                    .HasMaxLength(255);

                entity.Property(e => e.BirthYear).HasColumnName("birthYear");

                entity.Property(e => e.DeathCity)
                    .HasColumnName("deathCity")
                    .HasMaxLength(255);

                entity.Property(e => e.DeathCountry)
                    .HasColumnName("deathCountry")
                    .HasMaxLength(255);

                entity.Property(e => e.DeathDay).HasColumnName("deathDay");

                entity.Property(e => e.DeathMonth).HasColumnName("deathMonth");

                entity.Property(e => e.DeathState)
                    .HasColumnName("deathState")
                    .HasMaxLength(255);

                entity.Property(e => e.DeathYear).HasColumnName("deathYear");

                entity.Property(e => e.Debut)
                    .HasColumnName("debut")
                    .HasMaxLength(255);

                entity.Property(e => e.FinalGame)
                    .HasColumnName("finalGame")
                    .HasMaxLength(255);

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.NameFirst)
                    .HasColumnName("nameFirst")
                    .HasMaxLength(255);

                entity.Property(e => e.NameGiven)
                    .HasColumnName("nameGiven")
                    .HasMaxLength(255);

                entity.Property(e => e.NameLast)
                    .HasColumnName("nameLast")
                    .HasMaxLength(255);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(255);

                entity.Property(e => e.RetroId)
                    .HasColumnName("retroID")
                    .HasMaxLength(255);

                entity.Property(e => e.Throws)
                    .HasColumnName("throws")
                    .HasMaxLength(255);

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Pitching>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint })
                    .HasName("Pitching$Index_481778A5_18F2_430E");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");

                entity.Property(e => e.Baopp).HasColumnName("BAOpp");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Bfp).HasColumnName("BFP");

                entity.Property(e => e.Bk).HasColumnName("BK");

                entity.Property(e => e.Cg).HasColumnName("CG");

                entity.Property(e => e.Er).HasColumnName("ER");

                entity.Property(e => e.Era).HasColumnName("ERA");

                entity.Property(e => e.Gf).HasColumnName("GF");

                entity.Property(e => e.Gidp).HasColumnName("GIDP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Ibb).HasColumnName("IBB");

                entity.Property(e => e.Ipouts).HasColumnName("IPouts");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sh).HasColumnName("SH");

                entity.Property(e => e.Sho).HasColumnName("SHO");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.Sv).HasColumnName("SV");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.Wp).HasColumnName("WP");
            });

            modelBuilder.Entity<PitchingPost>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Round })
                    .HasName("PitchingPost$Index_E71336E6_AB00_432C");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Round)
                    .HasColumnName("round")
                    .HasMaxLength(10);

                entity.Property(e => e.Baopp).HasColumnName("BAOpp");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Bfp).HasColumnName("BFP");

                entity.Property(e => e.Bk).HasColumnName("BK");

                entity.Property(e => e.Cg).HasColumnName("CG");

                entity.Property(e => e.Er).HasColumnName("ER");

                entity.Property(e => e.Era).HasColumnName("ERA");

                entity.Property(e => e.Gf).HasColumnName("GF");

                entity.Property(e => e.Gidp).HasColumnName("GIDP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Ibb).HasColumnName("IBB");

                entity.Property(e => e.Ipouts).HasColumnName("IPouts");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sh).HasColumnName("SH");

                entity.Property(e => e.Sho).HasColumnName("SHO");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.Sv).HasColumnName("SV");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.Wp).HasColumnName("WP");
            });

            modelBuilder.Entity<Salaries>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.TeamId, e.LgId, e.PlayerId })
                    .HasName("Salaries$Index_E5568031_00FA_49CA");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(9);

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Schools>(entity =>
            {
                entity.HasKey(e => e.SchoolId)
                    .HasName("Schools$Index_3D308CF0_821E_4DAB");

                entity.Property(e => e.SchoolId)
                    .HasColumnName("schoolID")
                    .HasMaxLength(15);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(55);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(55);

                entity.Property(e => e.NameFull)
                    .HasColumnName("name_full")
                    .HasMaxLength(255);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(55);
            });

            modelBuilder.Entity<SeriesPost>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.Round })
                    .HasName("SeriesPost$Index_4F4214D5_9891_4F3C");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Round)
                    .HasColumnName("round")
                    .HasMaxLength(5);

                entity.Property(e => e.LgIdloser)
                    .HasColumnName("lgIDloser")
                    .HasMaxLength(2);

                entity.Property(e => e.LgIdwinner)
                    .HasColumnName("lgIDwinner")
                    .HasMaxLength(2);

                entity.Property(e => e.Losses).HasColumnName("losses");

                entity.Property(e => e.TeamIdloser)
                    .HasColumnName("teamIDloser")
                    .HasMaxLength(3);

                entity.Property(e => e.TeamIdwinner)
                    .HasColumnName("teamIDwinner")
                    .HasMaxLength(3);

                entity.Property(e => e.Ties).HasColumnName("ties");

                entity.Property(e => e.Wins).HasColumnName("wins");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.LgId, e.TeamId })
                    .HasName("Teams$Index_285058F1_D841_4142");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.Ab).HasColumnName("AB");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Bba).HasColumnName("BBA");

                entity.Property(e => e.Bpf).HasColumnName("BPF");

                entity.Property(e => e.Cg).HasColumnName("CG");

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.DivId)
                    .HasColumnName("divID")
                    .HasMaxLength(1);

                entity.Property(e => e.DivWin).HasMaxLength(1);

                entity.Property(e => e.Dp).HasColumnName("DP");

                entity.Property(e => e.Er).HasColumnName("ER");

                entity.Property(e => e.Era).HasColumnName("ERA");

                entity.Property(e => e.Fp).HasColumnName("FP");

                entity.Property(e => e.FranchId)
                    .HasColumnName("franchID")
                    .HasMaxLength(3);

                entity.Property(e => e.Ha).HasColumnName("HA");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Hra).HasColumnName("HRA");

                entity.Property(e => e.Ipouts).HasColumnName("IPouts");

                entity.Property(e => e.LgWin).HasMaxLength(1);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Park)
                    .HasColumnName("park")
                    .HasMaxLength(255);

                entity.Property(e => e.Ppf).HasColumnName("PPF");

                entity.Property(e => e.Ra).HasColumnName("RA");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sho).HasColumnName("SHO");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.Soa).HasColumnName("SOA");

                entity.Property(e => e.Sv).HasColumnName("SV");

                entity.Property(e => e.TeamIdbr)
                    .HasColumnName("teamIDBR")
                    .HasMaxLength(3);

                entity.Property(e => e.TeamIdlahman45)
                    .HasColumnName("teamIDlahman45")
                    .HasMaxLength(3);

                entity.Property(e => e.TeamIdretro)
                    .HasColumnName("teamIDretro")
                    .HasMaxLength(3);

                entity.Property(e => e.Wcwin)
                    .HasColumnName("WCWin")
                    .HasMaxLength(1);

                entity.Property(e => e.Wswin)
                    .HasColumnName("WSWin")
                    .HasMaxLength(1);

                entity.Property(e => e._2b).HasColumnName("2B");

                entity.Property(e => e._3b).HasColumnName("3B");
            });

            modelBuilder.Entity<TeamsFranchises>(entity =>
            {
                entity.HasKey(e => e.FranchId)
                    .HasName("TeamsFranchises$Index_D181F923_2BF9_4281");

                entity.Property(e => e.FranchId)
                    .HasColumnName("franchID")
                    .HasMaxLength(3);

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(2);

                entity.Property(e => e.FranchName)
                    .HasColumnName("franchName")
                    .HasMaxLength(50);

                entity.Property(e => e.Naassoc)
                    .HasColumnName("NAassoc")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<TeamsHalf>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.TeamId, e.LgId, e.Half })
                    .HasName("TeamsHalf$Index_3FD773F5_2FC0_415C");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.TeamId)
                    .HasColumnName("teamID")
                    .HasMaxLength(3);

                entity.Property(e => e.LgId)
                    .HasColumnName("lgID")
                    .HasMaxLength(2);

                entity.Property(e => e.Half).HasMaxLength(1);

                entity.Property(e => e.DivId)
                    .HasColumnName("divID")
                    .HasMaxLength(1);

                entity.Property(e => e.DivWin).HasMaxLength(1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
