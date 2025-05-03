using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RushToTarget", story: "Rush to [Target] in [Mover] to [MaxDistance] with [WolfEnemy]", category: "Action", id: "3ed726b875e18edb8f50276e74fad935")]
public partial class RushToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<EnemyMover> Mover;
    [SerializeReference] public BlackboardVariable<float> MaxDistance;
    [SerializeReference] public BlackboardVariable<Wolf> WolfEnemy;
    [SerializeReference] public BlackboardVariable<LayerMask> WhatIsWall;

    protected override Status OnStart()
    {
        WolfEnemy.Value.IsRush = true;
        Mover.Value.Speed *= 2f;
        if (Physics.Raycast(WolfEnemy.Value.transform.position, WolfEnemy.Value.transform.forward, out RaycastHit hitInfo, MaxDistance.Value, WhatIsWall.Value))
        {
            //_moveDir = hitInfo.point - transform.position;
            //_moveDir.y = 0;
            //_moveDir.Normalize();
        }
        return Status.Success;
    }
}

