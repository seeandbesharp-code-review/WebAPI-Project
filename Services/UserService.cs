using AutoMapper;
using DTOs;
using Entities;
using Repositories;

namespace Services;

public class UserService : IUserService
    {

        IUserRepository repository;
        IPasswordService service;
        IMapper mapper;

        public UserService(IUserRepository repository, IPasswordService service, IMapper mapper)
        {
            this.repository = repository;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<UserDTO> GetUserById(int id) 
        { 
            User user = await repository.GetUserById(id);
            UserDTO userDTO = mapper.Map<User, UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> AddUser(User newUser)
        { 
            if(service.Check(newUser.Password).Strength<2)
            {
                return null;
            }
            else
            {
                User user = await repository.AddUser(newUser);
                UserDTO userDTO = mapper.Map<User, UserDTO>(user);
                return userDTO;
        }        
        }

        public async Task<bool> UpdateUser(User user, int id)
        {
        if (service.Check(user.Password).Strength < 2)
            {
                return false;
            }
            await repository.UpdateUser(id,user);
            return true;
        }

        public async Task<UserDTO> LogIn(User newUser)
        {
            User user = await repository.LogIn(newUser);
            UserDTO userDTO = mapper.Map<User, UserDTO>(user);
            return userDTO;
        }


}

