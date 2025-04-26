using Blade.Enemies;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "StopMove", story: "[Movement] stop set to [newValue]", category: "Action", id: "fcab52ff130f71b00dae8c49494e1f4b")]
public partial class StopMoveAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMovement> Movement;
    [SerializeReference] public BlackboardVariable<bool> NewValue;

    protected override Status OnStart()
    {
        Movement.Value.SetStop(NewValue.Value);
        return Status.Success;
    }
}

