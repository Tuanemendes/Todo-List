using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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