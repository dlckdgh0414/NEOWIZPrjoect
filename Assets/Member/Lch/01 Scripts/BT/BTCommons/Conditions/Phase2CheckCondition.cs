using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Phase2Check", story: "Check to [Phase2]", category: "Conditions", id: "5e63f57dadaf91e05b996ebd05dd4e94")]
public partial class Phase2CheckCondition : Condition
{
    [SerializeReference] public BlackboardVariable<bool> Phase2;

    public override bool IsTrue()
    {
        if (Phase2)
        {
            return true;
        }
        return false;
    }
}
