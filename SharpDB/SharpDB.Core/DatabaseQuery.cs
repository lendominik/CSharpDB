using SharpDB.Core.Enums;

namespace SharpDB.Core;

public class DatabaseQuery
{
	public OperationType OperationType { get; set; }
	public string Key { get; set; } = string.Empty;
	public string? Value { get; set; }
}
