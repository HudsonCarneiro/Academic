using System;
using System.ComponentModel.DataAnnotations;

namespace ProgramacaoIV.Venda.Api.DTO;

public sealed class TransacaoDTO
{
    public sealed class TransacaoCapaRequest
    {
        [Required(ErrorMessage = "O Id do Cliente é obrigatório.")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "O Id do Vendedor é obrigatório.")]
        public Guid IdVendedor { get; set; }

        public TransacaoCapaRequest(Guid idCliente, Guid idVendedor)
        {
            if (idCliente == Guid.Empty)
                throw new ArgumentException("O Id do Cliente não pode ser vazio.", nameof(idCliente));

            if (idVendedor == Guid.Empty)
                throw new ArgumentException("O Id do Vendedor não pode ser vazio.", nameof(idVendedor));

            IdCliente = idCliente;
            IdVendedor = idVendedor;
        }
    }

    public sealed class TransacaoItemRequest
    {
        [Required(ErrorMessage = "O Id do Produto é obrigatório.")]
        public Guid IdProduto { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public decimal Quantidade { get; set; }

        public TransacaoItemRequest(Guid idProduto, decimal quantidade)
        {
            if (idProduto == Guid.Empty)
                throw new ArgumentException("O Id do Produto não pode ser vazio.", nameof(idProduto));

            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantidade));

            IdProduto = idProduto;
            Quantidade = quantidade;
        }
    }
}
