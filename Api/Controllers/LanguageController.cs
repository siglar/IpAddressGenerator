using Api.Services.IpAddressService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageSpeakerService _languageSpeakerService;

        public LanguageController(ILanguageSpeakerService languageSpeakerService)
        {
            _languageSpeakerService = languageSpeakerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _languageSpeakerService.GetLanguagesWithSpeakers();

            return Ok(result);
        }
    }
}
