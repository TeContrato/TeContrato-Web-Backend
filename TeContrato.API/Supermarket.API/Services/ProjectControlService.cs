using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class ProjectControlService : IProjectControlService
    {
        private readonly IProjectControlRepository _cityRepository;
        public readonly IUnitOfWork _unitOfWork;


        public ProjectControlService(IProjectControlRepository contractorRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = contractorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProjectControlResponse> DeleteAsync(int id)
        {
            var existingTag = await _cityRepository.FindById(id);

            if (existingTag == null)
                return new ProjectControlResponse("City not found");

            try
            {
                _cityRepository.Remove(existingTag);
                return new ProjectControlResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new ProjectControlResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<ProjectControlResponse> GetByIdAsync(int id)
        {
            var existingTag = await _cityRepository.FindById(id);

            if (existingTag == null)
                return new ProjectControlResponse("City not found");
            return new ProjectControlResponse(existingTag);
        }
        
        public async Task<ProjectControlResponse> SaveAsync(ProjectControl city)
        {
            try
            {
                await _cityRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new ProjectControlResponse(city);
            }
            catch (Exception e)
            {
                return new ProjectControlResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<ProjectControl>> ListAsync()
        {
            return await _cityRepository.ListAsync();

        }

        public async Task<ProjectControlResponse> UpdateAsync(int id, ProjectControl city)
        {
            var existingCity = await _cityRepository.FindById(id);

            if (existingCity == null)
                return new ProjectControlResponse("City not found");

            existingCity.Nproject = city.Nproject;

            try
            {
                _cityRepository.Update(existingCity);

                return new ProjectControlResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new ProjectControlResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}