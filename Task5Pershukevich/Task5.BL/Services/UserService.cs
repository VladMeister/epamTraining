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
            var userList = _userRepository.GetAll();

            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Role, RoleDTO>()
                .ForMember(r => r.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(r => r.Name, opt => opt.MapFrom(src => src.Name));

                cfg.CreateMap<User, UserDTO>()
                .ForMember(u => u.Role, opt => opt.MapFrom(src => src.Role));
            }).CreateMapper();

            return mapper.Map<IEnumerable<User>, List<UserDTO>>(userList);
        }

        public void RegisterUser(UserDTO userDTO)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<RoleDTO, Role>()
                .ForMember(r => r.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(r => r.Name, opt => opt.MapFrom(src => src.Name));

                cfg.CreateMap<UserDTO, User>()
                .ForMember(u => u.Role, opt => opt.MapFrom(src => src.Role));
            }).CreateMapper();

            User user = mapper.Map<UserDTO, User>(userDTO);

            _userRepository.Register(user);
        }

        public bool UserExists(string email, string password)
        {
            return _userRepository.UserExists(email, password);
        }

        public void AddUserRole(RoleDTO roleDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, Role>()).CreateMapper();
            Role role = mapper.Map<RoleDTO, Role>(roleDTO);

            _userRepository.AddRole(role);
        }

        public IEnumerable<RoleDTO> GetUserRoles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Role>, List<RoleDTO>>(_userRepository.GetRoles());
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
