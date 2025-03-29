using ProgramacaoIV.Venda.Api.Entidades;

namespace ProgramacaoIV.Venda.Api.Context;

public static class VendaInitializer
{
    public static void Initialize(VendaContext context)
    {
       
        PopularTabelas(context);
    }

    private static void PopularTabelas(VendaContext context)
    {
        bool alterado = false;

        if (!context.Clientes.Any())
        {
            context.Clientes.Add(new Cliente("CONSUMIDOR FINAL", "00000000000", "RUA TESTE, 999, CIANORTE-PR", "44999999999"));
            alterado = true;
        }

        if (!context.Produtos.Any())
        {
            context.Produtos.Add(new Produto("123456789012", "PRODUTO TESTE", 15.90m, 79.90m, 999m));
            alterado = true;
        }

        if (!context.Vendedores.Any())
        {
            context.Vendedores.Add(new Vendedor("VENDEDOR02", "vendedor02@email.com")); 
            alterado = true;
        }

        if (alterado)
        {
            context.SaveChanges(); // Chama SaveChanges() apenas uma vez
        }
    }
}
