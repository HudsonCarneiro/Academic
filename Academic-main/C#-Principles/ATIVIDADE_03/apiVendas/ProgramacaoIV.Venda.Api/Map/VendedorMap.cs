using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramacaoIV.Venda.Api.Entidades;

namespace ProgramacaoIV.Venda.Api.Map;

public sealed class VendedorMap : AbstractEntidadeMap<Vendedor>
{
    public override void Configure(EntityTypeBuilder<Vendedor> builder)
    {
        base.Configure(builder);

        builder.ToTable("VENDEDORES"); // Melhor manter no plural para refletir o conjunto de dados

        builder.Property(x => x.Nome)
            .HasColumnName("NM_VENDEDOR")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("EM_VENDEDOR")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.IsAtivo)
            .HasColumnName("IS_ATIVO")
            .HasDefaultValue(true) // Define o valor padrão como true
            .IsRequired();

        builder.Property(x => x.DataCriacao) // Corrigido para DataCriacao
            .HasColumnName("DT_CRIACAO")
            .HasDefaultValueSql("GETUTCDATE()") // Usa a data do banco no momento da criação
            .IsRequired();

        builder.Property(x => x.DataAtualizacao) // Corrigido para DataAtualizacao
            .HasColumnName("DT_ATUALIZACAO")
            .HasDefaultValueSql("GETUTCDATE()") // Atualizado automaticamente
            .IsRequired();
    }
}
