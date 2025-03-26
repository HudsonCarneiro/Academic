namespace ProgramacaoIV.ToDoList.Model;

public sealed class Todo
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; } = false;
}