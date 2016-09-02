using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatr.Core.Interfaces;

namespace Mediatr.ConsoleTest.Actions.DeleteItemCommand
{
    public class DeleteItemCommandPostHandler : ICommandPostHandler<DeleteItemCommand, DeleteItemCommandResult>
    {
        public void Handle(DeleteItemCommand viewModel, DeleteItemCommandResult entity)
        {
            
            // savechanges

            entity.Description += "Modified from post handler";
        }
    }
}
