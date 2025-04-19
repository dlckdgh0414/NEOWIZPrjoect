using UnityEngine;

public class PlayerAttackCompo : MonoBehaviour, IEntityComponet
{
    [Header("attack datas"), SerializeField] private AttackDataSO[] attackDataList;
    [SerializeField] private DamageCaster damageCast;

    [SerializeField] private float comboWindow;
    private Entity _entity;
    private EntityAnimator _entityAnimator;

    [SerializeField] private LayerMask _whatIsEnemy;

    private readonly int _attackSpeedHash = Animator.StringToHash("ATTACK_SPEED");
    private readonly int _comboCounterHash = Animator.StringToHash("COMBO_COUNTER");

    [SerializeField] private StatSO _atkDamage;
    [SerializeField] private EntityStat _stat;

    private float atkDamage;
    private EntityAnimatorTrigger _triggerCompo;

    private float _attackSpeed = 0.3f;
    private float _lastAttackTime;

    public bool useMouseDirection = false;

    public int ComboCounter { get; set; } = 0;

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
        _entityAnimator = entity.GetCompo<EntityAnimator>();
        AttackSpeed = 0.23f;
        damageCast.InitCaster(_entity);
        _triggerCompo = entity.GetCompo<EntityAnimatorTrigger>();
        _triggerCompo.OnAttackTriggerEnd += HandleAttackTrigger;
    }

    private void Start()
    {
        atkDamage = _stat.GetStat(_atkDamage).Value;
    }

    private void OnDestroy()
    {
        _triggerCompo.OnAttackTriggerEnd -= HandleAttackTrigger;
    }

    public void Attack()
    {
        bool comboCounterOver = ComboCounter > 2;
        bool comboWindowExhaust = Time.time >= _lastAttackTime + comboWindow;
        if (comboCounterOver || comboWindowExhaust)
        {
            ComboCounter = 0;
        }
        _entityAnimator.SetParam(_comboCounterHash, ComboCounter);
    }

    private void HandleAttackTrigger()
    {
        Vector2 knockbackForce = new Vector2(6,6);
        bool success = damageCast.CastDamage(atkDamage, knockbackForce);


        if (success)
        {
            print(atkDamage);
            Debug.Log("nice");
            CameraManager.Instance.ShakeCamera(atkDamage / 2, AttackSpeed / 2);
        }
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


}
