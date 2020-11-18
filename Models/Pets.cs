namespace CRUD.Models
{
  public class Pet
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public int PessoaId { get; set; }
    public bool Adotado { get; set; }
  }
}