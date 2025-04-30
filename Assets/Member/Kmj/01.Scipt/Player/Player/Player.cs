using System;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : Entity
{
    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    [SerializeField] private StateDataSO[] stateDatas;

    public CharacterMovement _movement { get; private set; }

    public EntityAnimatorTrigger _triggerCompo { get; private set; }

    public bool _isSkilling { get;  set; }
    private EntityStateMachine _stateMachine;
    public PlayerAttackCompo _attackCompo { get; private set; }
    public EntitySkillCompo _skillCompo { get; private set; }
    public float rollingVelocity = 12f;

    public bool isDoingFollow { get; set; }
    [field : SerializeField] public MousePlayer _soul { get; private set; }

    [SerializeField] private LayerMask _whatIsEnemey;

    
    protected override void Awake()
    {
        base.Awake();
         _stateMachine = new EntityStateMachine(this,stateDatas);
        _skillCompo = GetCompo<EntitySkillCompo>();
        _movement = GetCompo<CharacterMovement>();
        _triggerCompo = GetCompo<EntityAnimatorTrigger>();
 
        PlayerInput.OnRollingPressed += HandleRollingPressed;
    }


    private void HandleRollingPressed()
    {
        ChangeState("ROLLING");
    }

    protected override void OnDestroy()
    {
        PlayerInput.OnRollingPressed -= HandleRollingPressed;
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

    protected override void HandleStun()
    {
        
    }

    public void PlayerDie()
    {
        _isSkilling = true;
        ChangeState("DIE");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & _whatIsEnemey) != 0 && isDoingFollow)
        {
            ChangeState("STRONGATTACK");
        }
    }
}
