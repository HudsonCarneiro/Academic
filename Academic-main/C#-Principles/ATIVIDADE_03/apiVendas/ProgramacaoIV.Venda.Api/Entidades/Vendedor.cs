using ProgramacaoIV.Venda.Api.Entidades;
using System.Text.RegularExpressions;


public class Vendedor : AbstractEntity
{
    public string Nome { get; private set; }
    public string Email { get; private set; }

    /// <summary>
    /// Construtor privado para uso do EF Core.
    /// </summary>
    private Vendedor() : base() { }

    public Vendedor(string nome, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentNullException(nameof(nome), "O nome do vendedor é obrigatório.");

        if (!ValidarEmail(email))
            throw new ArgumentException("O e-mail fornecido é inválido.", nameof(email));

        Nome = nome.ToUpper();
        Email = email.ToLower(); // E-mails geralmente são tratados em minúsculas
    }

    public void AtualizarInformacoes(string nome, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentNullException(nameof(nome), "O nome do vendedor é obrigatório.");

        if (!ValidarEmail(email))
            throw new ArgumentException("O e-mail fornecido é inválido.", nameof(email));

        Nome = nome.ToUpper();
        Email = email.ToLower();
        AtualizarDataAtualizacao();
    }

    private static bool ValidarEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
        return regex.IsMatch(email);
    }
}
