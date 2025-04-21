using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Phase2Check", story: "Check to [WolfEnemy]", category: "Conditions", id: "5e63f57dadaf91e05b996ebd05dd4e94")]
public partial class Phase2CheckCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Wolf> WolfEnemy;

    public override bool IsTrue()
    {
        if (WolfEnemy.Value.IsPhase2)
        {
            return true;
        }
        return false;
    }
}
