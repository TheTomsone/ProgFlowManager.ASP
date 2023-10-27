using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework.Profiler;
using ProgFlowManager.Requester.API;

namespace ProgFlowManager.ASP.Controllers
{
    public class DataController : Controller
    {
        private readonly GenericAPIRequester _genericAPIRequester;

        public DataController(GenericAPIRequester genericAPIRequester)
        {
            _genericAPIRequester = genericAPIRequester;
        }

        //public IActionResult GetImage(int id)
        //{
        //    FileResultRequester fileResult = new FileResultRequester { Content = _genericAPIRequester.Get<byte[]>($"Data/{id}/image"), ContentType = _genericAPIRequester.Get<string>($"Data/{id}/imageType") };

        //    return fileResult.Content is null ? NotFound("Image not found") : File(fileResult.Content, fileResult.ContentType);
        //}
    }
}
