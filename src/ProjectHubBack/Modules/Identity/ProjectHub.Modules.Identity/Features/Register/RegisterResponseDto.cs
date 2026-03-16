using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHub.Modules.Identity.Features.Register;

public record RegisterResponseDto
{
    public Guid UserId { get; init; }
}
