using Microsoft.AspNetCore.Diagnostics;
using ProjectHub.API.Helpers;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace ProjectHub.API.ExceptionHandlers.Base;

internal abstract class BaseExceptionHandler<TException> : IExceptionHandler
    where TException : Exception
{
    private const string UnhandledException =
     "Unhandled exception occurred. Path: {Path}, Method: {Method}, StatusCode: {StatusCode}, ExceptionType: {ExceptionType}, Message: {Message}, StackTrace: {StackTrace}, TraceId: {TraceId}, User: {User}, InnerException: {InnerException}, Source: {Source}";
    protected readonly IProblemDetailsService ProblemDetailsService;
    protected readonly Microsoft.Extensions.Logging.ILogger Logger;
    protected BaseExceptionHandler(
        IProblemDetailsService problemDetailsService,
        Microsoft.Extensions.Logging.ILogger logger
    )
    {
        ProblemDetailsService = problemDetailsService;
        Logger = logger;
    }

    protected abstract int StatusCode { get; }
    protected abstract string Title { get; }
    protected abstract string Detail { get; }
    protected virtual LogLevel LogLevel => LogLevel.Error;

    public virtual async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        if (exception is not TException)
        {
            return false;
        }
        if (Logger.IsEnabled(LogLevel))
        {
            Logger.Log(
            LogLevel,
            exception,
            UnhandledException,
            httpContext.Request.Path,
            httpContext.Request.Method,
            StatusCode,
            exception.GetType().Name,
            exception.Message,
            exception.StackTrace,
            httpContext.TraceIdentifier,
            httpContext.User?.Identity?.Name ?? "Anonymous",
            exception.InnerException?.ToString(),
            exception.Source);
        }

        httpContext.Response.StatusCode = StatusCode;

        var problemDetails = new MvcProblemDetails
        {
            Status = StatusCode,
            Type = ProblemDetailsUriHelper.GetProblemTypeUri(StatusCode),
            Title = Title,
            Detail = Detail,
            Extensions =
            {
                ["traceId"] = httpContext.TraceIdentifier
            }
        };

        return await ProblemDetailsService.TryWriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = problemDetails,
            }
        );
    }
}