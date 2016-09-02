namespace Mediatr.Core.Interfaces
{
    public interface IQueryPipeline
    {
        IQueryPipeline Validate<T>() where T : IValidatorFactory, new();

        TResult Execute<THandler, TResult>() where THandler : IQueryHandler where TResult : IQueryResult, new();
    }
}
