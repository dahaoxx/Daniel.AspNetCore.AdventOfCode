namespace Five.MovingCrates.Models;

internal readonly record struct MoveCommand(IReadOnlyList<string> Command)
{
	public int Amount => int.Parse(Command[1]);
	public int TargetStackIndex => int.Parse(Command[3]) - 1;
	public int DestinationStackIndex => int.Parse(Command[5]) - 1;
	
}
