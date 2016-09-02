using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatr.Core.Interfaces;

namespace Mediatr.ConsoleTest.Actions.DeleteItemCommand
{
    public class DeleteItemCommandHandler : IHandle<DeleteItemCommand, DeleteItemCommandResult>
    {
        public DeleteItemCommandResult Handle(DeleteItemCommand viewModel)
        {
            return new DeleteItemCommandResult()
            {
                IsDeleted = true,
                Description = viewModel.Description
            };
        }
    }
}
