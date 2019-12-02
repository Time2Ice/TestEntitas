using Entitas;
using ScriptableObjects;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] 
    private Colors _colors;
    private Entitas.Systems _systems;
    private Contexts _contexts;

    private void Start()
    {
        _contexts = Contexts.sharedInstance;  
        _systems = CreateSystems(_contexts);
        _systems.Initialize();        
        GameEntity mover = _contexts.game.CreateEntity();
        mover.isMover = true;
        mover.AddPosition(Vector2.zero);
        mover.AddDirection(Random.Range(0,360));
        mover.AddSprite("Bee");
        mover.AddColour(0);
        
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private  Entitas.Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new InputSystems(contexts, _colors))
            .Add(new MovementSystems(contexts))
            .Add(new ViewSystems(contexts));
    }
}