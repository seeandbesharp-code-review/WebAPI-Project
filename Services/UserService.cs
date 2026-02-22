using AutoMapper;
using DTOs;
using Entities;
using Repositories;

namespace Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordService _service;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IPasswordService service, IMapper mapper)
    {
        _repository = repository;
        _service = service;
        _mapper = mapper;
    }

    public async Task<UserDTO> GetUserById(int id)
    {
        User user = await _repository.GetUserById(id);
        UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
        return userDTO;
    }

    public async Task<UserDTO> AddUser(User newUser)
    {
        if (_service.Check(newUser.Password).Strength < 2)
        {
            return null;
        }
        User user = await _repository.AddUser(newUser);
        UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
        return userDTO;
    }

    public async Task<bool> UpdateUser(User user, int id)
    {
        if (_service.Check(user.Password).Strength < 2)
        {
            return false;
        }
        await _repository.UpdateUser(id, user);
        return true;
    }

    public async Task<UserDTO> LogIn(User newUser)
    {
        User user = await _repository.LogIn(newUser);
        UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
        return userDTO;
    }
}

