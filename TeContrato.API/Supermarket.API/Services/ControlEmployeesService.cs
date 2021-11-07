using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class ControlEmployeesService : IControlEmployeesService
    {
        private readonly IControlEmployeesRepository _controlEmployeesRepository;
        public readonly IUnitOfWork _unitOfWork;


        public ControlEmployeesService(IControlEmployeesRepository controlEmployees, IUnitOfWork unitOfWork)
        {
            _controlEmployeesRepository = controlEmployees;
            _unitOfWork = unitOfWork;
        }

        public async Task<ControlEmployeesResponse> DeleteAsync(int id)
        {
            var existingControlEmployee = await _controlEmployeesRepository.FindById(id);

            if (existingControlEmployee == null)
                return new ControlEmployeesResponse("City not found");

            try
            {
                _controlEmployeesRepository.Remove(existingControlEmployee);
                return new ControlEmployeesResponse(existingControlEmployee);
            }
            catch (Exception ex)
            {
                return new ControlEmployeesResponse($"An error ocurred while deleting controlEmployees: {ex.Message}");
            }
        }

        public async Task<ControlEmployeesResponse> GetByIdAsync(int id)
        {
            var existingControlEmployee = await _controlEmployeesRepository.FindById(id);

            if (existingControlEmployee == null)
                return new ControlEmployeesResponse("City not found");
            return new ControlEmployeesResponse(existingControlEmployee);
        }
        
        public async Task<ControlEmployeesResponse> SaveAsync(ControlEmployees controlEmployees)
        {
            try
            {
                await _controlEmployeesRepository.AddAsync(controlEmployees);
                await _unitOfWork.CompleteAsync();

                return new ControlEmployeesResponse(controlEmployees);
            }
            catch (Exception e)
            {
                return new ControlEmployeesResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<ControlEmployees>> ListAsync()
        {
            return await _controlEmployeesRepository.ListAsync();

        }

        public async Task<ControlEmployeesResponse> UpdateAsync(int id, ControlEmployees controlEmployees)
        {
            var existingControlEmployee = await _controlEmployeesRepository.FindById(id);

            if (existingControlEmployee == null)
                return new ControlEmployeesResponse("City not found");

            existingControlEmployee.ProjectControl_Control = controlEmployees.ProjectControl_Control;

            try
            {
                _controlEmployeesRepository.Update(existingControlEmployee);

                return new ControlEmployeesResponse(existingControlEmployee);
            }
            catch (Exception ex)
            {
                return new ControlEmployeesResponse($"An error ocurred while updating the controlEmployees: {ex.Message}");
            }

        }
    }
}