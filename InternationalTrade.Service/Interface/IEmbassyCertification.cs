﻿using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IEmbassyCertification
    {
        EmbassyCertificationViewPage Index(string id);
    }
}
