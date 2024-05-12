using Microsoft.EntityFrameworkCore;

namespace OdontoSchedule.Models
{
    public class DBInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DBInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Horario>().HasData(
                new Horario { ID = 1, Hora = new TimeOnly(8, 0) },
                new Horario { ID = 2, Hora = new TimeOnly(8, 30) },
                new Horario { ID = 3, Hora = new TimeOnly(9, 0) },
                new Horario { ID = 4, Hora = new TimeOnly(9, 30) },
                new Horario { ID = 5, Hora = new TimeOnly(10, 0) },
                new Horario { ID = 6, Hora = new TimeOnly(10, 30) },
                new Horario { ID = 7, Hora = new TimeOnly(11, 0) },
                new Horario { ID = 8, Hora = new TimeOnly(11, 30) },
                new Horario { ID = 9, Hora = new TimeOnly(12, 0) },
                new Horario { ID = 10, Hora = new TimeOnly(12, 30) },
                new Horario { ID = 11, Hora = new TimeOnly(13, 0) },
                new Horario { ID = 12, Hora = new TimeOnly(13, 30) },
                new Horario { ID = 13, Hora = new TimeOnly(14, 0) },
                new Horario { ID = 14, Hora = new TimeOnly(14, 30) },
                new Horario { ID = 15, Hora = new TimeOnly(15, 0) },
                new Horario { ID = 16, Hora = new TimeOnly(15, 30) },
                new Horario { ID = 17, Hora = new TimeOnly(16, 0) },
                new Horario { ID = 18, Hora = new TimeOnly(16, 30) },
                new Horario { ID = 19, Hora = new TimeOnly(17, 0) }
            );
        }
    }
}
