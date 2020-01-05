using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EndCameraDragSystem : ReactiveSystem<InputEntity>
{
    readonly GameContext _context;

    public EndCameraDragSystem(Contexts contexts) : base(contexts.input)
    {
        _context = contexts.game;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        GameEntity mainCameraEntity = _context.mainCameraEntity;
        if (mainCameraEntity.hasCameraDrag)
            mainCameraEntity.RemoveCameraDrag();
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseUp;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.MiddleMouse, InputMatcher.MouseUp));
    }
}
