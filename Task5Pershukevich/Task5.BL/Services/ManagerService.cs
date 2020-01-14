using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.BL.DTO;
using Task5.BL.Exceptions;
using Task5.DAL.Entities;
using Task5.DAL.Repositories;

namespace Task5.BL.Services
{
    public class ManagerService : ISalesService<ManagerDTO>
    {
        private ManagerRepository _managerRepository;

        public ManagerService(string connectionString)
        {
            _managerRepository = new ManagerRepository(connectionString);
        }

        public IEnumerable<ManagerDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Manager, ManagerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Manager>, List<ManagerDTO>>(_managerRepository.GetAll());
        }

        public ManagerDTO GetManagerById(int id)
        {
            if (id < 0)
            {
                return null;
                throw new InvalidIdException("Invalid id input!");
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Manager, ManagerDTO>()).CreateMapper();
                return mapper.Map<Manager, ManagerDTO>(_managerRepository.GetById(id));
            }
        }

        public int AddManager(ManagerDTO managerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ManagerDTO, Manager>()).CreateMapper();
            Manager manager = mapper.Map<ManagerDTO, Manager>(managerDTO);

            var managerId = _managerRepository.Add(manager);

            return managerId;
        }

        public void Save()
        {
            _managerRepository.Save();
        }

        public void Dispose()
        {
            _managerRepository.Dispose();
        }
    }
}
