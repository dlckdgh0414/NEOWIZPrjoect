using UnityEngine;

public class MousePlayer : Entity
{
    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    [SerializeField] private StateDataSO[] stateDatas;

    [field: SerializeField] public Rigidbody rbCompo;
    private EntityStateMachine _stateMachine;
    [field: SerializeField] public LayerMask _whatIsEnemy { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        rbCompo = GetComponentInChildren<Rigidbody>();
        _stateMachine = new EntityStateMachine(this, stateDatas);
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

}
