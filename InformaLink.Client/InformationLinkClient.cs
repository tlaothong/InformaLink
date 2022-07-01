﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace InformaLink.Client
{
    public class InformationLinkClient
    {
        public Task<List<PrimaryRecord>> GetInfo()
        {
            return "https://localhost:7058/api/primary".GetJsonAsync<List<PrimaryRecord>>();
        }
    }
}