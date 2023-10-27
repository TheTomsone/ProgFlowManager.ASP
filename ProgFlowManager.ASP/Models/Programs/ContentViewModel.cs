using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgFlowManager.BLL.Models.Programs;
using System.ComponentModel.DataAnnotations;

namespace ProgFlowManager.ASP.Models.Programs
{
    public class ContentViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Resume { get; set; }
        [ScaffoldColumn(false)]
        [Required]
        public int StageId { get; set; }
        [ScaffoldColumn(false)]
        [Required]
        public int VersionNbId { get; set; }
        //[BindNever]
        //public List<SelectListItem> StageList { get; set; }
    }
}
