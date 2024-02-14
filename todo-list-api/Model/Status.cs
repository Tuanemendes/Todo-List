using System.ComponentModel;


namespace todo_list_api.Model
{
    public enum Status
    {
        [Description("Pendente")]
        Pendente,

        [Description("Concluído")]
        Concluido,

        [Description("Em Andamento")]
        EmAndamento
    }

}
