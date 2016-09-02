using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatr.Core.Interfaces;

namespace Mediatr.ConsoleTest.Actions.DeleteItemCommand
{
    public class DeleteItemCommandPreHandler : ICommandPreHandler<DeleteItemCommand>
    {
        public void Handle(DeleteItemCommand viewModel)
        {
            if (viewModel.Description.Length > 10)
            {
                viewModel.Description = viewModel.Description.Substring(0, 10);
            }
        }
    }
}
