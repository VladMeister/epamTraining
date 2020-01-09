using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BL.DTO;
using Task4.BL.Exceptions;
using Task4.DAL.Entities;
using Task4.DAL.Repositories;

namespace Task4.BL.Services
{
    public class ManagerService : ISalesService<ManagerDTO>
    {
        private ManagerRepository managerRepository { get; }

        public ManagerService(string connectionString)
        {
            managerRepository = new ManagerRepository(connectionString);
        }

        public IEnumerable<ManagerDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Manager, ManagerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Manager>, List<ManagerDTO>>(managerRepository.GetAll());
        }

        public ManagerDTO GetManagerById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException("Invalid id input!");
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Manager, ManagerDTO>()).CreateMapper();
                return mapper.Map<Manager, ManagerDTO>(managerRepository.GetById(id));
            }
        }

        public void AddManager(ManagerDTO managerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ManagerDTO, Manager>()).CreateMapper();
            Manager manager = mapper.Map<ManagerDTO, Manager>(managerDTO);

            managerRepository.Add(manager);
        }

        public void Save()
        {
            managerRepository.Save();
        }

        public void Dispose()
        {
            managerRepository.Dispose();
        }
    }
}
