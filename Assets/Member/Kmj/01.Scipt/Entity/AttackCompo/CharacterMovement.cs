
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterMovement : MonoBehaviour, IEntityComponet
{
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float rotationSpeed = 8f;
    private float originMoveSpeed;

    private float moveSpeed;
    public bool CanManualMovement { get; set; } = true;
    public bool CanMove { get; set; } = true;
    private Vector3 _autoMovement;

    public bool IsGround => characterController.isGrounded;

    private Vector3 _velocity;
    public Vector3 Velocity => _velocity;

    private float _verticalVelocity;
    private Vector3 _movementDirection;

    private Entity _entity;

    [SerializeField] private StatSO _moveSpeedStat;
    [SerializeField] private EntityStat _stat;

    public void Initialize(Entity entity)
    {
        _entity = entity;
    }

    private void Start()
    {
        moveSpeed = _stat.GetStat(_moveSpeedStat).Value;
    }
    public void SetMovementDirection(Vector2 movementInput)
    {
        _movementDirection = new Vector3(movementInput.x, 0, movementInput.y).normalized;
    }

    private void Update()
    {
        SetTransformXChange();
    }

    private void FixedUpdate()
    {
        CalculateMovement();
        ApplyGravity();
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
        if (CanMove)
        {
            if (CanManualMovement)
            {
                _velocity = Quaternion.Euler(0, -45f, 0) * _movementDirection;
                _velocity *= moveSpeed;
            }
            else
            {
                _velocity += _autoMovement * Time.fixedDeltaTime;
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

    private void ApplyGravity()
    {
        if (IsGround && _verticalVelocity < 0)
        {
            _verticalVelocity = -0.03f;
        }
        else
        {
            _verticalVelocity += gravity * Time.fixedDeltaTime;
        }

        _velocity.y = _verticalVelocity;
    }

    public void SetAutoMovement(Vector3 autoMovement)
        => _autoMovement = autoMovement;
    private void SetTransformXChange()
    {
        Quaternion quaternion = _entity.transform.rotation;

        quaternion.x = 0;

        _entity.transform.rotation = quaternion;
    }
}
