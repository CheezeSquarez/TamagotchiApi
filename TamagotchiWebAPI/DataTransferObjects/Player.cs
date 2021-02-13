using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuisnessLogicDll.Models;

#nullable disable

namespace TamagotchiWebAPI.DataTransferObjects
{
    
    public partial class PlayerDTO
    {
        public PlayerDTO()
        {

        }
        public PlayerDTO(Player p)
        {
            PlayerId = p.PlayerId;
            FirstName = p.FirstName;
            LastName = p.LastName;
            Email = p.Email;
            Gender = p.Gender;
            Username = p.Username;
            PWord = p.PWord;
            DateOfBirth = p.DateOfBirth;
            ActiveAnimal = p.ActiveAnimal;
        }
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string PWord { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ActiveAnimal { get; set; }
    }
}
