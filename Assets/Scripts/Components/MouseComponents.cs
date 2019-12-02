
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input, Unique]
public class LeftMouseComponent : IComponent
{
}

[Input]
public class MouseDownComponent : IComponent
{
    public Vector2 Position;
}

[Input]
public class MousePositionComponent : IComponent
{
    public Vector2 Position;
}

