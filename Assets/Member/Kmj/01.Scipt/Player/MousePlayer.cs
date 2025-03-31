using System;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MousePlayer : Entity
{
    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    [SerializeField] private StateDataSO[] stateDatas;

    [field: SerializeField] public Rigidbody rbCompo;
    private EntityStateMachine _stateMachine;
    [field: SerializeField] public LayerMask _whatIsEnemy { get; private set; }

    public bool _isSkilling { get;  set; } = false;
    public EntitySkillCompo _skillCompo { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        rbCompo = GetComponentInChildren<Rigidbody>();
        _skillCompo = GetCompo<EntitySkillCompo>();
        _stateMachine = new EntityStateMachine(this, stateDatas);
        PlayerInput.OnSheldPressd += HandleSheldPressed;
        _isSkilling = false;
    }

    protected override void OnDestroy()
    {
        PlayerInput.OnSheldPressd -= HandleSheldPressed;
    }
    private void HandleSheldPressed()
    {
        if (_skillCompo.CanUseSkill("Sheld") && !_isSkilling)
        {
            ChangeState("SHELD");
            _skillCompo.CurrentTimeClear("Sheld");
            _isSkilling = true;
        }
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
        Vector3 targetPos = PlayerInput.GetWorldPosition();
        targetPos.y = transform.position.y;
        return targetPos;
    }


    public void ChangeState(string newStateName) => _stateMachine.ChangeState(newStateName);

    protected override void HandleHit()
    {
        
    }

    protected override void HandleDead()
    {
        
    }
}
