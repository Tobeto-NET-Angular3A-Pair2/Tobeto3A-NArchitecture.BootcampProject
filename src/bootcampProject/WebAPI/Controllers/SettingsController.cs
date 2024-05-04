using Application.Features.Settings.Commands.Update;
using Application.Features.Settings.Queries.GetById;
using Infrastructure.Adapters.ImageService;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseController
    {
        private readonly CloudinaryImageServiceAdapter _cloudinaryImageServiceAdapter;

        public SettingsController(CloudinaryImageServiceAdapter cloudinaryImageService)
        {
            _cloudinaryImageServiceAdapter = cloudinaryImageService;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSettingCommand updateSettingCommand)
        {  
            UpdatedSettingResponse response = await Mediator.Send(updateSettingCommand);
            return Ok(response);
        }

       

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdSettingResponse response = await Mediator.Send(new GetByIdSettingQuery { Id = id });
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(IFormFile formFile)
        {
               
            var result = await _cloudinaryImageServiceAdapter.UploadAsync(formFile);
            UpdatedSettingImageReponse settingsReponse = new UpdatedSettingImageReponse
            {
                Url = result
            };
            return Ok(settingsReponse);
        }
    }
}
