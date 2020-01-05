//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity middleMouseEntity { get { return GetGroup(InputMatcher.MiddleMouse).GetSingleEntity(); } }

    public bool isMiddleMouse {
        get { return middleMouseEntity != null; }
        set {
            var entity = middleMouseEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isMiddleMouse = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly MiddleMouseComponent middleMouseComponent = new MiddleMouseComponent();

    public bool isMiddleMouse {
        get { return HasComponent(InputComponentsLookup.MiddleMouse); }
        set {
            if (value != isMiddleMouse) {
                var index = InputComponentsLookup.MiddleMouse;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : middleMouseComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherMiddleMouse;

    public static Entitas.IMatcher<InputEntity> MiddleMouse {
        get {
            if (_matcherMiddleMouse == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.MiddleMouse);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherMiddleMouse = matcher;
            }

            return _matcherMiddleMouse;
        }
    }
}
