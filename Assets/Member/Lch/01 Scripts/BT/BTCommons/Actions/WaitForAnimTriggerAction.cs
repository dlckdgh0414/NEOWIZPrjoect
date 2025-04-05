using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WaitForAnimTrigger", story: "Wait for [AnimTrigger] end", category: "Action", id: "681d7c6155a64cf43f5392f845c24e64")]
public partial class WaitForAnimTriggerAction : Action
{
    [SerializeReference] public BlackboardVariable<EntityAnimatorTrigger> AnimTrigger;

    private bool _animationEndTrigger;

    protected override Status OnStart()
    {
        _animationEndTrigger = false;
        AnimTrigger.Value.OnAnimationEndTrigger += HandleAnimationEnd;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return _animationEndTrigger ? Status.Success : Status.Running;
    }

    protected override void OnEnd()
    {
        AnimTrigger.Value.OnAnimationEndTrigger -= HandleAnimationEnd;
    }

    private void HandleAnimationEnd()
    {
        _animationEndTrigger = true;
    }
}

