using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data;
public partial class Gestor2Context : DbContext
{
    public Gestor2Context()
    {
    }

    public Gestor2Context(DbContextOptions<Gestor2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<GestorAcceso> GestorAccesos { get; set; }

    public virtual DbSet<GestorColaboradores> GestorColaboradores { get; set; }

    public virtual DbSet<GestorDocColaboradores> GestorDocColaboradores { get; set; }

    public virtual DbSet<GestorDocProveedor> GestorDocProveedors { get; set; }

    public virtual DbSet<GestorDocTrabajos> GestorDocTrabajos { get; set; }

    public virtual DbSet<GestorDocVehiculos> GestorDocVehiculos { get; set; }

    public virtual DbSet<GestorGrupoUsuario> GestorGrupoUsuarios { get; set; }

    public virtual DbSet<GestorProveedor> GestorProveedors { get; set; }

    public virtual DbSet<GestorRole> GestorRoles { get; set; }

    public virtual DbSet<GestorTrabajos> GestorTrabajos { get; set; }

    public virtual DbSet<GestorUsuario> GestorUsuarios { get; set; }

    public virtual DbSet<GestorUsuariosAcceso> GestorUsuariosAccesos { get; set; }

    public virtual DbSet<GestorVehiculos> GestorVehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QR0752P; Database=GESTOR2; User ID=venar; Password=123456; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GestorAcceso>(entity =>
        {
            entity.HasKey(e => e.AcciId).HasName("PK__GESTOR_A__403703128C808F56");

            entity.ToTable("GESTOR_ACCESOS");

            entity.Property(e => e.AcciId).HasColumnName("ACCI_ID");
            entity.Property(e => e.AccvNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACCV_NOMBRE");
        });

        modelBuilder.Entity<GestorColaboradores>(entity =>
        {
            entity.HasKey(e => e.ColaiId).HasName("PK__GESTOR_C__D38F62DE644294C9");

            entity.ToTable("GESTOR_COLABORADORES");

            entity.Property(e => e.ColaiId).HasColumnName("COLAI_ID");
            entity.Property(e => e.ColaiEstadoTrab).HasColumnName("COLAI_ESTADO_TRAB");
            entity.Property(e => e.ColaiNumeroDoc).HasColumnName("COLAI_NUMERO_DOC");
            entity.Property(e => e.ColavApellidoMat)
                .HasMaxLength(50)
                .HasColumnName("COLAV_APELLIDO_MAT");
            entity.Property(e => e.ColavApellidoPat)
                .HasMaxLength(50)
                .HasColumnName("COLAV_APELLIDO_PAT");
            entity.Property(e => e.ColavDireccion)
                .HasMaxLength(100)
                .HasColumnName("COLAV_DIRECCION");
            entity.Property(e => e.ColavNacionalidad)
                .HasMaxLength(50)
                .HasColumnName("COLAV_NACIONALIDAD");
            entity.Property(e => e.ColavNombres)
                .HasMaxLength(100)
                .HasColumnName("COLAV_NOMBRES");
            entity.Property(e => e.ColavPuestoTrabajo)
                .HasMaxLength(50)
                .HasColumnName("COLAV_PUESTO_TRABAJO");
            entity.Property(e => e.ColavSexo)
                .HasMaxLength(50)
                .HasColumnName("COLAV_SEXO");
            entity.Property(e => e.ColavTipoDoc)
                .HasMaxLength(15)
                .HasColumnName("COLAV_TIPO_DOC");
            entity.Property(e => e.ProviId).HasColumnName("PROVI_ID");

            entity.HasOne(d => d.Provi).WithMany(p => p.GestorColaboradores)
                .HasForeignKey(d => d.ProviId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GESTOR_CO__PROVI__5AEE82B9");
        });

        modelBuilder.Entity<GestorDocColaboradores>(entity =>
        {
            entity.HasKey(e => e.DoccolaiId).HasName("PK__GESTOR_D__FD953CDEE97BD27E");

            entity.ToTable("GESTOR_DOC_COLABORADOR");

            entity.Property(e => e.DoccolaiId).HasColumnName("DOCCOLAI_ID");
            entity.Property(e => e.ColaiId).HasColumnName("COLAI_ID");
            entity.Property(e => e.DoccoladFechaReg).HasColumnName("DOCCOLAD_FECHA_REG");
            entity.Property(e => e.DoccolavDescripcion).HasColumnName("DOCCOLAV_DESCRIPCION");
            entity.Property(e => e.DocIdDocumentoStorage).HasColumnName("DocIdDocumentoStorage");
            entity.Property(e => e.DoccolavRuta)
                .HasMaxLength(200)
                .HasColumnName("DOCCOLAV_RUTA");
         
            entity.Property(e => e.ProviId).HasColumnName("PROVI_ID");

            entity.HasOne(d => d.Colai).WithMany(p => p.GestorDocColaboradores)
                .HasForeignKey(d => d.ColaiId)
                .HasConstraintName("FK__GESTOR_DO__COLAI__6477ECF3");

            entity.HasOne(d => d.Provi).WithMany(p => p.GestorDocColaboradors)
                .HasForeignKey(d => d.ProviId)
                .HasConstraintName("FK__GESTOR_DO__PROVI__656C112C");
        });

        modelBuilder.Entity<GestorDocProveedor>(entity =>
        {
            entity.HasKey(e => e.DocproviId).HasName("PK__GESTOR_D__1375341BEA6A23A0");

            entity.ToTable("GESTOR_DOC_PROVEEDOR");

            entity.Property(e => e.DocproviId).HasColumnName("DOCPROVI_ID");
            entity.Property(e => e.DocprovdFechaReg).HasColumnName("DOCPROVD_FECHA_REG");
            entity.Property(e => e.DocprovvDescripcion).HasColumnName("DOCPROVV_DESCRIPCION");
            entity.Property(e => e.DocprovvRuta)
                .HasMaxLength(200)
                .HasColumnName("DOCPROVV_RUTA");
            entity.Property(e => e.ProviId).HasColumnName("PROVI_ID");

            entity.HasOne(d => d.Provi).WithMany(p => p.GestorDocProveedors)
                .HasForeignKey(d => d.ProviId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GESTOR_DO__PROVI__6FE99F9F");
        });

        modelBuilder.Entity<GestorDocTrabajos>(entity =>
        {
            entity.HasKey(e => e.DoctrabiId).HasName("PK__GESTOR_D__B54A82554D271644");

            entity.ToTable("GESTOR_DOC_TRABAJOS");

            entity.Property(e => e.DoctrabiId).HasColumnName("DOCTRABI_ID");
            entity.Property(e => e.DoctrabdFechaReg).HasColumnName("DOCTRABD_FECHA_REG");
            entity.Property(e => e.DoctrabvDescripcion).HasColumnName("DOCTRABV_DESCRIPCION");
            entity.Property(e => e.DoctrabvRuta)
                .HasMaxLength(200)
                .HasColumnName("DOCTRABV_RUTA");
            entity.Property(e => e.ProviId).HasColumnName("PROVI_ID");
            entity.Property(e => e.TrabiId).HasColumnName("TRABI_ID");

            entity.HasOne(d => d.Provi).WithMany(p => p.GestorDocTrabajos)
                .HasForeignKey(d => d.ProviId)
                .HasConstraintName("FK__GESTOR_DO__PROVI__6D0D32F4");

            entity.HasOne(d => d.Trabi).WithMany(p => p.GestorDocTrabajos)
                .HasForeignKey(d => d.TrabiId)
                .HasConstraintName("FK__GESTOR_DO__TRABI__6C190EBB");
        });

        modelBuilder.Entity<GestorDocVehiculos>(entity =>
        {
            entity.HasKey(e => e.DocvehiId).HasName("PK__GESTOR_D__D3834C3A631E5276");

            entity.ToTable("GESTOR_DOC_VEHICULO");

            entity.Property(e => e.DocvehiId).HasColumnName("DOCVEHI_ID");
            entity.Property(e => e.DocvehidFechaReg).HasColumnName("DOCVEHID_FECHA_REG");
            entity.Property(e => e.DocvehivDescripcion).HasColumnName("DOCVEHIV_DESCRIPCION");
            entity.Property(e => e.DocIdDocumentoStorage).HasColumnName("DocIdDocumentoStorage");
            entity.Property(e => e.DocvehivRuta)
                .HasMaxLength(200)
                .HasColumnName("DOCVEHIV_RUTA");
            entity.Property(e => e.ProviId).HasColumnName("PROVI_ID");
            entity.Property(e => e.VehiId).HasColumnName("VEHI_ID");

            entity.HasOne(d => d.Provi).WithMany(p => p.GestorDocVehiculos)
                .HasForeignKey(d => d.ProviId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GESTOR_DO__PROVI__693CA210");

            entity.HasOne(d => d.Vehi).WithMany(p => p.GestorDocVehiculos)
                .HasForeignKey(d => d.VehiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GESTOR_DO__VEHI___68487DD7");
        });

        modelBuilder.Entity<GestorGrupoUsuario>(entity =>
        {
            entity.HasKey(e => e.GruiId).HasName("PK__GESTOR_G__1905F9632E33C494");

            entity.ToTable("GESTOR_GRUPO_USUARIOS");

            entity.Property(e => e.GruiId).HasColumnName("GRUI_ID");
            entity.Property(e => e.GruvNombre)
                .HasMaxLength(100)
                .HasColumnName("GRUV_NOMBRE");
        });

        modelBuilder.Entity<GestorProveedor>(entity =>
        {
            entity.HasKey(e => e.ProviId).HasName("PK__GESTOR_P__F489B4D0132C017C");

            entity.ToTable("GESTOR_PROVEEDOR");

            entity.Property(e => e.ProviId).HasColumnName("PROVI_ID");
            entity.Property(e => e.ProvdFechaRegistro).HasColumnName("PROVD_FECHA_REGISTRO");
            entity.Property(e => e.ProvnCodigo).HasColumnName("PROVN_CODIGO");
            entity.Property(e => e.ProvnRuc).HasColumnName("PROVN_RUC");
            entity.Property(e => e.ProvnTelefonoResp).HasColumnName("PROVN_TELEFONO_RESP");
            entity.Property(e => e.ProvvActividadEcon)
                .HasMaxLength(100)
                .HasColumnName("PROVV_ACTIVIDAD_ECON");
            entity.Property(e => e.ProvvApellidoMatResp)
                .HasMaxLength(50)
                .HasColumnName("PROVV_APELLIDO_MAT_RESP");
            entity.Property(e => e.ProvvApellidoPatResp)
                .HasMaxLength(50)
                .HasColumnName("PROVV_APELLIDO_PAT_RESP");
            entity.Property(e => e.ProvvCorreoResp)
                .HasMaxLength(200)
                .HasColumnName("PROVV_CORREO_RESP");
            entity.Property(e => e.ProvvDepartamento)
                .HasMaxLength(100)
                .HasColumnName("PROVV_DEPARTAMENTO");
            entity.Property(e => e.ProvvDireccion)
                .HasMaxLength(200)
                .HasColumnName("PROVV_DIRECCION");
            entity.Property(e => e.ProvvDistrito)
                .HasMaxLength(100)
                .HasColumnName("PROVV_DISTRITO");
            entity.Property(e => e.ProvvNombre)
                .HasMaxLength(100)
                .HasColumnName("PROVV_NOMBRE");
            entity.Property(e => e.ProvvNombreResp)
                .HasMaxLength(50)
                .HasColumnName("PROVV_NOMBRE_RESP");
            entity.Property(e => e.ProvvPais)
                .HasMaxLength(50)
                .HasColumnName("PROVV_PAIS");
            entity.Property(e => e.ProvvProvincia)
                .HasMaxLength(100)
                .HasColumnName("PROVV_PROVINCIA");
            entity.Property(e => e.ProvvRazonSocial)
                .HasMaxLength(50)
                .HasColumnName("PROVV_RAZON_SOCIAL");
            entity.Property(e => e.ProvvReferencia).HasColumnName("PROVV_REFERENCIA");
            entity.Property(e => e.UsuaiId).HasColumnName("USUAI_ID");

            entity.HasOne(d => d.Usuai).WithMany(p => p.GestorProveedors)
                .HasForeignKey(d => d.UsuaiId)
                .HasConstraintName("FK__GESTOR_PR__USUAI__5812160E");
        });

        modelBuilder.Entity<GestorRole>(entity =>
        {
            entity.HasKey(e => e.RoliId).HasName("PK__GESTOR_R__AD7E406DC7D08C8A");

            entity.ToTable("GESTOR_ROLES");

            entity.Property(e => e.RoliId).HasColumnName("ROLI_ID");
            entity.Property(e => e.RolvNombre)
                .HasMaxLength(50)
                .HasColumnName("ROLV_NOMBRE");
        });

        modelBuilder.Entity<GestorTrabajos>(entity =>
        {
            entity.HasKey(e => e.TrabiId).HasName("PK__GESTOR_T__C4D2932A87E306B9");

            entity.ToTable("GESTOR_TRABAJOS");

            entity.Property(e => e.TrabiId).HasColumnName("TRABI_ID");
            entity.Property(e => e.ProviId).HasColumnName("PROVI_ID");
            entity.Property(e => e.TrabdFechaFin).HasColumnName("TRABD_FECHA_FIN");
            entity.Property(e => e.TrabdFechaInicio).HasColumnName("TRABD_FECHA_INICIO");
            entity.Property(e => e.TrabvDescripcion).HasColumnName("TRABV_DESCRIPCION");
            entity.Property(e => e.TrabvEstado)
                .HasMaxLength(50)
                .HasColumnName("TRABV_ESTADO");

            entity.HasOne(d => d.Provi).WithMany(p => p.GestorTrabajos)
                .HasForeignKey(d => d.ProviId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GESTOR_TR__PROVI__619B8048");
        });

        modelBuilder.Entity<GestorUsuario>(entity =>
        {
            entity.HasKey(e => e.UsuaiId).HasName("PK__GESTOR_U__0C159614720D64C5");

            entity.ToTable("GESTOR_USUARIOS");

            entity.Property(e => e.UsuaiId).HasColumnName("USUAI_ID");
            entity.Property(e => e.GruiId).HasColumnName("GRUI_ID");
            entity.Property(e => e.RoliId).HasColumnName("ROLI_ID");
            entity.Property(e => e.UsuavApellido)
                .HasMaxLength(50)
                .HasColumnName("USUAV_APELLIDO");
            entity.Property(e => e.UsuavEmail)
                .HasMaxLength(100)
                .HasColumnName("USUAV_EMAIL");
            entity.Property(e => e.UsuavNom)
                .HasMaxLength(50)
                .HasColumnName("USUAV_NOM");
            entity.Property(e => e.UsuavNombre)
                .HasMaxLength(50)
                .HasColumnName("USUAV_NOMBRE");
            entity.Property(e => e.UsuavPass)
                .HasMaxLength(50)
                .HasColumnName("USUAV_PASS");

            entity.HasOne(d => d.Grui).WithMany(p => p.GestorUsuarios)
                .HasForeignKey(d => d.GruiId)
                .HasConstraintName("FK__GESTOR_US__GRUI___5070F446");

            entity.HasOne(d => d.Roli).WithMany(p => p.GestorUsuarios)
                .HasForeignKey(d => d.RoliId)
                .HasConstraintName("FK__GESTOR_US__ROLI___4F7CD00D");
        });

        modelBuilder.Entity<GestorUsuariosAcceso>(entity =>
        {
            entity.HasKey(e => e.UsuaacciId).HasName("PK__GESTOR_U__7BF7ED813903ACC1");

            entity.ToTable("GESTOR_USUARIOS_ACCESOS");

            entity.HasIndex(e => new { e.UsuaiId, e.AcciId }, "UQ_Usuario_Acceso").IsUnique();

            entity.Property(e => e.UsuaacciId).HasColumnName("USUAACCI_ID");
            entity.Property(e => e.AcciId).HasColumnName("ACCI_ID");
            entity.Property(e => e.UsuaiId).HasColumnName("USUAI_ID");

            entity.HasOne(d => d.Acci).WithMany(p => p.GestorUsuariosAccesos)
                .HasForeignKey(d => d.AcciId)
                .HasConstraintName("FK__GESTOR_US__ACCI___5535A963");

            entity.HasOne(d => d.Usuai).WithMany(p => p.GestorUsuariosAccesos)
                .HasForeignKey(d => d.UsuaiId)
                .HasConstraintName("FK__GESTOR_US__USUAI__5441852A");
        });

        modelBuilder.Entity<GestorVehiculos>(entity =>
        {
            entity.HasKey(e => e.VehiId).HasName("PK__GESTOR_V__FE66BE80E92C884E");

            entity.ToTable("GESTOR_VEHICULOS");

            entity.HasIndex(e => e.VehicPlaca, "UQ__GESTOR_V__57731FD1F1B03272").IsUnique();

            entity.Property(e => e.VehiId).HasColumnName("VEHI_ID");
            entity.Property(e => e.ProviId).HasColumnName("PROVI_ID");
            entity.Property(e => e.VehicPlaca)
                .HasMaxLength(10)
                .HasColumnName("VEHIC_PLACA");
            entity.Property(e => e.VehinAno).HasColumnName("VEHIN_ANO");
            entity.Property(e => e.VehivMarca)
                .HasMaxLength(50)
                .HasColumnName("VEHIV_MARCA");
            entity.Property(e => e.VehivModelo)
                .HasMaxLength(50)
                .HasColumnName("VEHIV_MODELO");

            entity.HasOne(d => d.Provi).WithMany(p => p.GestorVehiculos)
                .HasForeignKey(d => d.ProviId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GESTOR_VE__PROVI__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
