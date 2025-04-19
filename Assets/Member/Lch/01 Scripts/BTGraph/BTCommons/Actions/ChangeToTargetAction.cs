using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChangeToTarget", story: "[Target] to [LastAttacker]", category: "Action", id: "5f211e5abe83cb2dd34176b19a2e4b0f")]
public partial class ChangeToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<EntityFeedbackData> LastAttacker;

    protected override Status OnStart()
    {
        
        if(LastAttacker.Value.LastEntityWhoHit != null)
        {
            Target.Value = LastAttacker.Value.LastEntityWhoHit.transform;
            return Status.Success;
        }
        return Status.Success;
    }
}

