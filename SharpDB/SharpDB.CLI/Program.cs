using SharpDB.Core;
using SharpDB.Core.Enums;

Console.WriteLine("=== Welcome to SharpDB ===");
Console.Write("Enter the path to the database file (e.g. sharpdb.dat): ");
var dbFile = Console.ReadLine();

if (string.IsNullOrWhiteSpace(dbFile))
{
	Console.WriteLine("The file path cannot be empty.");
	return;
}

var dataStore = new DataStore(dbFile);
var queryHandler = new QueryHandler(dataStore);

Console.WriteLine($"Database opened successfully: {dbFile}");
Console.WriteLine("Available commands: SET <key> <value> | GET <key> | EXIT");
Console.WriteLine();

while (true)
{
	Console.Write("DB> ");
	var input = Console.ReadLine();
	if (string.IsNullOrWhiteSpace(input)) continue;

	if (input.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
	{
		break;
	}

	var parts = input.Split(' ', 3);
	var commandStr = parts[0].ToUpper();

	try
	{
		if (commandStr == "SET" && parts.Length == 3)
		{
			var query = new DatabaseQuery
			{
				OperationType = OperationType.SET,
				Key = parts[1],
				Value = parts[2]
			};

			var result = queryHandler.Handle(query);
			Console.WriteLine(result);
		}
		else if (commandStr == "GET" && parts.Length == 2)
		{
			var query = new DatabaseQuery
			{
				OperationType = OperationType.GET,
				Key = parts[1]
			};

			var result = queryHandler.Handle(query);
			Console.WriteLine(result != null ? result : "(nil)");
		}
		else
		{
			Console.WriteLine("Unknown command or invalid syntax. Use: SET <key> <value> or GET <key>");
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Execution error: {ex.Message}");
	}
}