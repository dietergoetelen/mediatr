using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatr.Core.Interfaces;

namespace Mediatr.ConsoleTest.Actions.GetItemsQuery
{
    public class GetItemsQueryHandler : IHandle<GetItemsQueryViewModel, GetItemsQueryResult>
    {
        public GetItemsQueryResult Handle(GetItemsQueryViewModel viewModel)
        {
            return new GetItemsQueryResult()
            {
                Id = 15
            };
        }
    }
}
