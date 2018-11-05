
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using NHibernate.Tuple;
using Spellbook.Domains.Write.States;

namespace Spellbook.Infrastructure.Maps.Write
{
    public class UserStateMap: ClassMap<UserState>
    {
        public UserStateMap()
        {
            Table("User");

            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.Email);
            Map(x => x.Password);

        }
    }
}