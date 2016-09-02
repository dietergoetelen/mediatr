using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatr.Core.Interfaces;

namespace Mediatr.ConsoleTest.Actions.DeleteItemCommand
{
    public class DeleteItemCommand : ICommandAction
    {

        public string Description { get; set; }

    }
}
