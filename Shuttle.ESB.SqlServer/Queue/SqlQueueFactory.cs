using System;
using Shuttle.Core.Data;
using Shuttle.Core.Infrastructure;
using Shuttle.ESB.Core;

namespace Shuttle.ESB.SqlServer
{
	public class SqlQueueFactory : IQueueFactory
	{
		private readonly IScriptProvider scriptProvider;
		private readonly IDatabaseConnectionFactory databaseConnectionFactory;
		private readonly IDatabaseGateway databaseGateway;

		public SqlQueueFactory()
		{
			scriptProvider = ScriptProvider.Default();
			databaseConnectionFactory = DatabaseConnectionFactory.Default();
			databaseGateway = DatabaseGateway.Default();
		}

		public string Scheme
		{
			get { return SqlUriParser.SCHEME; }
		}

		public IQueue Create(Uri uri)
		{
			Guard.AgainstNull(uri, "uri");

			return new SqlQueue(uri, scriptProvider, databaseConnectionFactory, databaseGateway);
		}

		public bool CanCreate(Uri uri)
		{
			Guard.AgainstNull(uri, "uri");

			return Scheme.Equals(uri.Scheme, StringComparison.InvariantCultureIgnoreCase);
		}
	}
}