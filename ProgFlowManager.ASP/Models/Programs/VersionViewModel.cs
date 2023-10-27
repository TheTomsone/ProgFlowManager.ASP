using System.ComponentModel.DataAnnotations;

namespace ProgFlowManager.ASP.Models.Programs
{
    public class VersionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Resume { get; set; }
        [Required]
        public int Major { get; set; }
        [Required]
        public int Minor { get; set; }
        [Required]
        public int Patch { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Goal { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Release {  get; set; }
        public int StageId { get; set; }
        public int SoftwareId { get; set; }
    }
}
