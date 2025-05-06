using Unity.Behavior;
using UnityEngine;

public class Wolf : BTBoss
{
    [HideInInspector] public float RushDamge = 0;
    private Phase1AttackEvents _phaseChange;
    private Phase2AttackChange _phase2Change;

    private WolfPhase1AttackEnum _phase1Enum;
    private WolfPhase2AttackEnum _phase2Enum;

    [SerializeField] private Pillar[] pillars;

    public bool IsPhase2;

    [SerializeField] private float rushTimer;
    private float _currentTimer;
    private float _hollwingHp;
    private float _lastHollwing;
    public bool IsRush  = false;
    public bool IsRushStop  = false;
    private bool _iSRushTimerStart = true;
    private bool _isPhaseing = true;
    [SerializeField] private float hollwingTime;
    private EntityHealth _health;
    public Animator mainAnim;

    protected override void Awake()
    {
        base.Awake();
        _health = GetCompo<EntityHealth>();
        mainAnim = GetComponentInChildren<Animator>();
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
        BlackboardVariable<WolfPhase1AttackEnum> phase1Enum 
            = GetBlackboardVariable<WolfPhase1AttackEnum>("AttackEnum");
        _phase1Enum = phase1Enum.Value;
        BlackboardVariable<WolfPhase2AttackEnum> phase2Enum
            = GetBlackboardVariable<WolfPhase2AttackEnum>("Phase2AttackChange");
        _phase2Enum = phase2Enum.Value;
        BlackboardVariable<bool> IsPhase2CheckVariable
            = GetBlackboardVariable<bool>("IsPhase2");
        BlackboardVariable<bool> IsPhasingCheckVariable =
            GetBlackboardVariable<bool>("IsPhaseing");
        IsPhase2 = IsPhase2CheckVariable.Value;
        _isPhaseing = IsPhasingCheckVariable.Value;
        _hollwingHp = _health.maxHealth - 15f;
        _lastHollwing = Time.time;
    }

    private void Update()
    {
        if(_health.maxHealth / 2 >= _health.currentHealth)
        {
            IsPhase2 = true;
        }
        if (_isPhaseing)
        {
            if (_iSRushTimerStart)
            {
                RushTimer();
            }
            HowlingTimer();
        }
    }
    private void HowlingTimer()
    {
        if (_health.currentHealth <= _hollwingHp)
        {
            if (Time.time >= _lastHollwing + hollwingTime)
            {
                if (_state.Value == BTBossState.STUN
             || _state.Value == BTBossState.HIT || _phase2Enum == WolfPhase2AttackEnum.Parrying)
                {
                    return;
                }
                if (IsPhase2 && _phase2Enum != WolfPhase2AttackEnum.Rush_Upgrade)
                {
                    _phase2Change.SendEventMessage(WolfPhase2AttackEnum.Howling);
                }
                else if (_phase1Enum != WolfPhase1AttackEnum.Rush)
                {
                    _phaseChange.SendEventMessage(WolfPhase1AttackEnum.Howling);
                }
                _lastHollwing = Time.time;
                _hollwingHp -= 15f;
            }
              
        }
    }

    public void OffPillar()
    {

        foreach (Pillar pillar in pillars)
        {
            pillar.OffPillar();
        }
    }

    #region TestAttack

    [ContextMenu("TestHoling")]
    private void TestHowling()
    {
        _phaseChange.SendEventMessage(WolfPhase1AttackEnum.Howling);
    }

    [ContextMenu("Rush")]
    private void TestRush()
    {
        _phaseChange.SendEventMessage(WolfPhase1AttackEnum.Rush);

    }

    [ContextMenu("Parrying")]
    private void TestParrying()
    {
        _phase2Change.SendEventMessage(WolfPhase2AttackEnum.Parrying);
    }

    #endregion
    private void RushTimer()
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= rushTimer)
        {
            if (_state.Value == BTBossState.STUN
                || _state.Value == BTBossState.HIT)
            {
                return;
            }

            if (IsPhase2 && _phase2Enum != WolfPhase2AttackEnum.Howling && _phase2Enum != WolfPhase2AttackEnum.Parrying)
            {
                _phase2Change.SendEventMessage(WolfPhase2AttackEnum.Rush_Upgrade);
                _currentTimer = 0;
            }
            else if(_phase1Enum != WolfPhase1AttackEnum.Howling)
            {
                _phaseChange.SendEventMessage(WolfPhase1AttackEnum.Rush);
                _currentTimer = 0;
            }
           _iSRushTimerStart = false;
            IsStun = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsRush)
        {
            Debug.Log(collision.gameObject.name);
            if(collision.gameObject.TryGetComponent(out Player player))
            {
                IDamgable damgable = player.GetComponentInChildren<IDamgable>();
                damgable.ApplyDamage(RushDamge, false, 0, this);
            }
            if (collision.gameObject.CompareTag("Wall"))
            {
                Debug.Log("dfdf");
                 IsRushStop = true;
                _iSRushTimerStart = true;
                IsStun = false;
            }
        }
            
    }
}
