using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BuisnessLogicDll.Models
{
    [Index(nameof(Email), Name = "U_Email", IsUnique = true)]
    [Index(nameof(Username), Name = "U_Username", IsUnique = true)]
    public partial class Player
    {
        public Player()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int PlayerId { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Gender { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [Column("pWord")]
        [StringLength(18)]
        public string PWord { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfBirth { get; set; }
        public int? ActiveAnimal { get; set; }

        [ForeignKey(nameof(ActiveAnimal))]
        [InverseProperty(nameof(Animal.PlayerNavigation))]
        public virtual Animal ActiveAnimalNavigation { get; set; }
        [InverseProperty(nameof(Animal.Player))]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
