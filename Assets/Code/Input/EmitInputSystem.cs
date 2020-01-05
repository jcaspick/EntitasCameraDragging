using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    readonly InputContext _context;
    private InputEntity _middleMouseEntity;
    private InputEntity _mousePositionEntity;

    public EmitInputSystem(Contexts contexts)
    {
        _context = contexts.input;
    }

    public void Initialize()
    {
        _context.isMiddleMouse = true;
        _middleMouseEntity = _context.middleMouseEntity;

        Vector2 mouseScreenPosition = Input.mousePosition;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        _context.ReplaceMousePosition(mouseWorldPosition, mouseScreenPosition);
        _mousePositionEntity = _context.mousePositionEntity;
    }

    public void Execute()
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        _context.ReplaceMousePosition(mouseWorldPosition, mouseScreenPosition);

        if (Input.GetMouseButtonDown(2))
            _middleMouseEntity.ReplaceMouseDown(mouseWorldPosition, mouseScreenPosition);

        if (Input.GetMouseButtonUp(2))
            _middleMouseEntity.ReplaceMouseUp(mouseWorldPosition, mouseScreenPosition);

        if (Input.GetMouseButton(2))
            _middleMouseEntity.ReplaceMouseHeld(mouseWorldPosition, mouseScreenPosition);
    }
}