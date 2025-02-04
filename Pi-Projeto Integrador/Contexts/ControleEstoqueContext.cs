using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pi_Projeto_Integrador.Models;

namespace Pi_Projeto_Integrador.Contexts;

public partial class ControleEstoqueContext : DbContext
{
    public ControleEstoqueContext()
    {
    }

    public ControleEstoqueContext(DbContextOptions<ControleEstoqueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<cadUsuario> cadUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=dbCondominio;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<cadUsuario>(entity =>
        {
            entity.HasKey(e => e.cdUsuario).HasName("PK__cadUsuar__0C5725AA9432C04B");

            entity.Property(e => e.dtCriacao).HasColumnType("datetime");
            entity.Property(e => e.senha)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.usuarioLogin)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
