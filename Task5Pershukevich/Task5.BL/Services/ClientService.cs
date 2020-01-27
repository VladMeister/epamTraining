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
    public class ClientService : ISalesService<ClientDTO>
    {
        private ClientRepository _clientRepository;

        public ClientService(string connectionString)
        {
            _clientRepository = new ClientRepository(connectionString);
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Client>, List<ClientDTO>>(_clientRepository.GetAll());
        }

        public IEnumerable<ClientDTO> GetClientsByLastname(string lastName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Client>, List<ClientDTO>>(_clientRepository.GetFilteredByLastname(lastName));
        }

        public ClientDTO GetClientById(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            return mapper.Map<Client, ClientDTO>(_clientRepository.GetById(id));
        }

        public int AddClient(ClientDTO clientDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, Client>()).CreateMapper();
            Client client = mapper.Map<ClientDTO, Client>(clientDTO);

            var clientId = _clientRepository.Add(client);

            return clientId;
        }

        public void UpdateClient(ClientDTO clientDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, Client>()).CreateMapper();
            Client client = mapper.Map<ClientDTO, Client>(clientDTO);

            _clientRepository.Update(client);
        }

        public void DeleteClient(ClientDTO clientDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, Client>()).CreateMapper();
            Client client = mapper.Map<ClientDTO, Client>(clientDTO);

            _clientRepository.Delete(client);
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}
