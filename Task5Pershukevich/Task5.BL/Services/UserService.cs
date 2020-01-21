using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.BL.DTO;
using Task5.DAL.Entities;
using Task5.DAL.Repositories;

namespace Task5.BL.Services
{
    public class UserService : ISalesService<UserDTO>
    {
        private UserRepository _userRepository;

        public UserService(string connectionString)
        {
            _userRepository = new UserRepository(connectionString);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(_userRepository.GetAll());
        }

        public void RegisterUser(UserDTO userDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            User user = mapper.Map<UserDTO, User>(userDTO);

            _userRepository.Register(user);
        }

        public bool LoginUser(string email, string password)
        {
            return _userRepository.Login(email, password);
        }

        public void UpdateClient(UserDTO userDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            User user = mapper.Map<UserDTO, User>(userDTO);

            _userRepository.Update(user);
        }

        public void DeleteClient(UserDTO userDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            User user = mapper.Map<UserDTO, User>(userDTO);

            _userRepository.Delete(user);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
