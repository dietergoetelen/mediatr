namespace Mediatr.Core.Interfaces
{
    public interface IHandle<in TViewModel, out TResult> : IHandler where TViewModel : IViewModel
        where TResult : IResult
    {
        TResult Handle(TViewModel viewModel);
    }

    public interface ICommandPreHandler<in TViewModel> : IHandler where TViewModel : IViewModel
    {
        void Handle(TViewModel viewModel);
    }

    public interface ICommandPostHandler<in TViewModel, in TResult> : IHandler where TViewModel : IViewModel 
    {
        void Handle(TViewModel viewModel, TResult entity);
    }
}