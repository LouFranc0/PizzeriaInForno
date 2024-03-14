namespace PizzeriaInForno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Articoli")]
    public partial class Articoli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articoli()
        {
            OrdiniArticoli = new HashSet<OrdiniArticoli>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public decimal Prezzo { get; set; }

        [StringLength(255)]
        public string Descrizione { get; set; }

        [StringLength(255)]
        public string Immagine { get; set; }

        public int? TempoConsegna { get; set; }

        [StringLength(255)]
        public string Ingredienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdiniArticoli> OrdiniArticoli { get; set; }
    }
}