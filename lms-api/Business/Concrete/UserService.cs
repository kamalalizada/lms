using DataAccess.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;
public class UserService
{
    private readonly UserRepository _repository;

    public UserService(UserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<User>> GetAllAsync()=>await _repository.GetAllAsync();

    public async Task<User> GetByIdAsync(int id)=>await _repository.GetByIdAsync(id);

    public async Task AddAsync(User user)=>await _repository.AddAsync(user);

    public async Task UpdateAsync(User user)=>await _repository.UpdateAsync(user);

    public async Task DeleteAsync(int id)=>await _repository.DeleteAsync(id);
}
