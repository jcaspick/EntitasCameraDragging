using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique]
public class MousePositionComponent : IComponent
{
    public Vector2 worldPosition;
    public Vector2 screenPosition;
}