﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CatalogController : ControllerBase
    {

        public string Get()
        {
            return "Data";
        }
       
    }
}
