using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackCompo : MonoBehaviour, IEntityComponet
{
    public AttackDataSO[] attackDataList;
    [SerializeField] private DamageCaster damageCast;

    [SerializeField] private float comboWindow;
    private Entity _entity;
    private EntityAnimator _entityAnimator;

    [SerializeField] private LayerMask _whatIsEnemy;

    private readonly int _attackSpeedHash = Animator.StringToHash("ATTACK_SPEED");
    private readonly int _comboCounterHash = Animator.StringToHash("COMBO_COUNTER");

    [SerializeField] private StatSO _atkDamage;
    [SerializeField] private EntityStat _stat;

    public float atkDamage { get; set; }
    private EntityAnimatorTrigger _triggerCompo;

    private float _attackSpeed = 0.3f;
    private float _lastAttackTime;
    private float attackHoldTime = 0f;

    [SerializeField] private Vector3 _boxsize;

    [field: SerializeField] public float MaxHoldTime { get; set; } 

    public bool useMouseDirection = false;

    public int ComboCounter { get; set; } = 0;

    [field: SerializeField] public Transform swingTrm;
    private Player _player;
        
    private Coroutine _chargeRoutine;

    public float AttackSpeed
    {
        get => _attackSpeed;
        set
        {
            _attackSpeed = value;
            _entityAnimator.SetParam(_attackSpeedHash, _attackSpeed);
        }
    }

    public void Initialize(Entity entity)
    {
        _entity = entity;
        _player = entity as Player;
        _entityAnimator = entity.GetCompo<EntityAnimator>();
        AttackSpeed = 0.7f;
        damageCast.InitCaster(_entity);
        _triggerCompo = entity.GetCompo<EntityAnimatorTrigger>();
        _triggerCompo.OnAttackTriggerEnd += HandleAttackTrigger;
        _triggerCompo.OnSwingAttackTrigger += HandleSwing;
        _player.PlayerInput.OnChargeAttackPressed += StartCharge;
        _player.PlayerInput.OnChargeAttackCanceled += StopCharge;
    }

    private void HandleAttackTrigger()
    {
        Vector2 knockbackForce = new Vector2(6, 6);
     //   bool success = damageCast.CastDamage(atkDamage);

        Collider[] collider = Physics.OverlapBox(transform.position, _boxsize,
            Quaternion.identity, _whatIsEnemy);
        foreach (var Obj in collider)
        {
            if (Obj.TryGetComponent(out IDamgable damage))
            {
                 Debug.Log("공격됨");
                 damage.ApplyDamage(10, true, 0, _player);
                 CameraManager.Instance.ShakeCamera(atkDamage / 2, AttackSpeed / 2);
            }
            else
            {
                print("왔는데 없음");
            }
        }
    }
    
    public void Attack()
    {
        bool comboCounterOver = ComboCounter > 1;
        bool comboWindowExhaust = Time.time >= _lastAttackTime + comboWindow;
        if (comboCounterOver || comboWindowExhaust)
        {
            ComboCounter = 0;
        }
        _entityAnimator.SetParam(_comboCounterHash, ComboCounter);
    }

    private void StartCharge()
    {
        if (_chargeRoutine == null)
            _chargeRoutine = StartCoroutine(HoldAttackCoroutine());
    }

    private void StopCharge()
    {
        if (_chargeRoutine != null)
        {
            StopCoroutine(_chargeRoutine);
            _chargeRoutine = null;
        }
    }
    private void HandleSwing()
    {
        _player._movement.StopImmediately();
        _player._movement.CanMove = false;
        
        _player._soul.rbCompo.AddForce(_player.transform.forward * 700, ForceMode.Impulse);
    }


    public void EndAttack()
    {
        ComboCounter++;
        _lastAttackTime = Time.time;
    }

    public AttackDataSO GetCurrentAttackData()
    {
        Debug.Assert(attackDataList.Length > ComboCounter, "Combo counter is out of range");
        return attackDataList[ComboCounter];
    }

    private IEnumerator HoldAttackCoroutine()
    {
        _player.isUsePowerAttack = false;
        _player.ChangeState("CHARGE");
        attackHoldTime = 0f;
        
        while (true)
        {
            attackHoldTime += Time.deltaTime;
            if (attackHoldTime >= MaxHoldTime)
            {
                _player.isUsePowerAttack = true;
            }
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, _boxsize);
        Gizmos.color = Color.white;
    }
}