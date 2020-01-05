using UnityEngine;
using Entitas;

public class InitMainCameraSystem : IInitializeSystem
{
    readonly GameContext _context;

    public InitMainCameraSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        GameObject mainCamera = Camera.main.gameObject;
        _context.ReplaceMainCamera(mainCamera);
        _context.mainCameraEntity.AddPosition(mainCamera.transform.position.x, mainCamera.transform.position.y);
    }
}
