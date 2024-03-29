//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

public partial class GameEntity {

    public ColorComponent Color { get { return (ColorComponent)GetComponent(GameComponentsLookup.Colour); } }
    public bool hasColour { get { return HasComponent(GameComponentsLookup.Colour); } }

    public void AddColour(int newValue) {
        var index = GameComponentsLookup.Colour;
        var component = (ColorComponent)CreateComponent(index, typeof(ColorComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceColour(int newValue) {
        var index = GameComponentsLookup.Colour;
        var component = (ColorComponent)CreateComponent(index, typeof(ColorComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveColour() {
        RemoveComponent(GameComponentsLookup.Colour);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherColour;

    public static Entitas.IMatcher<GameEntity> Colour {
        get {
            if (_matcherColour == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Colour);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherColour = matcher;
            }
           return _matcherColour;
        }
    }
}
