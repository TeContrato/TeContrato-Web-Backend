using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public readonly IUnitOfWork _unitOfWork;


        public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientResponse> DeleteAsync(int id)
        {
            var existingClient = await _clientRepository.FindById(id);

            if (existingClient == null)
                return new ClientResponse("City not found");

            try
            {
                _clientRepository.Remove(existingClient);
                return new ClientResponse(existingClient);
            }
            catch (Exception ex)
            {
                return new ClientResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<ClientResponse> GetByIdAsync(int id)
        {
            var existingClient = await _clientRepository.FindById(id);

            if (existingClient == null)
                return new ClientResponse("City not found");
            return new ClientResponse(existingClient);
        }
        
        public async Task<ClientResponse> SaveAsync(Client client)
        {
            try
            {
                await _clientRepository.AddAsync(client);
                await _unitOfWork.CompleteAsync();

                return new ClientResponse(client);
            }
            catch (Exception e)
            {
                return new ClientResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _clientRepository.ListAsync();

        }

        public async Task<ClientResponse> UpdateAsync(int id, Client client)
        {
            var existingClient = await _clientRepository.FindById(id);

            if (existingClient == null)
                return new ClientResponse("City not found");

            existingClient.Cuser = client.Cuser;

            try
            {
                _clientRepository.Update(existingClient);

                return new ClientResponse(existingClient);
            }
            catch (Exception ex)
            {
                return new ClientResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}
