namespace Mediatr.Core.Interfaces
{
    public interface IMediator<out TQueryPipeline, out TCommandPipeline> where TQueryPipeline : IQueryPipeline where TCommandPipeline : ICommandPipeline
    {
        TQueryPipeline Query<T>(T query) where T : IQueryViewModel, new();

        ICommandPipeline Command<T>(T command) where T : ICommandAction, new();
    }
}
