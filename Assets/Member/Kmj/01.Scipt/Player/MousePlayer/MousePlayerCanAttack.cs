using UnityEngine;

public class MousePlayerCanAttack : EntityState
{
    protected MousePlayer _player;
    protected MousePlayerEnergy _energyCompo;
    public MousePlayerCanAttack(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;
        _energyCompo = entity.GetComponentInChildren<MousePlayerEnergy>();
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.OnMouseAttackkeyPressed += HandleAttackPressed;
    }

    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        _player.PlayerInput.OnMouseAttackkeyPressed -= HandleAttackPressed;
        base.Exit();
    }

    private void HandleAttackPressed()
    {
        Vector3 worldPosition = _player.PlayerInput.GetWorldPosition(out RaycastHit hitInfo);

        if (hitInfo.collider != null && ((1 << hitInfo.transform.gameObject.layer) & _player._whatIsEnemy) != 0)
        {
            _player.ChangeState("MOVE");
        }
    }
}
