using Systems;
using ScriptableObjects;

public sealed class InputSystems : Feature
{
    public InputSystems(Contexts contexts, Colors colors) : base("Input Systems")
    {
        Add(new EmitInputSystem(contexts));
        Add(new CommandMoveSystem(contexts));
        Add(new MoveStateSystem(contexts));
        Add(new ColorSystem(contexts, colors));
    }         
}