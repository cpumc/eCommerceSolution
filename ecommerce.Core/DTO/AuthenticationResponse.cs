using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Core.DTO
{
    public record AuthenticationResponse(Guid UserId, string? Email, string? PersonName, string? Gender, string? token, bool sucess)
    {
        public AuthenticationResponse() : this(default, default, default, default, default, default)
        {
        }
    };

}
