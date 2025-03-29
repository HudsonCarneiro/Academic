using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramacaoIV.Venda.Api.Entidades;

namespace ProgramacaoIV.Venda.Api.Map;

public sealed class VendedorMap : AbstractEntidadeMap<Vendedor>
{
    public override void Configure(EntityTypeBuilder<Vendedor> builder)
    {
        base.Configure(builder);

        builder.ToTable("VENDEDOR");

        builder.Property(x => x.Nome).HasColumnName("NM_VENDEDOR").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Email).HasColumnName("EM_VENDEDOR").HasMaxLength(200).IsRequired();

    }
}