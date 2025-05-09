
using System;
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

    public GameObject Cam1;
    public GameObject Cam2;

    public bool IsQuarterView { get; set; } = true;

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
        Cam2.SetActive(false);
        moveSpeed = _stat.GetStat(_moveSpeedStat).Value;
        rollingSpeed = _stat.GetStat(_rollingSpeedStat).Value;
    }


    public void SetMove(float XMove, float ZMove)
    {
        _movementDirection.x = XMove;
        _movementDirection.z = ZMove;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsQuarterView)
        {
            IsQuarterView = true;
            Cam2.SetActive(false);
            Cam1.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && IsQuarterView)
        {
            IsQuarterView = false;
            Cam1.SetActive(false);
            Cam2.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        CalculateMovement();
        
      

        if(IsQuarterView)
            _rbcompo.linearVelocity = new Vector3(_velocity.x, _rbcompo.linearVelocity.y, _velocity.z);
        else
        {
            _rbcompo.linearVelocity = new Vector3(transform.TransformDirection(_velocity).x,
                _rbcompo.linearVelocity.y, transform.TransformDirection(_velocity).z);
        }
    }

    public void MoveToEntity(Vector3 target)
    {
        _entity.transform.position =
           Vector3.MoveTowards(_entity.transform.position, target, 60 * Time.deltaTime);
    }

    public void LookAt(Vector3 entity)
    {
        Vector3 targetPos = entity;
        Vector3 direction = targetPos - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction.normalized);
    }
    private void CalculateMovement()
    {
        if (CanMove)
        {

            if (CanManualMovement && !IsQuarterView)
            {
                _velocity = Quaternion.Euler(0, 0, 0) * _movementDirection;
                _velocity *= moveSpeed;
            }
            else if (CanManualMovement && IsQuarterView)
            {
                _velocity = Quaternion.Euler(0, -45, 0) * _movementDirection;
                _velocity *= moveSpeed;
            }
            
            else
            {
                _velocity += _autoMovement * Time.fixedDeltaTime;
            }

            if(IsRolling && !IsQuarterView)
            {
                _velocity = Quaternion.Euler(0, 0f, 0) * _movementDirection;
                _velocity *= rollingSpeed;
            }
            else if(IsRolling && IsQuarterView)
            {
                _velocity = Quaternion.Euler(0, -45f, 0) * _movementDirection;
                _velocity *= rollingSpeed;
            }


            if (_velocity.magnitude > 0 && IsQuarterView)
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
