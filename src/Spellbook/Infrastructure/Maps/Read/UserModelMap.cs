using FluentNHibernate.Mapping;
using Spellbook.Domains.Read.Models;

namespace Spellbook.Infrastructure.Maps.Read
{
    public class UserModelMap: ClassMap<UserModel>
    {
        public UserModelMap()
        {
            ReadOnly();
            
            Table("User");

            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.Email);
            Map(x => x.Password);
        }
    }
}