using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindTarget", story: "[self] set [targets] from finder", category: "Action", id: "f24d43abd5c639704598d1d213055747")]
public partial class FindTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Enemy> Self;
    [SerializeReference] public BlackboardVariable<List<GameObject>> Targets;
    protected override Status OnStart()
    {
        foreach(var target in  Self.Value.PlayerFinder.Targets)
        {
            Targets.Value.Add(target.gameObject);
        }
        return Status.Success;
    }
}

