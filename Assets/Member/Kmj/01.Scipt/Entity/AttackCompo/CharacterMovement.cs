
using UnityEngine;

public class CharacterMovement : MonoBehaviour, IEntityComponet
{
    [SerializeField] private float moveSpeed = 1f, gravity = -9.81f
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float rotationSpeed = 8f;
    private float originMoveSpeed;

    public bool CanManualMovement { get; set; } = true;
    private Vector3 _autoMovement;

    public bool IsGround => characterController.isGrounded;

    private Vector3 _velocity;
    public Vector3 Velocity => _velocity;

    private float _verticalVelocity;
    private Vector3 _movementDirection;

    private Entity _entity;

    [SerializeField] private StatSO _moveSpeedStat;

    public void Initialize(Entity entity)
    {
        _entity = entity;
    }
    public void SetMovementDirection(Vector2 movementInput)
    {
        _movementDirection = new Vector3(movementInput.x, 0, movementInput.y).normalized;
    }

    public void Run(float runSpeed)
    {
        originMoveSpeed = moveSpeed;
        moveSpeed = runSpeed;
    }

    public void Walk()
    {
        moveSpeed = originMoveSpeed;
    }

    private void FixedUpdate()
    {
        CalculateMovement();
        Move();
    }

    private void Move()
    {
        characterController.Move(_velocity * Time.fixedDeltaTime);
    }

    public void StopImmediately()
    {
        _movementDirection = Vector3.zero;
    }

    private void CalculateMovement()
    {
        if (CanManualMovement)
        {
            _velocity = Quaternion.Euler(0, 0, 0) * _movementDirection;
            _velocity *= moveSpeed;
        }
        else
        {
            _velocity += _autoMovement * Time.fixedDeltaTime;
        }

        if (_velocity.magnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(_velocity);
            Transform parent = _entity.transform;
            parent.rotation = Quaternion.Lerp(parent.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
        }
    }

    public void SetAutoMovement(Vector3 autoMovement)
        => _autoMovement = autoMovement;

}
