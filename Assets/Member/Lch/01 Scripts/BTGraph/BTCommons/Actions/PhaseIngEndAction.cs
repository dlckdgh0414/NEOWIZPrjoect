using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PhaseIngEnd", story: "Is [Phasing] End", category: "Action", id: "8dedab0d0d33e0f75df2f8372d9abfbc")]
public partial class PhaseIngEndAction : Action
{
    [SerializeReference] public BlackboardVariable<bool> Phasing;
    protected override Status OnStart()
    {
        Phasing.Value = true;
        return Status.Success;
    }
}

