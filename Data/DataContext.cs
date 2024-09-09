using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TbCampanha> Campanhas { get; set; }
        public DbSet<TbCategoria> Categorias { get; set; }
        public DbSet<TbCluster> Clusters { get; set; }
        public DbSet<TbCompra> Compras { get; set; }
        public DbSet<TbCredit> Credits { get; set; }
        public DbSet<TbCreditCompra> CreditCompras { get; set; }
        public DbSet<TbLoja> Lojas { get; set; }
        public DbSet<TbNotificaco> Notificacoes { get; set; }
        public DbSet<TbPonto> Pontos { get; set; }
        public DbSet<TbPontosCompra> PontosCompra { get; set; }
        public DbSet<TbProduto> Produtos { get; set; }
        public DbSet<TbUser> Users { get; set; }
        public DbSet<TbUserCluster> UserClusters { get; set; }
        public DbSet<TbUserPdv> UserPdvs { get; set; }
        public DbSet<TbUsermaster> UserMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseOracle("Data Source=oracle.fiap.com.br:1521/orcl;User ID=rm99085;Password=170297;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("RM99085")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<TbCampanha>(entity =>
            {
                entity.HasKey(e => e.Campanhaid).HasName("TB_CAMPANHAS_PK");

                entity.HasOne(d => d.Cluster).WithMany(p => p.TbCampanhas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_CAMPANHAS_ID_CLUSTERID_FK");

                entity.HasOne(d => d.Master).WithMany(p => p.TbCampanhas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_CAMPANHAS_ID_MASTERID_FK");
            });

            modelBuilder.Entity<TbCategoria>(entity =>
            {
                entity.HasKey(e => e.Categoriaid).HasName("TB_CATEGORIAS_PK");

                entity.Property(e => e.Ativo).IsFixedLength();
            });

            modelBuilder.Entity<TbCluster>(entity =>
            {
                entity.HasKey(e => e.Clusterid).HasName("TB_CLUSTER_PK");
            });

            modelBuilder.Entity<TbCompra>(entity =>
            {
                entity.HasKey(e => e.Compraid).HasName("TB_COMPRAS_PK");

                entity.HasOne(d => d.Pdv).WithMany(p => p.TbCompras)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_COMPRAS_ID_PDVID_FK");

                entity.HasOne(d => d.Users).WithMany(p => p.TbCompras)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_COMPRAS_ID_USERSID_FK");
            });

            modelBuilder.Entity<TbCredit>(entity =>
            {
                entity.HasKey(e => e.Creditid).HasName("TB_CREDIT_PK");

                entity.Property(e => e.Utilizado).IsFixedLength();
            });

            modelBuilder.Entity<TbCreditCompra>(entity =>
            {
                entity.HasOne(d => d.Compra).WithMany()
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_CREDIT_C_ID_COMPRASID_FK");

                entity.HasOne(d => d.Credit).WithMany()
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_CREDIT_C_ID_CREDITID_FK");
            });

            modelBuilder.Entity<TbLoja>(entity =>
            {
                entity.HasKey(e => e.Pdvid).HasName("TB_LOJA_PK");

                entity.Property(e => e.Ativo).IsFixedLength();
            });

            modelBuilder.Entity<TbNotificaco>(entity =>
            {
                entity.HasKey(e => e.Notificacoesid).HasName("TB_NOTIFICACOES_PK");

                entity.HasOne(d => d.Pdv).WithMany(p => p.TbNotificacos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_NOTIFICACOES_ID_PDVID_FK");
            });

            modelBuilder.Entity<TbPonto>(entity =>
            {
                entity.HasKey(e => e.Pointid).HasName("TB_PONTOS_PK");

                entity.Property(e => e.Utilizado).IsFixedLength();
            });

            modelBuilder.Entity<TbPontosCompra>(entity =>
            {
                entity.HasOne(d => d.Compra).WithMany()
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_PONTOS_C_ID_COMPRASID_FK");

                entity.HasOne(d => d.Point).WithMany()
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_PONTOS_C_ID_PONTOSID_FK");
            });

            modelBuilder.Entity<TbProduto>(entity =>
            {
                entity.HasKey(e => e.Produtoid).HasName("TB_PRODUTOSV1_PK");

                entity.Property(e => e.Ativo).IsFixedLength();

                entity.HasOne(d => d.Categoria).WithMany(p => p.TbProdutos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_PRODUTOS_ID_CATEGORIAID_FK");

                entity.HasOne(d => d.Pdv).WithMany(p => p.TbProdutos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_PRODUTOS_ID_PDVID_FK");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.Usersid).HasName("TB_USERS_PK");

                entity.Property(e => e.Ativo).IsFixedLength();
            });

            modelBuilder.Entity<TbUserCluster>(entity =>
            {
                entity.HasKey(e => e.Userclusterid).HasName("TB_USER_CLUSTER_PK");

                entity.HasOne(d => d.Cluster).WithMany(p => p.TbUserClusters)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_USER_CLUSTER_ID_CLUSTER_FK");

                entity.HasOne(d => d.User).WithMany(p => p.TbUserClusters)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_USER_CLUSTER_ID_USERS_FK");
            });

            modelBuilder.Entity<TbUserPdv>(entity =>
            {
                entity.HasKey(e => e.Userpdvid).HasName("TB_USERPDV_PK");

                entity.Property(e => e.Ativo).IsFixedLength();

                entity.HasOne(d => d.Pdv).WithMany(p => p.TbUserPdvs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TB_USER_PDV_ID_PDVID_FK");
            });

            modelBuilder.Entity<TbUsermaster>(entity =>
            {
                entity.HasKey(e => e.Masterid).HasName("TB_USERMASTER_PK");

                entity.Property(e => e.Ativo).IsFixedLength();
            });
        }
    }
}
