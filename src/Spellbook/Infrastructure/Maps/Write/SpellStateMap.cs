using FluentNHibernate.Mapping;
using Spellbook.Domains.Write.States;

namespace Spellbook.Infrastructure.Maps.Write
{
    public class SpellStateMap: ClassMap<SpellState>
    {
        public SpellStateMap()
        {
            Table("SPELL");

            Id(x => x.Id);

            Map(x => x.Text);
            Map(x => x.UserId);
        }
    }
}