using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public partial class NaselenieDbContext : DbContext
{
    public NaselenieDbContext()
    {
    }

    public NaselenieDbContext(DbContextOptions<NaselenieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocumentPredostavlaushiyLgotu> DocumentPredostavlaushiyLgotu { get; set; }

    public virtual DbSet<DokumentUdostoveraushiyLichnost> DokumentUdostoveraushiyLichnost { get; set; }

    public virtual DbSet<ObshieSvedenya> ObshieSvedenya { get; set; }

    public virtual DbSet<SocialnoePolojenie> SocialnoePolojenie { get; set; }

    public virtual DbSet<Uslugi> Uslugi { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocumentPredostavlaushiyLgotu>(entity =>
        {
            entity.HasKey(e => e.КодДокументаПредоставляющегоЛьготу);

            entity.ToTable("Документ предоставляющий льготу");

            entity.Property(e => e.КодДокументаПредоставляющегоЛьготу)
                .ValueGeneratedNever()
                .HasColumnName("Код документа предоставляющего льготу");
            entity.Property(e => e.ДатаВыдачи).HasColumnName("Дата выдачи");
            entity.Property(e => e.ДатаОкончанияСрокаДействия).HasColumnName("Дата окончания срока действия");
            entity.Property(e => e.Номер).HasMaxLength(50);
            entity.Property(e => e.Серия).HasMaxLength(50);
            entity.Property(e => e.ТипДокумента)
                .HasMaxLength(50)
                .HasColumnName("Тип документа");
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("ФИО");

            entity.HasOne(d => d.КодДокументаПредоставляющегоЛьготуNavigation).WithOne(p => p.ДокументПредоставляющийЛьготу)
                .HasForeignKey<DocumentPredostavlaushiyLgotu>(d => d.КодДокументаПредоставляющегоЛьготу)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Документ предоставляющий льготу_Общие сведения");
        });

        modelBuilder.Entity<DokumentUdostoveraushiyLichnost>(entity =>
        {
            entity.HasKey(e => e.КодДокументаУдостоверяющегоЛичность);

            entity.ToTable("Документ удостоверяющий личность");

            entity.Property(e => e.КодДокументаУдостоверяющегоЛичность)
                .ValueGeneratedNever()
                .HasColumnName("Код документа удостоверяющего личность");
            entity.Property(e => e.ДатаВыдачи).HasColumnName("Дата выдачи");
            entity.Property(e => e.ДатаОкончанияСрокаДействия).HasColumnName("Дата окончания срока действия");
            entity.Property(e => e.КемВыдан)
                .HasMaxLength(50)
                .HasColumnName("Кем выдан");
            entity.Property(e => e.Номер).HasMaxLength(50);
            entity.Property(e => e.Серия).HasMaxLength(50);
            entity.Property(e => e.ТипДокумента)
                .HasMaxLength(50)
                .HasColumnName("Тип документа");
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("ФИО");

            entity.HasOne(d => d.КодДокументаУдостоверяющегоЛичностьNavigation).WithOne(p => p.ДокументУдостоверяющийЛичность)
                .HasForeignKey<DokumentUdostoveraushiyLichnost>(d => d.КодДокументаУдостоверяющегоЛичность)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Документ удостоверяющий личность_Общие сведения");
        });

        modelBuilder.Entity<ObshieSvedenya>(entity =>
        {
            entity.HasKey(e => e.КодОбщихСведений).HasName("PK_Клиенты");

            entity.ToTable("Общие сведения");

            entity.Property(e => e.КодОбщихСведений)
                .ValueGeneratedNever()
                .HasColumnName("Код общих сведений");
            entity.Property(e => e.АдресПроживания)
                .HasMaxLength(100)
                .HasColumnName("Адрес проживания");
            entity.Property(e => e.АдресРегистрации)
                .HasMaxLength(100)
                .HasColumnName("Адрес регистрации");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.Пол).HasMaxLength(50);
            entity.Property(e => e.Телефон).HasMaxLength(50);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<SocialnoePolojenie>(entity =>
        {
            entity.HasKey(e => e.КодСоциальногоПоложения);

            entity.ToTable("Социальное положение");

            entity.Property(e => e.КодСоциальногоПоложения)
                .ValueGeneratedNever()
                .HasColumnName("Код социального положения");
            entity.Property(e => e.ГруппаИнвалидности)
                .HasMaxLength(50)
                .HasColumnName("Группа инвалидности");
            entity.Property(e => e.Инвалидность).HasMaxLength(50);
            entity.Property(e => e.СемейноеПоложение)
                .HasMaxLength(50)
                .HasColumnName("Семейное положение");
            entity.Property(e => e.СоциальнаяКатегория)
                .HasMaxLength(50)
                .HasColumnName("Социальная категория");
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("ФИО");

            entity.HasOne(d => d.КодСоциальногоПоложенияNavigation).WithOne(p => p.СоциальноеПоложение)
                .HasForeignKey<SocialnoePolojenie>(d => d.КодСоциальногоПоложения)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Социальное положение_Общие сведения");
        });

        modelBuilder.Entity<Uslugi>(entity =>
        {
            entity.HasKey(e => e.КодУслуги);

            entity.ToTable("Услуги");

            entity.Property(e => e.КодУслуги)
                .ValueGeneratedNever()
                .HasColumnName("Код услуги");
            entity.Property(e => e.ДатаОказанияУслуги).HasColumnName("Дата оказания услуги");
            entity.Property(e => e.КодОбщихСведений).HasColumnName("Код общих сведений");
            entity.Property(e => e.НаименованиеУслуги)
                .HasMaxLength(50)
                .HasColumnName("Наименование услуги");
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("ФИО");

            entity.HasOne(d => d.КодОбщихСведенийNavigation).WithMany(p => p.Услугиs)
                .HasForeignKey(d => d.КодОбщихСведений)
                .HasConstraintName("FK_Услуги_Общие сведения");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
