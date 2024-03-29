﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public readonly IUnitOfWork _unitOfWork;


        public JobService(IJobRepository contractorRepository, IUnitOfWork unitOfWork)
        {
            _jobRepository = contractorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<JobResponse> DeleteAsync(int id)
        {
            var existingTag = await _jobRepository.FindById(id);

            if (existingTag == null)
                return new JobResponse("City not found");

            try
            {
                _jobRepository.Remove(existingTag);
                return new JobResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new JobResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<JobResponse> GetByIdAsync(int id)
        {
            var existingTag = await _jobRepository.FindById(id);

            if (existingTag == null)
                return new JobResponse("City not found");
            return new JobResponse(existingTag);
        }
        
        public async Task<JobResponse> SaveAsync(Job city)
        {
            try
            {
                await _jobRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new JobResponse(city);
            }
            catch (Exception e)
            {
                return new JobResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<Job>> ListAsync()
        {
            return await _jobRepository.ListAsync();

        }

        public async Task<JobResponse> UpdateAsync(int id, Job city)
        {
            var existingCity = await _jobRepository.FindById(id);

            if (existingCity == null)
                return new JobResponse("City not found");

            existingCity.Cjob = city.Cjob;

            try
            {
                _jobRepository.Update(existingCity);

                return new JobResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new JobResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}