using System;

namespace Spellbook.Domains.Read.Models
{
    public class SpellModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
    }
}