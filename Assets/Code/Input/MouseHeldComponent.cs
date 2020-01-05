﻿using UnityEngine;
using Entitas;

[Input]
public class MouseHeldComponent : IComponent
{
    public Vector2 worldPosition;
    public Vector2 screenPosition;
}