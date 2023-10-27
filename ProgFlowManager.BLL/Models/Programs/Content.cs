using ProgFlowManager.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgFlowManager.BLL.Models.Programs
{
    public class Content : Data, IModel
    {
        public int VersionNbId { get; set; }
        public Stage Stage { get; set; }
    }
}
