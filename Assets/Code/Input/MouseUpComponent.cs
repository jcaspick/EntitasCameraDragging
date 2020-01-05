using UnityEngine;
using Entitas;

[Input]
public class MouseUpComponent : IComponent
{
    public Vector2 worldPosition;
    public Vector2 screenPosition;
}