using System;

namespace Spellbook.Domains.Write.States
{
    public class SpellState
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
    }
}