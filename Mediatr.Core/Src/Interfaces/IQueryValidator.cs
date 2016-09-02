namespace Mediatr.Core.Interfaces
{
    public interface IValidatorFactory
    {
    }

    public interface IQueryValidator<in TViewModel> : IValidatorFactory where TViewModel : IQueryViewModel
    {
        bool Handle(TViewModel viewModel);
    }

    public interface ICommandValidator<in TViewModel> : IValidatorFactory where TViewModel : ICommandAction
    {
        bool Handle(TViewModel viewModel);
    }
}
