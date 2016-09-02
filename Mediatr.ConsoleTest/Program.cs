using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatr.ConsoleTest.Actions.DeleteItemCommand;
using Mediatr.ConsoleTest.Actions.GetItemsQuery;
using Mediatr.Core;

namespace Mediatr.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new Mediator();

            var result = mediator
                .Query(new GetItemsQueryViewModel() { Description = "Hello" })
                .Validate<GetItemsQueryQueryValidator>()
                .Execute<GetItemsQueryHandler, GetItemsQueryResult>();

            var commandResult = mediator
                .Command(new DeleteItemCommand()
                {
                    Description = "Langer dan 10 characters om te testen :)"
                })
                .PreHandler<DeleteItemCommandPreHandler>()
                .PostHandler<DeleteItemCommandPostHandler>()
                .Validate<DeleteItemCommandQueryValidator>()
                .Execute<DeleteItemCommandHandler, DeleteItemCommandResult>();

            Console.WriteLine(commandResult.IsDeleted.ToString());
            Console.WriteLine(commandResult.Description);
            Console.WriteLine(result.Id.ToString());
            Console.ReadLine();
        }
    }
}
