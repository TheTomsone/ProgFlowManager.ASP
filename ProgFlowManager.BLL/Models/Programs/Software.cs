using ProgFlowManager.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ProgFlowManager.BLL.Models.Programs
{
    public class Software : Data, IModel
    {
        private const string defaultDateFormat = "dd MMMM yyy HH:mm";
        public DateTime ETA { get; set; }
        public DateTime Started { get; set; }
        public Stage Stage { get; set; }
        public List<Category> Categories { get; set; }
        public List<Language> Languages { get; set; }

        public string HeaderBar
        {
            get
            {
                string delimiter = " - ";

                if (Categories.Count < 1 && Languages.Count  < 1) return string.Empty;
                if (Languages.Count < 1 | Categories.Count < 1) delimiter = string.Empty;

                return (Categories.Count > 0 ? DataConverterTool.Concat(Categories.ConvertTo(cat => cat.Label), "·") : "") +
                       delimiter +
                       (Languages.Count > 0 ? DataConverterTool.Concat(Languages.ConvertTo(lang => lang.Label)) : "");
            }
        }
        public string FooterBar
        {
            get
            {
                string delimiter = " - ";

                if (Updated is null) delimiter = string.Empty;

                return Created.ToString(defaultDateFormat) +
                       delimiter +
                       (Updated is not null ? Created.ToString(defaultDateFormat) : "");
            }
        }
    }
}
