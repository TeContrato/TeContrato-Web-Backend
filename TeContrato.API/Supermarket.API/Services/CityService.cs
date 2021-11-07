using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public readonly IUnitOfWork _unitOfWork;


        public CityService(ICityRepository contractorRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = contractorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CityResponse> DeleteAsync(int id)
        {
            var existingTag = await _cityRepository.FindById(id);

            if (existingTag == null)
                return new CityResponse("City not found");

            try
            {
                _cityRepository.Remove(existingTag);
                return new CityResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new CityResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<CityResponse> GetByIdAsync(int id)
        {
            var existingTag = await _cityRepository.FindById(id);

            if (existingTag == null)
                return new CityResponse("City not found");
            return new CityResponse(existingTag);
        }
        
        public async Task<CityResponse> SaveAsync(City city)
        {
            try
            {
                await _cityRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new CityResponse(city);
            }
            catch (Exception e)
            {
                return new CityResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _cityRepository.ListAsync();

        }

        public async Task<CityResponse> UpdateAsync(int id, City city)
        {
            var existingCity = await _cityRepository.FindById(id);

            if (existingCity == null)
                return new CityResponse("City not found");

            existingCity.Ncity = city.Ncity;

            try
            {
                _cityRepository.Update(existingCity);

                return new CityResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new CityResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}
