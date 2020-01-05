using UnityEngine;
using Entitas;

[Input]
public class MouseDownComponent : IComponent
{
    public Vector2 worldPosition;
    public Vector2 screenPosition;
}