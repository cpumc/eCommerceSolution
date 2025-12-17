using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Core.DTO
{
    public record LoginRequest(string? Email, string? Password);
    
}
