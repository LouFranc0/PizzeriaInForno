namespace PizzeriaInForno.Models
{

    using PizzeriaInForno7.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordini()
        {
            OrdiniArticoli = new HashSet<OrdiniArticoli>();
        }

        public int ID { get; set; }

        public int? IDUtente { get; set; }

        public DateTime? DataOrdine { get; set; }

        [Required]
        [StringLength(50)]
        public string Stato { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        [Required]
        [StringLength(255)]
        public string Indirizzo { get; set; }

        public decimal Totale { get; set; }

        public virtual Utenti Utenti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdiniArticoli> OrdiniArticoli { get; set; }
    }
}