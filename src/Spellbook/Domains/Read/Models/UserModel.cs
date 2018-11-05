using System;

namespace Spellbook.Domains.Read.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }  
        public string Name {get ; set; }
        public string Password {get ; set; }
        public string Email {get ; set; }
    }
}