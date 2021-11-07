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
    [Route("/api/Contractors/[controller]/")]
    public class ContractorsController : ControllerBase
    {
        private readonly IContractorService _contractorService;
        private readonly IMapper _mapper;

        public ContractorsController(IContractorService contractorService, IMapper mapper)
        {
            _contractorService = contractorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContractorResource>> GetAllAsync()
        {
            var tags = await _contractorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Contractor>, IEnumerable<ContractorResource>>(tags) ;
            return resources;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a platform")]
        [ProducesResponseType(typeof(ContractorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveContractorResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var platform = _mapper.Map<SaveContractorResource, Contractor>(resource);
            var result = await _contractorService.SaveAsync(platform);

            if (!result.Success)
                return BadRequest(result.Message);

            var PlatformResource = _mapper.Map<Contractor, ContractorResource>(result.Resource);
            return Ok(PlatformResource);
        }
    }
}
