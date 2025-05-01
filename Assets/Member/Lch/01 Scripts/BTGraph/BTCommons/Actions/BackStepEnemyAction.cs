using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BackStepEnemy", story: "Back Step to [Target] in [Self] to [Power] with [Mover]", category: "Action", id: "abb055f8565e7413c2040291c92557eb")]
public partial class BackStepEnemyAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<BTEnemy> Self;
    [SerializeReference] public BlackboardVariable<float> Power;
    protected override Status OnStart()
    {
        Self.Value.BackStepEnemy(Target.Value,Power.Value,Self.Value.transform);
        return Status.Success;
    }
}

