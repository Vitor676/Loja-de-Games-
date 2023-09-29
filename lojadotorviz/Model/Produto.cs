using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lojadotorviz.Model
{
    public class Produto
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Console { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateOnly DataLancamento { get; set; }

        [Column(TypeName = "decimal (10,2)")]
        public decimal Preco { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(2000)]
        public string Foto { get; set; } = string.Empty;

        public virtual Categoria? Categoria { get; set; }

    }
}

