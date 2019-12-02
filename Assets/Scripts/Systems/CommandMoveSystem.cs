using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEditor;
using UnityEngine;

public class CommandMoveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _gameContext;
    private readonly IGroup<GameEntity> _movers;

    public CommandMoveSystem(Contexts contexts) : base(contexts.input)
    {
        _movers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Mover, GameMatcher.Move));
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MousePosition));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMousePosition;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (InputEntity e in entities)
        {

            GameEntity[] movers = _movers.GetEntities();
            if (movers.Length <= 0) return;
            foreach (var mover in movers)
            {
                mover.ReplaceMove(e.mousePosition.Position);
            }
        }
    }
}