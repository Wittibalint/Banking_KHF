﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Authentication
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
