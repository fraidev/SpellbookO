

using System;
using System.Collections.Generic;
using System.Linq;
using Spellbook.Domains.Write.States;
using Spellbook.Infrastructure.Persistence;

namespace Spellbook.Domains.Read.Repositories
{
    public interface ISpellReadRepository
    {
        IEnumerable<SpellState> GetbyUserId(string userId);
        SpellState Find(Guid id);
    }
    
    public class SpellReadRepository: ISpellReadRepository
    {
        private IUnitOfWork _unitOfWork;
        
        public SpellReadRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SpellState> GetbyUserId(string userId)
        {
            return _unitOfWork.Query<SpellState>().Where(x=> x.UserId == userId).ToList();
        }

        public SpellState Find(Guid id)
        {
            return _unitOfWork.Query<SpellState>().FirstOrDefault(u => u.Id == id);
        }
    }
}