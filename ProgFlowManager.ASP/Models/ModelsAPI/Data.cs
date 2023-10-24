using System.ComponentModel.DataAnnotations;

namespace ProgFlowManager.ASP.Models.ModelsAPI
{
    public class Data
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Resume { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMime { get; set; }

        public Data()
        {
            Resume = null;
            Created = null;
            Updated = null;
            ImageData = null;
            ImageMime = null;
        }
    }
}
