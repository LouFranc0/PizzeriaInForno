namespace PizzeriaInForno7.Models
{
    using PizzeriaInForno.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    

    [Table("Utenti")]
    public partial class Utenti
    {
        public Utenti()
        {
            Ordini = new HashSet<Ordini>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Inserisci l'Username")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Inserisci la Password")]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Ruolo { get; set; }

        public virtual ICollection<Ordini> Ordini { get; set; }
    }
}