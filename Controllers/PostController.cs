using InternationalApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace InternationalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IStringLocalizer<PostController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedStringLocalizer;

        public PostController(IStringLocalizer<PostController> stringLocalizer, IStringLocalizer<SharedResource> sharedStringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _sharedStringLocalizer = sharedStringLocalizer;
        }

        [HttpGet]
        [Route("post_resource")]
        public IActionResult GetUsingPostControllerResource()
        {
            // find text
            var article = _stringLocalizer["article"];
            var postName = _stringLocalizer.GetString("welcome").Value ?? string.Empty;

            return Ok(new
            {
                PostType = article,
                PostNAme = postName
            });
        }

        [HttpGet]
        [Route("shared_resource")]
        public IActionResult GetUsingSharedResource()
        {
            // find text
            var article = _stringLocalizer.GetString("article").Value;
            var postName = _stringLocalizer.GetString("welcome").Value ?? string.Empty;
            var todayIs = string.Format(_sharedStringLocalizer.GetString("todayIs"),
                                DateTime.Today.ToLongDateString()); 

            return Ok(new
            {
                PostType = article,
                PostNAme = postName,
                TodayIs = todayIs
            });
        }
    }
}
