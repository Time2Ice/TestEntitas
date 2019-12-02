using Entitas;
using UnityEngine;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    private readonly InputContext _context;
    private InputEntity _leftMouseEntity;
  
    public EmitInputSystem(Contexts contexts)
    {
        _context = contexts.input;
    }

    public void Initialize()
    {
        // initialize the unique entities that will hold the mouse button data
        _context.isLeftMouse = true;
        _leftMouseEntity = _context.leftMouseEntity;
    }

    public void Execute()
    {
        // mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            _leftMouseEntity.ReplaceMouseDown(mousePosition);
        }
        
        _leftMouseEntity.ReplaceMousePosition(mousePosition);
    }
}