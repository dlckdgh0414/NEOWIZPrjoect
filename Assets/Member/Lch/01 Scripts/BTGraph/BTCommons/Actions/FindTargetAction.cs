using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindTarget", story: "[self] set [target] from finder", category: "Action", id: "f24d43abd5c639704598d1d213055747")]
public partial class FindTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Enemy> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    protected override Status OnStart()
    {
        Target.Value = Self.Value.PlayerFinder.Targets.transform;
        return Status.Success;
    }
}

