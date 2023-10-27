using ProgFlowManager.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgFlowManager.BLL.Models
{
    public class BaseCategory : IModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
