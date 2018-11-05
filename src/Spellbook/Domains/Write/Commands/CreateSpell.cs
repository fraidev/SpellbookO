using System;

namespace Spellbook.Domains.Write.Commands
{
    public class CreateSpell
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}