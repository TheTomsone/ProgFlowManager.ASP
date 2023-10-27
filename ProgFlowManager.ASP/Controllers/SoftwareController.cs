using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgFlowManager.ASP.Models.Programs;
using ProgFlowManager.ASP.Tools;
using ProgFlowManager.BLL.Models.Programs;
using ProgFlowManager.Requester.API;

namespace ProgFlowManager.ASP.Controllers
{
    public class SoftwareController : Controller
    {
        private readonly GenericAPIRequester _genericAPIRequester;

        public SoftwareController(GenericAPIRequester genericAPIRequester)
        {
            _genericAPIRequester = genericAPIRequester;
        }

        public IActionResult Index()
        {
            return View(_genericAPIRequester.Get<IEnumerable<SoftwareDetails>>("Software/details"));
        }

        [HttpGet("Content/Create")]
        public IActionResult CreateContent(int versionId)
        {
            ContentViewModel viewModel = new()
            {
                VersionNbId = versionId
            };

            foreach (var prop in viewModel.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name + " - " + prop.GetValue(viewModel));
            }

            return View(viewModel);
        }
        [HttpPost("Content/Create")]
        public IActionResult CreateContent(ContentViewModel newModel)
        {
            foreach (var prop in newModel.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name + " - " + prop.GetValue(newModel));
            }
            if (!ModelState.IsValid) return BadRequest(newModel);

            try
            {
                if (_genericAPIRequester.Post<ContentViewModel, bool>(newModel, "Content")) return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return View();
        }
        [HttpGet("Content/Update")]
        public IActionResult UpdateContent(int id)
        {
            Content content = _genericAPIRequester.Get<Content>($"Content/{id}");
            ContentViewModel viewModel = new ContentViewModel
            {
                Id = id,
                Name = content.Name,
                Resume = content.Resume is null ? "" : content.Resume,
                StageId = content.Stage.Id,
                VersionNbId = content.VersionNbId
            };

            foreach (var prop in content.GetType().GetProperties())
                Console.WriteLine(prop.Name + " - " + prop.GetValue(content));

            foreach (var prop in  viewModel.GetType().GetProperties())
                Console.WriteLine(prop.Name + " - " + prop.GetValue(viewModel));

            return View(viewModel);
        }
        [HttpPost("Content/Update")]
        public IActionResult UpdateContent(ContentViewModel updatedContent)
        {
            foreach (var prop in  updatedContent.GetType().GetProperties())
                Console.WriteLine(prop.Name + " - " + prop.GetValue(updatedContent));

            if (!ModelState.IsValid) return BadRequest(updatedContent);

            Console.WriteLine("Test");

            try { if (_genericAPIRequester.Patch(updatedContent, $"Content/{updatedContent.Id}")) return RedirectToAction("Index"); }
            catch (Exception ex) { return BadRequest(ex.Message); }

            return BadRequest(updatedContent);
        }
        [HttpGet("Content/Delete")]
        public IActionResult DeleteContent(int id)
        {
            try { if (_genericAPIRequester.Delete($"Content/{id}")) return RedirectToAction("Index"); }
            catch (Exception ex) { return BadRequest(ex.Message); }

            return View();
        }

        [HttpGet("Version/Create")]
        public IActionResult CreateVersion(int softwareId)
        {
            VersionViewModel viewModel = new()
            {
                Goal = null,
                Release = null,
                SoftwareId = softwareId
            };

            foreach (var prop in viewModel.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name + " - " + prop.GetValue(viewModel));
            }

            return View(viewModel);
        }
        [HttpPost("Version/Create")]
        public IActionResult CreateVersion(VersionViewModel newModel)
        {
            foreach (var prop in newModel.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name + " - " + prop.GetValue(newModel));
            }
            if (!ModelState.IsValid) return BadRequest(newModel);

            Console.WriteLine("Test");

            try
            {
                if (_genericAPIRequester.Post<VersionViewModel, bool>(newModel, "Version")) return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(newModel);
            }

            return View();
        }
        [HttpGet("Version/Update")]
        public IActionResult UpdateVersion(int id)
        {
            VersionNb version = _genericAPIRequester.Get<VersionNb>($"Version/{id}");
            VersionViewModel viewModel = new VersionViewModel
            {
                Id = id,
                Name = version.Name,
                Resume = version.Resume is null ? "" : version.Resume,
                Major = version.Major,
                Minor = version.Minor,
                Patch = version.Patch,
                Goal = version.Goal,
                Release = version.Release,
                StageId = version.Stage.Id,
                SoftwareId = version.SoftwareId
            };

            foreach (var prop in version.GetType().GetProperties())
                Console.WriteLine(prop.Name + " - " + prop.GetValue(version));

            foreach (var prop in viewModel.GetType().GetProperties())
                Console.WriteLine(prop.Name + " - " + prop.GetValue(viewModel));

            return View(viewModel);
        }
        [HttpPost("Version/Update")]
        public IActionResult UpdateVersion(VersionViewModel updatedVersion)
        {
            foreach (var prop in updatedVersion.GetType().GetProperties())
                Console.WriteLine(prop.Name + " - " + prop.GetValue(updatedVersion));

            if (!ModelState.IsValid) return BadRequest(updatedVersion);

            Console.WriteLine("Test");

            try { if (_genericAPIRequester.Patch(updatedVersion, $"Version/{updatedVersion.Id}")) return RedirectToAction("Index"); }
            catch (Exception ex) { return BadRequest(ex.Message); }

            return BadRequest(updatedVersion);
        }
        [HttpGet("Version/Delete")]
        public IActionResult DeleteVersion(int id)
        {
            try { if (_genericAPIRequester.Delete($"Version/{id}")) return RedirectToAction("Index"); }
            catch (Exception ex) { return BadRequest(ex.Message); }

            return View();
        }
    }
}
