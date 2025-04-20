using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsPhaseing", story: "Change to [IsPhaseStart]", category: "Action", id: "42c43aed58edb4ac326ca1c6d5d42a12")]
public partial class IsPhaseingAction : Action
{
    [SerializeReference] public BlackboardVariable<bool> IsPhaseStart;

    protected override Status OnStart()
    {
        IsPhaseStart.Value = false;
        return Status.Success;
    }
}

