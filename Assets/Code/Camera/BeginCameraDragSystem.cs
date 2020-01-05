using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class BeginCameraDragSystem : ReactiveSystem<InputEntity>
{
    readonly GameContext _context;

    public BeginCameraDragSystem(Contexts contexts) : base(contexts.input)
    {
        _context = contexts.game;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        GameEntity mainCameraEntity = _context.mainCameraEntity;
        Vector2 cameraStart = new Vector2(mainCameraEntity.position.x, mainCameraEntity.position.y);
        mainCameraEntity.AddCameraDrag(cameraStart, entities.SingleEntity().mouseDown.screenPosition);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.MiddleMouse, InputMatcher.MouseDown));
    }
}
