﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4BL.DTO;
using Task4DAL.Repositories;
using AutoMapper;
using Task4DAL.Entities;
using Task4BL.Exceptions;

namespace Task4BL.Services
{
    public class ClientService : ISalesService<ClientDTO>
    {
        private ClientRepository clientRepository { get; }

        public ClientService(string connectionString)
        {
            clientRepository = new ClientRepository(connectionString);
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Client>, List<ClientDTO>>(clientRepository.GetAll());
        }

        public ClientDTO GetClientById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException("Invalid id input!");
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
                return mapper.Map<Client, ClientDTO>(clientRepository.GetById(id));
            }
        }

        public void AddClient(ClientDTO clientDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, Client>()).CreateMapper();
            Client client = mapper.Map<ClientDTO, Client>(clientDTO);

            clientRepository.Add(client);
        }

        public void Save()
        {
            clientRepository.Save();
        }

        public void Dispose()
        {
            clientRepository.Dispose();
        }
    }
}