using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _cityRepository;
        public readonly IUnitOfWork _unitOfWork;


        public ProjectService(IProjectRepository contractorRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = contractorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProjectResponse> DeleteAsync(int id)
        {
            var existingTag = await _cityRepository.FindById(id);

            if (existingTag == null)
                return new ProjectResponse("City not found");

            try
            {
                _cityRepository.Remove(existingTag);
                return new ProjectResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<ProjectResponse> GetByIdAsync(int id)
        {
            var existingTag = await _cityRepository.FindById(id);

            if (existingTag == null)
                return new ProjectResponse("City not found");
            return new ProjectResponse(existingTag);
        }
        
        public async Task<ProjectResponse> SaveAsync(Project city)
        {
            try
            {
                await _cityRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(city);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _cityRepository.ListAsync();

        }

        public async Task<ProjectResponse> UpdateAsync(int id, Project city)
        {
            var existingCity = await _cityRepository.FindById(id);

            if (existingCity == null)
                return new ProjectResponse("City not found");

            existingCity.Nproject = city.Nproject;

            try
            {
                _cityRepository.Update(existingCity);

                return new ProjectResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}