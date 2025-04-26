using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using static Unity.Behavior.Node;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckPlayers", story: "distance between [Self] in [Target]", category: "Conditions", id: "7f2a206d95e3acda3c8c4c989e1e1939")]
public partial class CheckPlayersCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Enemy> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    public override bool IsTrue()
    {
        float distance = Vector3.Distance(Self.Value.transform.position, Target.Value.position);
        return distance < Self.Value.delectRange;
    }
}
