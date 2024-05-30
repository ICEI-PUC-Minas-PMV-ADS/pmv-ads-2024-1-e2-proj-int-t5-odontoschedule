using Microsoft.EntityFrameworkCore;

namespace OdontoSchedule.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atendimento>().HasOne(a => a.Paciente).WithMany().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Atendimento>().HasOne(a => a.Dentista).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Atendimento>().HasOne(a => a.Agenda).WithOne().OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Agenda>().HasOne(a => a.Dentista).WithMany().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Agenda>().HasOne(a => a.Horario).WithMany().OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Paciente>().HasIndex(p => p.CPF).IsUnique(true);
            modelBuilder.Entity<Paciente>().HasIndex(p => p.Email).IsUnique(true);

            modelBuilder.Entity<Dentista>().HasIndex(d => d.CPF).IsUnique(true);
            modelBuilder.Entity<Dentista>().HasIndex(d => d.CRO).IsUnique(true);

            new DBInitializer(modelBuilder).Seed();
        }

        public DbSet<Paciente> Pacientes { get; set; }
        
        public DbSet<Recoverycode> RecoveryCodes { get; set; }

        public DbSet<Dentista> Dentistas { get; set; }

        public DbSet<Atendimento> Atendimentos { get; set; }

        public DbSet<Notificacao> Notificacoes { get; set; }

        public DbSet<Horario> Horarios { get; set; }

        public DbSet<Agenda> Agendas { get; set; }
    }
}
