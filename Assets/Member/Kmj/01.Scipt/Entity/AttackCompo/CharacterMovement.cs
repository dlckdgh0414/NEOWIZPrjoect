
using UnityEngine;

public class CharacterMovement : MonoBehaviour, IEntityComponet
{
    [field: SerializeField] public Rigidbody _rbcompo { get; private set; }
    [SerializeField] private float rotationSpeed = 8f;
    private float moveSpeed;
    private float rollingSpeed;
    public bool CanMove { get; set; } = true;
    private Vector3 _autoMovement;

    public Vector3 _velocity { get; set; }
    public Vector3 Velocity => _velocity;

    public bool CanManualMovement { get; set; } = true;

    public bool IsRolling { get; set; } = false;
    private Player _entity;

    [SerializeField] private StatSO _moveSpeedStat;
    [SerializeField] private StatSO _rollingSpeedStat;
    [SerializeField] private EntityStat _stat;
    private Vector3 _movementDirection;

    public void Initialize(Entity entity)
    {
        _entity = entity as Player;
    }

    private void Start()
    {
        moveSpeed = _stat.GetStat(_moveSpeedStat).Value;
        rollingSpeed = _stat.GetStat(_rollingSpeedStat).Value;
    }


    public void SetMove(float XMove, float ZMove)
    {
        _movementDirection.x = XMove;
        _movementDirection.z = ZMove;
    }

    private void FixedUpdate()
    {
        CalculateMovement();


        _rbcompo.linearVelocity = _velocity;
    }

    private void CalculateMovement()
    {
        if (CanMove)
        {

            if (CanManualMovement)
            {
                _velocity = Quaternion.Euler(0, -90f, 0) * _movementDirection;
                _velocity *= moveSpeed;
            }
            else
            {
                _velocity += _autoMovement * Time.fixedDeltaTime;
            }

            if(IsRolling)
            {
                _velocity = Quaternion.Euler(0, -90f, 0) * _movementDirection;
                _velocity *= rollingSpeed;
            }


            if (_velocity.magnitude > 0)
            {
                var targetRotation = Quaternion.LookRotation(_velocity);
                targetRotation.z = 0;
                Transform parent = _entity.transform;
                parent.rotation = Quaternion.Lerp(parent.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
            }
        }
    }

    public void StopImmediately()
    {
        _velocity = Vector3.zero;
    }
}
