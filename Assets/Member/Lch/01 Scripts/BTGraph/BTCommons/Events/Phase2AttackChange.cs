using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Phase2AttackChange")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Phase2AttackChange", message: "Change to [Phase]", category: "Events", id: "b4a7360d277951dc0d916277cc4b310b")]
public partial class Phase2AttackChange : EventChannelBase
{
    public delegate void Phase2AttackChangeEventHandler(WolfPhase2AttackEnum Phase);
    public event Phase2AttackChangeEventHandler Event; 

    public void SendEventMessage(WolfPhase2AttackEnum Phase)
    {
        Event?.Invoke(Phase);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<WolfPhase2AttackEnum> PhaseBlackboardVariable = messageData[0] as BlackboardVariable<WolfPhase2AttackEnum>;
        var Phase = PhaseBlackboardVariable != null ? PhaseBlackboardVariable.Value : default(WolfPhase2AttackEnum);

        Event?.Invoke(Phase);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        Phase2AttackChangeEventHandler del = (Phase) =>
        {
            BlackboardVariable<WolfPhase2AttackEnum> var0 = vars[0] as BlackboardVariable<WolfPhase2AttackEnum>;
            if(var0 != null)
                var0.Value = Phase;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as Phase2AttackChangeEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as Phase2AttackChangeEventHandler;
    }
}

