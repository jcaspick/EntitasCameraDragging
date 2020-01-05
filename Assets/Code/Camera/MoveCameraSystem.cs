using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveCameraSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;

    public MoveCameraSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        GameEntity e = entities.SingleEntity();
        e.mainCamera.gameObject.transform.position = new Vector3(e.position.x, e.position.y, -10);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.MainCamera, GameMatcher.Position));
    }
}
