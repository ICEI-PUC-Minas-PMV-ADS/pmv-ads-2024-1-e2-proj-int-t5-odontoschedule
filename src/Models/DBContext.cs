using Microsoft.EntityFrameworkCore;

namespace OdontoSchedule.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Dentista> Dentistas { get; set; }

        public DbSet<Atendimento> Atendimentos { get; set; }

        public DbSet<Notificacao> Notificacoes { get; set; }

        public DbSet<Horario> Horarios { get; set; }

        public DbSet<Agenda> Agendas { get; set; }
    }
}
