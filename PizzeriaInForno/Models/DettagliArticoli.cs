namespace PizzeriaInForno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DettagliOrdine")]
    public partial class DettagliOrdine
    {
        public int ID { get; set; }

        public int? IDOrdine { get; set; }

        [Required]
        [StringLength(255)]
        public string Indirizzo { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public virtual Ordini Ordini { get; set; }
    }
}