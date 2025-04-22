using Blade.Enemies;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RoatateToTarget", story: "[Self] rotate To [Target] in [Secend]", category: "Action", id: "3d806b184fb86e269f26b9d132b13263")]
public partial class RoatateToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Enemy> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<float> Secend;

    private const float _rotationSpeed = 20f;
    private float _startTime;
    protected override Status OnStart()
    {
        _startTime = Time.time;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        LookTargetSmothly();
        if(Time.time - _startTime >= Secend.Value)
            return Status.Success;
        return Status.Running;
    }

    private void LookTargetSmothly()
    {
        Transform trm = Self.Value.transform;
        Vector3 direction = Target.Value.position - trm.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);
        trm.rotation = Quaternion.Lerp(Self.Value.transform.rotation,targetRotation,_rotationSpeed * Time.deltaTime);
    }

    protected override void OnEnd()
    {
    }
}

