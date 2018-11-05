using System;
using System.Linq;
using Spellbook.Domains.Write.States;
using Spellbook.Infrastructure.Persistence;

namespace Spellbook.Domains.Write.Repositories
{
    public interface IUserRepository
    {
        void Add(UserState user);
        UserState Autenticar(string username, string password);
        void Remove(Guid id);
        void Update(UserState user);
    }
    
    public class UserRepository: IUserRepository
    {
        private IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void Add(UserState user)
        {
            _unitOfWork.Save(user);
        }

        public UserState Autenticar(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            UserState retvalUser = _unitOfWork.Query<UserState>()
                .SingleOrDefault(x => x.Name == username && x.Password == password);
 
            // check if username exists
            if (retvalUser == null)
                return null;
 
            // check if password is correct
            // if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //     return null;
 
            // authentication successful
            return retvalUser;
        }

        public void Remove(Guid id)
        {
            var entity = _unitOfWork.Query<UserState>().First(u=> u.Id == id);
            _unitOfWork.Delete(entity);
        }

        public void Update(UserState user)
        {
            _unitOfWork.Update(user);
        }
    }
}