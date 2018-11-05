using System;
using System.Collections.Generic;
using System.Linq;
using Spellbook.Domains.Read.Models;
using Spellbook.Domains.Write.States;
using Spellbook.Infrastructure.Persistence;

namespace Spellbook.Domains.Read.Repositories
{
    public interface IUserReadRepository
    {
        IEnumerable<UserState> GetAll();
        UserState Find(Guid id);
    }
    
    public class UserReadRepository: IUserReadRepository
    {
        private IUnitOfWork _unitOfWork;
        
        public UserReadRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserState Find(Guid id)
        {
            return _unitOfWork.Query<UserState>().FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<UserState> GetAll()
        {
            return _unitOfWork.Query<UserState>().ToList();
        }
    }
}