using System;
using System.Linq;
using System.Reflection;
using Mediatr.Core.Interfaces;

namespace Mediatr.Core
{
    public class CommandPipeline : ICommandPipeline
    {
        private readonly ICommandAction _commandAction;
        private Func<ICommandAction, bool> _validatorFunc;
        private Action<ICommandAction> _preHandler;
        private Action<ICommandAction, object> _postHandler;

        public CommandPipeline(ICommandAction commandAction)
        {
            _commandAction = commandAction;
        }

        public ICommandPipeline Validate<T>() where T : IValidatorFactory, new()
        {
            _validatorFunc = action =>
            {
                var result = InvokeHandle<T>(_commandAction);
                return Convert.ToBoolean(result);
            };

            return this;
        }

        private object InvokeHandle<T>(params object[] actions) where T : new()
        {
            var type = typeof(T);
            var method = type.GetMethod("Handle");
            var instance = new T();

            return method.Invoke(instance, actions);
        }

        public ICommandPipeline PreHandler<T>() where T : ICommandHandler, new()
        {
            _preHandler = action =>
            {
                InvokeHandle<T>(_commandAction);
            };

            return this;
        }

        public ICommandPipeline PostHandler<T>() where T : ICommandHandler, new()
        {
            _postHandler = (action, result)=>
            {
                InvokeHandle<T>(_commandAction, result);
            };

            return this;
        }

        public TResult Execute<THandler, TResult>() where THandler : ICommandHandler where TResult : ICommandResult, new()
        {
            bool isValid = true;

            if (_validatorFunc != null)
            {
                isValid = _validatorFunc(_commandAction);
            }

            ICommandResult result = new TResult();

            if (isValid)
            {
                _preHandler?.Invoke(_commandAction);

                var type = typeof(THandler);
                var method = type.GetMethod("Handle");

                Type iHandler = (from t in Assembly.GetAssembly(typeof(THandler)).GetExportedTypes()
                                 where !t.IsInterface && !t.IsAbstract
                                 where typeof(THandler).IsAssignableFrom(t)
                                 select t).ToArray().First();

                var instance = Activator.CreateInstance(iHandler);
                result = (TResult)method.Invoke(instance, new object[1]
                {
                    _commandAction
                });

                _postHandler?.Invoke(_commandAction, result);
            }

            return (TResult)result;
        }
    }
}
