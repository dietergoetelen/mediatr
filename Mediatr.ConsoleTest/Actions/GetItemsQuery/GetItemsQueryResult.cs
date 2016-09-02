using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Mediatr.Core.Interfaces;

namespace Mediatr.ConsoleTest.Actions.GetItemsQuery
{
    public class GetItemsQueryResult : IQueryResult
    {
        public int Id { get; set; }

    }
}
