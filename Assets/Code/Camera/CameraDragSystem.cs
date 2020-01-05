using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CameraDragSystem : IExecuteSystem, IInitializeSystem
{
    readonly GameContext _game;
    readonly InputContext _input;

    private GameEntity _mainCameraEntity;
    readonly IGroup<GameEntity> _cameraDrag;

    public CameraDragSystem(Contexts contexts)
    {
        _game = contexts.game;
        _input = contexts.input;
        _cameraDrag = contexts.game.GetGroup(GameMatcher.CameraDrag);
    }

    public void Initialize()
    {
        _mainCameraEntity = _game.mainCameraEntity;
    }

    public void Execute()
    {
        foreach (GameEntity e in _cameraDrag.GetEntities())
        {
            Vector2 mouseOffset = _input.mousePositionEntity.mousePosition.screenPosition -
                e.cameraDrag.mouseStartPosition;
            Vector2 cameraPosition = e.cameraDrag.camStartPosition - mouseOffset * 0.02f;
            _mainCameraEntity.ReplacePosition(cameraPosition.x, cameraPosition.y);
        }
    }
}
