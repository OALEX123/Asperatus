using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Shukratar.Shared.Diagnostics
{
    public class TraceDbCommandInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuting(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }

        public void NonQueryExecuted(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void ReaderExecuting(
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }

        public void ReaderExecuted(
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void ScalarExecuting(
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }

        public void ScalarExecuted(
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        private static void LogIfNonAsync(
            IDbCommand command, DbInterceptionContext interceptionContext)
        {
            if (interceptionContext.IsAsync) return;

            var @params = string.Join(",",
                command.Parameters.Cast<SqlParameter>().Select(x => $"{x.ParameterName} = {x.Value}"));

            Trace.TraceInformation("Non-async command used: {0}", command.CommandText);
            Debug.WriteLine(@params);
        }

        private static void LogIfError<TResult>(
            IDbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (interceptionContext.Exception != null)
            {
                Trace.TraceInformation("Command {0} failed with exception {1}",
                    command.CommandText, interceptionContext.Exception);
            }
        }
    }
}