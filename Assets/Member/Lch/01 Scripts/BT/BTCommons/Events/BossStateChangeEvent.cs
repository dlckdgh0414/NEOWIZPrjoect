using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/BossStateChangeEvent")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "BossStateChangeEvent", message: "boss state change to [newState]", category: "Events", id: "ddef45d8a81de5fa25b0f954d0d1adf4")]
public partial class BossStateChangeEvent : EventChannelBase
{
    public delegate void BossStateChangeEventEventHandler(BTBossState newState);
    public event BossStateChangeEventEventHandler Event; 

    public void SendEventMessage(BTBossState newState)
    {
        Event?.Invoke(newState);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<BTBossState> newStateBlackboardVariable = messageData[0] as BlackboardVariable<BTBossState>;
        var newState = newStateBlackboardVariable != null ? newStateBlackboardVariable.Value : default(BTBossState);

        Event?.Invoke(newState);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        BossStateChangeEventEventHandler del = (newState) =>
        {
            BlackboardVariable<BTBossState> var0 = vars[0] as BlackboardVariable<BTBossState>;
            if(var0 != null)
                var0.Value = newState;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as BossStateChangeEventEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as BossStateChangeEventEventHandler;
    }
}

