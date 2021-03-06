namespace Shuttle.ESB.SqlServer
{
	public interface ISqlServerConfiguration
	{
		string SubscriptionManagerConnectionStringName { get; }
		string IdempotenceServiceConnectionStringName { get; }
		string ScriptFolder { get; }
	}
}