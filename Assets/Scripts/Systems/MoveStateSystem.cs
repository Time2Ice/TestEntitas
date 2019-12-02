using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class MoveStateSystem: ReactiveSystem<InputEntity>
    {
        private readonly IGroup<GameEntity> _gameObjects;

        public MoveStateSystem(Contexts contexts): base(contexts.input)
        {
            _gameObjects = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Mover, GameMatcher.View));
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseDown));
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasMouseDown;
        }

        protected  override void Execute(List<InputEntity> entities)
        {
            foreach (InputEntity e in entities)
            {
                var hit = Physics2D.Raycast(e.mouseDown.Position, Vector2.zero, 100);
                if (hit.collider != null)
                {
                    var go = hit.collider.transform.gameObject;
                    var obj = _gameObjects.GetEntities().FirstOrDefault(o => o.view.GameObject == go);
                    if (obj.hasMove) obj.RemoveMove();
                    else obj.AddMove(hit.collider.transform.position);
                }
            }
        }

    }
}