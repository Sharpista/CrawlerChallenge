using API.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations
{
    public class ServidorProxyConfiguration : IEntityTypeConfiguration<ServidorProxy>
    {
        public void Configure(EntityTypeBuilder<ServidorProxy> builder)
        {
            builder.ToTable("servidores_proxy");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).HasColumnName("id_servidor");

            builder.Property(x => x.Https).HasColumnName("https");

            builder.Property(x => x.Protocolo).HasColumnName("protocolo");

            builder.Property(x => x.Porta).HasColumnName("porta");

            builder.Property(x => x.Anonimato).HasColumnName("anonimato");

            builder.Property(x => x.Country).HasColumnName("pais");

            builder.Property(x => x.Code).HasColumnName("codigo_pais");

            builder.Property(x => x.Ip).HasColumnName("ip");

            builder.Property(x => x.Latencia).HasColumnName("latencia");

            builder.Property(x => x.UltimaVerificacao).HasColumnName("ultima_verificacao");

        }
    }
}
