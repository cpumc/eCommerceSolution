using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Core.DTO
{
    public record  RegisterRequest(string? Email,string? Password, string? PersonName,GenderOptions Gender);
   
}
