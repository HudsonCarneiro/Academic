namespace ProgramacaoIV.ToDoList.Model;
using System.ComponentModel.DataAnnotations;

public class Nota
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(100, ErrorMessage = "O nome do aluno deve ter no máximo 100 caracteres.")]
    public string Aluno { get; set; } = string.Empty;

    [Required]
    [StringLength(100, ErrorMessage = "A disciplina deve ter no máximo 100 caracteres.")]
    public string Disciplina { get; set; } = string.Empty;

    [Required]
    [Range(0, 10, ErrorMessage = "A nota deve estar entre 0 e 10.")]
    public decimal Valor { get; set; }

    public DateTime DataLancamento { get; set; } = DateTime.UtcNow;
}
