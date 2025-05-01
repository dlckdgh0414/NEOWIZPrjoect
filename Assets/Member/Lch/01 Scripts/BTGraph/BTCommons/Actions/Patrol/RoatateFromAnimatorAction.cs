using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Blade.Enemies;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RoatateFromAnimator", story: "[Movement] rotate to [Target] with [Trigger]", category: "Action", id: "980a6f975f742a00b44673cc640c74e4")]
public partial class RoatateFromAnimatorAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMovement> Movement;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<EntityAnimatorTrigger> Trigger;

    private bool _isRotate = false;

    protected override Status OnStart()
    {
        Trigger.Value.OnManualRotationTrigger += HandleManualRotation;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (_isRotate)
        {
            Movement.Value.LookAtTarget(Target.Value.position);
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
        Trigger.Value.OnManualRotationTrigger -= HandleManualRotation;
    }

    private void HandleManualRotation(bool isRotate) => _isRotate = isRotate;
}

