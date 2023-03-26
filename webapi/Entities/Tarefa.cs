namespace webapi.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string NomeTarefa { get; set; } = "";
        public string? Descricao { get; set; } = "";
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }        
        public bool Terminado { get; set; }
    }
}
