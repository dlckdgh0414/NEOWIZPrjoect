using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Blade.Enemies;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RoatateToTarget", story: "[Self] rotate To [Target]", category: "Action", id: "3d806b184fb86e269f26b9d132b13263")]
public partial class RoatateToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMovement> Movement;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<Transform> Self;
    Quaternion _targetRotation;


    protected override Status OnUpdate()
    {
        if (LookTargetSmothly())
        {
            return Status.Success;
        }
        return Status.Running;
    }

    private bool LookTargetSmothly()
    {
        Quaternion targetRot = Movement.Value.LookAtTarget(Target.Value.position);
        const float angleThreshold = 5f;
        return Quaternion.Angle(targetRot, Self.Value.rotation) < angleThreshold;
    }

    protected override void OnEnd()
    {
    }
}

