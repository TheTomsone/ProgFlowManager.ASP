﻿using ProgFlowManager.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgFlowManager.BLL.Models.Programs
{
    public class VersionNbDetails : VersionNb, IModel
    {
        public List<Content> Contents { get; set; }
    }
}
