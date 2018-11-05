using System;
using Spellbook.Domains.Write.Commands;
using Spellbook.Domains.Write.States;
using Spellbook.Infrastructure.Persistence;

namespace Spellbook.Domains.Write.Repositories
{
    public interface ISpellRepository
    {
        void Add(SpellState spellState);
        void Remove(Guid id);
        void Update(SpellState user);
    }
    
    public class SpellRepository: ISpellRepository
    {
        private IUnitOfWork _unitOfWork;

        public SpellRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void Add(SpellState spellState)
        {
            _unitOfWork.Save(spellState);
        }

        public void Remove(Guid id)
        {
            _unitOfWork.Delete(id);
        }

        public void Update(SpellState spellState)
        {
            _unitOfWork.Update(spellState);
        }
    }
}