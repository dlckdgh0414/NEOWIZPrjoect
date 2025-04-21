using Unity.Behavior;
using UnityEngine;

public class Wolf : BTBoss
{
    [HideInInspector] public float RushDamge = 0;
    private Phase1AttackEvents _phaseChange;
    private Phase2AttackChange _phase2Change;

    private WolfPhase1AttackEnum _phase1Enum;
    private WolfPhase2AttackEnum _phase2Enum;

    public bool IsPhase2 { get; set; }

    [SerializeField] private float rushTimer;
    private float _currentTimer;
    private float _hollwingHp;
    private float _lastHollwing;
    public bool IsRush {get; set;} = false;
    public bool IsRushStop { get; set; } = false;
    private bool _iSRushTimerStart = true;
    [SerializeField] private float hollwingTime;
    private EntityHealth _health;

    protected override void Awake()
    {
        base.Awake();
        _health = GetCompo<EntityHealth>();
    }

    protected override void Start()
    {
        base.Start();
        BlackboardVariable <Phase1AttackEvents> phase1ChannelVariable =
           GetBlackboardVariable<Phase1AttackEvents>("Phase1AttackChange");
        _phaseChange = phase1ChannelVariable.Value;
        Debug.Assert(_phaseChange != null, $"StateChannel variable is null {gameObject.name}");
        BlackboardVariable <Phase2AttackChange> phase2ChannelVariable =
          GetBlackboardVariable<Phase2AttackChange>("Phase2Attack");
        _phase2Change = phase2ChannelVariable.Value;
        _phase1Enum = GetBlackboardVariable<WolfPhase1AttackEnum>("AttackEnum");
        _phase2Enum = GetBlackboardVariable<WolfPhase2AttackEnum>("Phase2Attack");
        IsPhase2 = GetBlackboardVariable<bool>("IsPhase2");
        _hollwingHp = _health.maxHealth - 15f;
        _lastHollwing = Time.time;
    }

    private void Update()
    {
        if(_health.maxHealth / 2 >= _health.currentHealth)
        {
            IsPhase2 = true;
        }
        if (_iSRushTimerStart)
        {
            RushTimer();
        }
        HowlingTimer();
    }
    private void HowlingTimer()
    {
        if (_health.currentHealth == _hollwingHp)
        {
            if (Time.time >= _lastHollwing + hollwingTime)
            {
                if (_phase1Enum == WolfPhase1AttackEnum.Rush
               || _state.Value == BTBossState.STUN
               || _state.Value == BTBossState.HIT
               || _phase2Enum == WolfPhase2AttackEnum.Rush_Upgrade
               || _phase2Enum == WolfPhase2AttackEnum.Catch)
                {
                    return;
                }
                if (IsPhase2)
                {
                    _phase2Change.SendEventMessage(WolfPhase2AttackEnum.Howling);
                    _lastHollwing = Time.time;
                    _hollwingHp -= 15f;
                }
                else
                {
                    _phaseChange.SendEventMessage(WolfPhase1AttackEnum.Howling);
                    _lastHollwing = Time.time;
                    _hollwingHp -= 15f;
                }
            }
        }
    }

    private void RushTimer()
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= rushTimer)
        {
            if (_phase1Enum == WolfPhase1AttackEnum.Howling 
                ||_state.Value == BTBossState.STUN 
                ||_state.Value == BTBossState.HIT 
                || _phase2Enum == WolfPhase2AttackEnum.Howling
                || _phase2Enum == WolfPhase2AttackEnum.Catch)
            {
                return;
            }

            if (IsPhase2)
            {
                _phase2Change.SendEventMessage(WolfPhase2AttackEnum.Rush_Upgrade);
                _currentTimer = 0;
            }
            else
            {
                _phaseChange.SendEventMessage(WolfPhase1AttackEnum.Rush);
                _currentTimer = 0;
            }
           _iSRushTimerStart = false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsRush)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (collision.gameObject.TryGetComponent(out IDamgable damgable))
                {
                    damgable.ApplyDamage(RushDamge, false, 0, this);
                }
            }
            if (collision.gameObject.CompareTag("Wall"))
            {
                 IsRushStop = true;
                _iSRushTimerStart = true;
            }
        }
            
    }
}
