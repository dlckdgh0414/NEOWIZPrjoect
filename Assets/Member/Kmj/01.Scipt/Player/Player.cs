using UnityEngine;

public class Player : Entity
{
    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    [SerializeField] private StateDataSO[] stateDatas;

    public CharacterMovement _movement { get; private set; }
    private EntityStateMachine _stateMachine;

    public EntitySkillCompo _skillCompo { get; private set; }

    protected override void Awake()
    {
        base.Awake();

         _stateMachine = new EntityStateMachine(this,stateDatas);
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
}
