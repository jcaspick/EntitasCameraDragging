using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    private Contexts _contexts;

    void Start()
    {
        _contexts = Contexts.sharedInstance;

        _systems = new Feature("Systems")
            .Add(new EmitInputSystem(_contexts))
            .Add(new InitMainCameraSystem(_contexts))
            .Add(new MoveCameraSystem(_contexts))
            .Add(new BeginCameraDragSystem(_contexts))
            .Add(new CameraDragSystem(_contexts))
            .Add(new EndCameraDragSystem(_contexts));
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
