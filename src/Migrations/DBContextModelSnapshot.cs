﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OdontoSchedule.Models;

#nullable disable

namespace OdontoSchedule.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OdontoSchedule.Models.Agenda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<int>("DentistaId")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<int>("HorarioId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DentistaId");

                    b.HasIndex("HorarioId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("OdontoSchedule.Models.Atendimento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AgendaId")
                        .HasColumnType("int");

                    b.Property<int?>("DentistaId")
                        .HasColumnType("int");

                    b.Property<bool>("Finalizado")
                        .HasColumnType("bit");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<bool>("TemConvenio")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AgendaId")
                        .IsUnique()
                        .HasFilter("[AgendaId] IS NOT NULL");

                    b.HasIndex("DentistaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("OdontoSchedule.Models.Dentista", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("CRO")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("ID");

                    b.ToTable("Dentistas");
                });

            modelBuilder.Entity("OdontoSchedule.Models.Horario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<TimeOnly>("Hora")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("OdontoSchedule.Models.Notificacao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PacienteId");

                    b.ToTable("Notificacoes");
                });

            modelBuilder.Entity("OdontoSchedule.Models.Paciente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("Sexo")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("ID");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("OdontoSchedule.Models.Agenda", b =>
                {
                    b.HasOne("OdontoSchedule.Models.Dentista", "Dentista")
                        .WithMany()
                        .HasForeignKey("DentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OdontoSchedule.Models.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentista");

                    b.Navigation("Horario");
                });

            modelBuilder.Entity("OdontoSchedule.Models.Atendimento", b =>
                {
                    b.HasOne("OdontoSchedule.Models.Agenda", "Agenda")
                        .WithOne()
                        .HasForeignKey("OdontoSchedule.Models.Atendimento", "AgendaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OdontoSchedule.Models.Dentista", "Dentista")
                        .WithMany()
                        .HasForeignKey("DentistaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("OdontoSchedule.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agenda");

                    b.Navigation("Dentista");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("OdontoSchedule.Models.Notificacao", b =>
                {
                    b.HasOne("OdontoSchedule.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
