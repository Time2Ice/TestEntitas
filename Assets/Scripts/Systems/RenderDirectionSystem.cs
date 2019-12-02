using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderDirectionSystem : ReactiveSystem<GameEntity>
{
    public RenderDirectionSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Direction);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDirection && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            float ang = e.direction.Value;
            e.view.GameObject.transform.rotation = Quaternion.AngleAxis(ang - 90, Vector3.forward);
        }
    }
}