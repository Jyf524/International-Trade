﻿using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IForeMessage
    {
        String Message(ForeMessageViewPage MessageAdd, string id, string UserID);//留言
    }
}
