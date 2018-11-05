using FluentNHibernate.Mapping;
using Spellbook.Domains.Read.Models;
using Spellbook.Domains.Write.States;

namespace Spellbook.Infrastructure.Maps.Read
{
    public class SpellModelMap: ClassMap<SpellModel>
    {
        public SpellModelMap()
        {
            Table("SPELL");

            Id(x => x.Id);

            Map(x => x.Text);
            Map(x => x.UserId);
        }
    }
}