using System;
using System.Linq;
using System.Reflection;
using Mediatr.Core.Interfaces;

namespace Mediatr.Core
{
    public class QueryPipeline : IQueryPipeline
    {
        private readonly IQueryViewModel _model;
        private bool _isValid = true;

        public QueryPipeline(IQueryViewModel model)
        {
            _model = model;
        }

        public IQueryPipeline Validate<T>() where T : IValidatorFactory, new()
        {
            var type = typeof(T);
            var method = type.GetMethod("Handle");
            var validator = new T();
            var isValid = Convert.ToBoolean(method.Invoke(validator, new object[1]
            {
                    _model
            }));

            if (!isValid)
            {
                _isValid = false;
            }

            return this;
        }

        public TResult Execute<THandler, TResult>() where THandler : IQueryHandler where TResult : IQueryResult, new()
        {
            var type = typeof(THandler);
            var method = type.GetMethod("Handle");

            Type iHandler = (from t in Assembly.GetAssembly(typeof(THandler)).GetExportedTypes()
                             where !t.IsInterface && !t.IsAbstract
                             where typeof(THandler).IsAssignableFrom(t)
                             select t).ToArray().First();

            var instance = Activator.CreateInstance(iHandler);

            return (TResult)method.Invoke(instance, new object[1]
            {
                _model
            });
        }
    }
}
