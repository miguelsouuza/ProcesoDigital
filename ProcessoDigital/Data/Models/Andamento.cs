using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessoDigital.Data.Model
{
    public class Andamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "A descrição do andamento é obrigatória.")]
        public string Descricao { get; set; } = string.Empty; // Ex: Publicação de sentença, Despacho, etc.

        // Chave Estrangeira
        public int ProcessoId { get; set; }

        [ForeignKey("ProcessoId")]
        public virtual Processo? Processo { get; set; }
    }
}
