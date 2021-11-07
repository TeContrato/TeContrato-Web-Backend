using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    /*
     * La capa service se puede encargar de la lógica, pero para nada interactúa con la persistencia, es decir la BD, o al menos no directamente.
     * Necesita apoyarse en otra clase para que ese objeto sea el encargado de recuperar la info o guardarla, ese objeto es la capa de Persistencia.
     * Repository es un patrón de diseño que permite que haya una clase que se encarga de interactuar con la persistencia para manejar el tratamiento
     * de datos.
     */
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingCategory = await _userRepository.FindById(id);

            if (existingCategory == null)
                return new UserResponse("User Not Found");

            try
            {
                _userRepository.Remove(existingCategory);
                return new UserResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting user: {ex.Message}");
            }

        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingCategory = await _userRepository.FindById(id);

            if (existingCategory == null)
                return new UserResponse("User Not Found");

            return new UserResponse(existingCategory);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while saving the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User Not Found");

            existingUser.Nname = user.Nname;

            try
            {
                _userRepository.Update(existingUser);

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating user: {ex.Message}");
            }
        }
    }
}
