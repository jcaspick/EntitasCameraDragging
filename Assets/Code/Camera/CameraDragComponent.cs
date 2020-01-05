using UnityEngine;
using Entitas;

[Game]
public class CameraDragComponent : IComponent
{
    public Vector2 camStartPosition;
    public Vector2 mouseStartPosition;
}
