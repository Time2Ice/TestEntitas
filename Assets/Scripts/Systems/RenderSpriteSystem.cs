using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderSpriteSystem : ReactiveSystem<GameEntity>
{
    public RenderSpriteSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            GameObject go = e.view.GameObject;
            SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
            BoxCollider2D c = go.GetComponent<BoxCollider2D>();
            if (sr == null) sr = go.AddComponent<SpriteRenderer>();
            if (c == null) c = go.AddComponent<BoxCollider2D>();
            sr.sprite = Resources.Load<Sprite>(e.sprite.Name);
            c.size = sr.sprite.bounds.size;
            e.view.SpriteRenderer = sr;
        }
    }
}