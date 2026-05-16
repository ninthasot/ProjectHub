using ProjectHub.API.ExceptionHandlers.Base;

namespace ProjectHub.API.ExceptionHandlers;

internal sealed class GlobalExceptionHandler : BaseExceptionHandler<Exception>
{
    public GlobalExceptionHandler(
        IProblemDetailsService problemDetailsService,
        ILogger<GlobalExceptionHandler> logger
    )
        : base(problemDetailsService, logger) { }

    protected override int StatusCode => StatusCodes.Status500InternalServerError;
    protected override string Title => "Internal Server Error";
    protected override string Detail => "An unexpected error occurred.";
}