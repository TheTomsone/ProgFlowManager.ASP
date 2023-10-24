using System.ComponentModel.DataAnnotations;

namespace ProgFlowManager.ASP.Models.ModelsAPI
{
    public abstract class BaseCategory
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
