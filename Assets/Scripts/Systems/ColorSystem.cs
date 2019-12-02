using System.Collections.Generic;
using System.Linq;
using Entitas;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    public class ColorSystem:ReactiveSystem<InputEntity>
        {
            private readonly IGroup<GameEntity> _gameObjects;
            private readonly Colors _colors;

            public ColorSystem(Contexts contexts, Colors colors): base(contexts.input)
            {
                _gameObjects = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Sprite, GameMatcher.View, GameMatcher.Colour));
                _colors = colors;
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
                        ChangeColour(obj);                      
                    }
                }
            }

            private void ChangeColour(GameEntity entity)
            {
                entity.ReplaceColour(entity.Color.Value+1);
                foreach (var multiplicity in _colors.Multiplicities.OrderByDescending(m=>m.Multiplicities.Length))
                {
                    if (multiplicity.Multiplicities.Where(m=>entity.Color.Value % m == 0).Count()==multiplicity.Multiplicities.Length)
                    {
                        entity.view.SpriteRenderer.color = multiplicity.Colour;
                        return;
                    }                            
                }
                entity.view.SpriteRenderer.color = _colors.Default;     
            }

        }
    } 
   