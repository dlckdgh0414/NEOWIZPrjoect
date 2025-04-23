using Unity.Behavior;
using UnityEngine;

public abstract class BTBoss : Enemy
{
    private BossStateChangeEvent _stateChannel;
    private EntityFeedbackData _feedbackData;
    protected BlackboardVariable<BTBossState> _state;
    protected Collider _bossCollider;
    public bool IsHit = false;
    public bool IsStun = false;

    protected override void Start()
    {
        BlackboardVariable<BossStateChangeEvent> stateChannelVariable =
            GetBlackboardVariable<BossStateChangeEvent>("BossStateChangeEvent");
        _stateChannel = stateChannelVariable.Value;
        Debug.Assert(_stateChannel != null, $"StateChannel variable is null {gameObject.name}");

        _bossCollider = GetComponent<Collider>();

        _state = GetBlackboardVariable<BTBossState>("BossState");
    }
    protected override void HandleHit()
    {
        if (IsDead) return;

        IsHit = true;

        if (_state.Value == BTBossState.STUN || _state.Value == BTBossState.HIT) return;

        if (_feedbackData.IsLastStopHit)
        {
            _stateChannel.SendEventMessage(BTBossState.HIT);
        }
        else if (_state.Value == BTBossState.CHASE)
        {
            _stateChannel.SendEventMessage(BTBossState.IDLE);
        }
    }

    protected override void HandleDead()
    {
        gameObject.layer = DeadBodyLayer;
        _bossCollider.enabled = false;
        IsDead = true;
        _stateChannel.SendEventMessage(BTBossState.DEAD);
    }

    protected override void HandleStun()
    {
        if (IsStun)
        {
            _stateChannel.SendEventMessage(BTBossState.STUN);
        }
    }
}
