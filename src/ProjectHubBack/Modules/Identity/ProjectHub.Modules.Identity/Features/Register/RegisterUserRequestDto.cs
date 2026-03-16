using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHub.Modules.Identity.Features.Register;

public record RegisterUserRequestDto
{
    public string Email { get; set; } = string.Empty;
}
