﻿using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);    
         bool StoreTokenAsync(User user, string token);
    }
}
