namespace SharpDB.Core;

public class QueryHandler(DataStore dataStore)
{
	public Task Handle(DatabaseQuery query)
	{
		return Task.CompletedTask;
	}
}
