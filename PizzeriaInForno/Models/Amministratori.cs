

namespace PizzeriaInForno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Amministratori")]
    public class Amministratori
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Inserisci l'Username")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Inserisci la Password")]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string Ruolo { get; set; }
    }
}