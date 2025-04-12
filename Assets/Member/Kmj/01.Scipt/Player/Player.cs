using System;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : Entity
{
    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    [SerializeField] private StateDataSO[] stateDatas;

    public CharacterMovement _movement { get; private set; }

    public bool _isSkilling { get;  set; }
    private EntityStateMachine _stateMachine;
    public PlayerAttackCompo _attackCompo { get; private set; }
    public EntitySkillCompo _skillCompo { get; private set; }
    public float rollingVelocity = 12f;

    protected override void Awake()
    {
        base.Awake();
         _stateMachine = new EntityStateMachine(this,stateDatas);
        _skillCompo = GetCompo<EntitySkillCompo>();
        PlayerInput.OnStrongAttackPressed += HandleStrongAttackPressed;
        PlayerInput.OnRollingPressed += HandleRollingPressed;
    }


    private void HandleRollingPressed()
    {
        ChangeState("ROLLING");
    }

    protected override void OnDestroy()
    {
        PlayerInput.OnStrongAttackPressed -= HandleStrongAttackPressed;
        PlayerInput.OnRollingPressed -= HandleRollingPressed;
    }
    private void HandleStrongAttackPressed()
    {
        if (_skillCompo.CanUseSkill("StrongAttack") && !_isSkilling)
        {
            ChangeState("STRONGATTACK");
            _skillCompo.CurrentTimeClear("StrongAttack");
            _isSkilling = true;
        }
        else
            return;
    }

    private void Start()
    {
        _stateMachine.ChangeState("IDLE");
    }

    private void Update()
    {
        _stateMachine.UpdateStateMachine();
    }


    public void ChangeState(string newStateName) => _stateMachine.ChangeState(newStateName);

    protected override void HandleHit()
    {
        
    }

    protected override void HandleDead()
    {
        
    }
}
