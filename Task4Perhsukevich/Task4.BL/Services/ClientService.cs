﻿using AutoMapper;
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

        public ClientDTO GetClientById(int id)
        {
            if (id < 0)
            {
                return null;
                throw new InvalidIdException("Invalid id input!");
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
                return mapper.Map<Client, ClientDTO>(_clientRepository.GetById(id));
            }
        }

        public int AddClient(ClientDTO clientDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, Client>()).CreateMapper();
            Client client = mapper.Map<ClientDTO, Client>(clientDTO);

            var clientId = _clientRepository.Add(client);

            return clientId;
        }

        public void Save()
        {
            _clientRepository.Save();
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}
