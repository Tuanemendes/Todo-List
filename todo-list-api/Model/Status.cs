using System.ComponentModel.DataAnnotations;

namespace todo_list_api.Model
{
    public enum Status
    {
        [Display(Name = "Pendente")]
        Pendente,

        [Display(Name = "Concluído")]
        Concluido,

        [Display(Name = "Em andamento")]
        EmAndamento
    }

}