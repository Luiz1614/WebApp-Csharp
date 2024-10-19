using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

[Table("tb_Aula")]
public class AulaModel
{
    public int Id { get; set; }
    [DisplayName("Nome: ")]
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; }
    [DisplayName("Turma: ")]
    [Required(ErrorMessage = "O campo Turma é obrigatório.")]
    public string Turma { get; set; }
}
