using System;
using System.IO;
using EFProviderWrapperToolkit;
using EFTracingProvider;

namespace EntityFrameworkModel
{
	public partial class LoggingObjectContext : System.Data.Objects.ObjectContext
    {
        private TextWriter m_log;

		public LoggingObjectContext(string a_strConnection, string a_strName)
            : base(EntityConnectionWrapperUtils.CreateEntityConnectionWithWrappers(
					a_strConnection,
					"EFTracingProvider"), a_strName)
        {
        }

        #region Tracing Extensions

        private EFTracingConnection TracingConnection
        {
            get { return this.UnwrapConnection<EFTracingConnection>(); }
        }

        public event EventHandler<CommandExecutionEventArgs> CommandExecuting
        {
            add { this.TracingConnection.CommandExecuting += value; }
            remove { this.TracingConnection.CommandExecuting -= value; }
        }

        public event EventHandler<CommandExecutionEventArgs> CommandFinished
        {
            add { this.TracingConnection.CommandFinished += value; }
            remove { this.TracingConnection.CommandFinished -= value; }
        }

        public event EventHandler<CommandExecutionEventArgs> CommandFailed
        {
            add { this.TracingConnection.CommandFailed += value; }
            remove { this.TracingConnection.CommandFailed -= value; }
        }

        private void AppendToLog(object sender, CommandExecutionEventArgs e)
        {
            if (this.m_log != null)
            {
                this.m_log.WriteLine(e.ToTraceString().TrimEnd());
                this.m_log.WriteLine();
            }
        }

        public TextWriter Log
        {
            get { return this.m_log; }
            set
            {
                if ((this.m_log != null) != (value != null))
                {
                    if (value == null)
                    {
                        CommandExecuting -= AppendToLog;
                    }
                    else
                    {
                        CommandExecuting += AppendToLog;
                    }
                }

                this.m_log = value;
            }
        }


        #endregion
    }

}
