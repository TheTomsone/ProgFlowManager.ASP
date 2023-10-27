using ProgFlowManager.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgFlowManager.BLL.Models.Programs
{
    public class VersionNb : Data, IModel
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }
        public DateTime Goal { get; set; }
        public DateTime Release { get; set; }
        public Stage Stage { get; set; }
        public int SoftwareId { get; set; }

        public string VersionFormatted
        {
            get { return DataConverterTool.Concat(new List<string> { Major.ToString(), Minor.ToString(), Patch.ToString() }, ".", "v", "-") + Stage.Label; }
        }
                
    }
}
