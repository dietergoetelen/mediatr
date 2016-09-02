using Mediatr.Core.Interfaces;

namespace Mediatr.ConsoleTest.Actions.GetItemsQuery
{
    public class GetItemsQueryQueryValidator : IQueryValidator<GetItemsQueryViewModel>
    {
        public bool Handle(GetItemsQueryViewModel viewModel)
        {
            return viewModel.Description.Length > 0;
        }
    }
}