using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [Route("/api/[controller]")]
        public class ClientsController : ControllerBase
        {
            private readonly IClientService _clientService;
            private readonly IMapper _mapper;

            public ClientsController(IClientService clientService, IMapper mapper)
            {
                _clientService = clientService;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<IEnumerable<ClientResource>> GetAllAsync()
            {
                var tags = await _clientService.ListAsync();
                var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(tags);
                return resources;
            }

            [HttpPost]
            [SwaggerOperation(Summary = "Create a platform")]
            [ProducesResponseType(typeof(ClientResource), 200)]
            [ProducesResponseType(typeof(BadRequestResult), 404)]
            public async Task<IActionResult> PostAsync([FromBody] SaveClientResource resource)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }

                var platform = _mapper.Map<SaveClientResource, Client>(resource);
                var result = await _clientService.SaveAsync(platform);

                if (!result.Success)
                    return BadRequest(result.Message);

                var PlatformResource = _mapper.Map<Client, ClientResource>(result.Resource);
                return Ok(PlatformResource);
            }
        }
    }
}

