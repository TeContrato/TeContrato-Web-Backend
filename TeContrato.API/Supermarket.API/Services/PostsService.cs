using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class PostsService : IPostService
    {
        private readonly IPostRepository _cityRepository;
        public readonly IUnitOfWork _unitOfWork;


        public PostsService(IPostRepository contractorRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = contractorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PostsResponse> DeleteAsync(int id)
        {
            var existingTag = await _cityRepository.FindById(id);

            if (existingTag == null)
                return new PostsResponse("City not found");

            try
            {
                _cityRepository.Remove(existingTag);
                return new PostsResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new PostsResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<PostsResponse> GetByIdAsync(int id)
        {
            var existingTag = await _cityRepository.FindById(id);

            if (existingTag == null)
                return new PostsResponse("City not found");
            return new PostsResponse(existingTag);
        }
        
        public async Task<PostsResponse> SaveAsync(Posts city)
        {
            try
            {
                await _cityRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new PostsResponse(city);
            }
            catch (Exception e)
            {
                return new PostsResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<Posts>> ListAsync()
        {
            return await _cityRepository.ListAsync();

        }

        public async Task<PostsResponse> UpdateAsync(int id, Posts city)
        {
            var existingCity = await _cityRepository.FindById(id);

            if (existingCity == null)
                return new PostsResponse("City not found");

            existingCity.Tbody = city.Tbody;

            try
            {
                _cityRepository.Update(existingCity);

                return new PostsResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new PostsResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}