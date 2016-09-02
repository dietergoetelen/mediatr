namespace Mediatr.Core.Interfaces
{
    public interface ICommandPipeline
    {
        ICommandPipeline Validate<T>() where T : IValidatorFactory, new();

        ICommandPipeline PreHandler<T>() where T : ICommandHandler, new();

        ICommandPipeline PostHandler<T>() where T : ICommandHandler, new();

        TResult Execute<THandler, TResult>() where THandler : ICommandHandler where TResult : ICommandResult, new();
    }
}