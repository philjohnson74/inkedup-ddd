using System.Threading.Tasks;
using InkedUp.Api.Services;
using Microsoft.AspNetCore.Mvc;
using static InkedUp.Api.Contracts.Pens;

namespace InkedUp.Api.Controllers
{
    [Route("/pen")]
    public class PensCommands : Controller
    {
        private readonly PensApplicationService 
            _applicationService;

        public PensCommands(
            PensApplicationService applicationService
        )
            => _applicationService = applicationService;

        [HttpPost]
        public async Task<IActionResult> Post(V1.Create request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(V1.Get request)
        {
            var pen = await _applicationService.HandleGet(request);
            return new OkObjectResult(pen);
        }

        [Route("manufacturer")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.UpdateManufacturer request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("model")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.UpdateModel request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("inkup")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.InkUp request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
    }
}