using RiverBooks.Users.Data;

namespace RiverBooks.Users.UseCases;

public interface IApplicationUserRepository
{
  Task<ApplicationUser> GetUserWithCartByEmail(string email);
  Task SaveChanges();
}
