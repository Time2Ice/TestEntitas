using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _moves;
    private readonly IGroup<GameEntity> _moveCompletes;
    private const float _speed = 4f;

    public MoveSystem(Contexts contexts)
    {
        _moves = contexts.game.GetGroup(GameMatcher.Move);
       
    }

    public void Execute()
    {
        foreach (GameEntity e in _moves.GetEntities())
        {
           var newPosition= Vector2.Lerp(e.position.Value, e.move.Target, _speed * Time.deltaTime);
            Vector2 dir = e.move.Target - e.position.Value;
            e.ReplacePosition(newPosition);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            e.ReplaceDirection(angle);           
        }
    }
}