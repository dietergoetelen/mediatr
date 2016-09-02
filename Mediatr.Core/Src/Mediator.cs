using Mediatr.Core.Interfaces;

namespace Mediatr.Core
{
    public class Mediator : IMediator<IQueryPipeline, ICommandPipeline>
    {
        public IQueryPipeline Query<T>(T query) where T : IQueryViewModel, new()
        {
            return new QueryPipeline(query);
        }

        public ICommandPipeline Command<T>(T command) where T : ICommandAction, new()
        {
            return new CommandPipeline(command);
        }
    }
}
