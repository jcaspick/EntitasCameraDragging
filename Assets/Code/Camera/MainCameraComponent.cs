﻿using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MainCameraComponent : IComponent
{
    public GameObject gameObject;
}
