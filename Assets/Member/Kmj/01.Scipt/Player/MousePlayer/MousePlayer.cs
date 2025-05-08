using System;
using Member.Kmj._01.Scipt.Player.MousePlayer;
using UnityEngine;

public class MousePlayer : Entity
{
    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    [SerializeField] private StateDataSO[] stateDatas;

    private EntityStateMachine _stateMachine;

    public MouseBarrerSkill _barrerSkill { get; private set;}
   
  //  public EntitySkillCompo _skillCompo { get; private set; }
    public MouseAttackCompo _attackCompo { get; private set; }
    public MouseMoveCompo _moveCompo { get; private set; }
    [field: SerializeField] public LayerMask _whatIsEnemy { get; private set; }
    
    [field: SerializeField] public LayerMask _whatIsSoulEnemy {get; private set;}
    
    public AttributeType _typeCompo { get; private set; }

    public Player player;

    [field: SerializeField] public Rigidbody rbCompo;

    public bool _isSkilling { get;  set; } = false;

    public bool isUseDashSkill { get; set; } = false;
    
    
    public bool isUseSheld { get; set; }



    protected override void Awake()
    {
        base.Awake();
        rbCompo = GetComponentInChildren<Rigidbody>();
    //    _skillCompo = GetCompo<EntitySkillCompo>();
        _barrerSkill = GetComponentInChildren<MouseBarrerSkill>();
        _attackCompo = GetComponentInChildren<MouseAttackCompo>();
        _moveCompo = GetCompo<MouseMoveCompo>();
        _stateMachine = new EntityStateMachine(this, stateDatas);
        _typeCompo = GetComponentInChildren<AttributeType>();
        _isSkilling = false;
    }

    private void Start()
    {
        _stateMachine.ChangeState("IDLE");
    }

    private void Update()
    {
        _stateMachine.UpdateStateMachine();
    }

    public Vector3 MoveToMousePosition(MousePlayer _player)
    {
        Vector3 targetPos = PlayerInput.GetWorldPosition(out RaycastHit hitInfo);
        return targetPos;
    }


    public void ChangeState(string newStateName) => _stateMachine.ChangeState(newStateName);


    public void LookAtMouse()
    {
        Vector3 targetPos = PlayerInput.GetWorldPosition(out RaycastHit hitInfo);
        Vector3 direction = targetPos - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction.normalized);
    }
    protected override void HandleHit()
    {
        
    }

    protected override void HandleDead()
    {
        
    }

    protected override void HandleStun()
    {
        throw new NotImplementedException();
    }
}
