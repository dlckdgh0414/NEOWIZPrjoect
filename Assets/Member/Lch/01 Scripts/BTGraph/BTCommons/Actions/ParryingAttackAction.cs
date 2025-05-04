using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ParryingAttack", story: "[parryingAttack] to [Target]", category: "Action", id: "54bf055f2c111fa99ef2a02982d16ff8")]
public partial class ParryingAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<WolfParryingAttackCompo> parryingAttack;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        parryingAttack.Value.ParryingCollider(Target.Value);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (parryingAttack.Value.ParryingCount == 5)
        {
            parryingAttack.Value.ParryingEnd();
             return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

