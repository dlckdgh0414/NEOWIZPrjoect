using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowSkill : SkillCompo
{
    private float _strongDamage;

    private Player _player;


    [SerializeField] private MousePlayer _soul;
    public override void GetSkill()
    {
        _player = _entity as Player;
        _strongDamage = _stat.GetStat(_skillDamage).Value;
        print(_player);
        print(_triggerCompo);
        _player.PlayerInput.OnRollingPressed += HandleFollowSoul;
        _triggerCompo.OnStrongAttackTrigger += Skill;
    }

    private void HandleFollowSoul()
    {
        if (CanUseSkill("MoveToSoul") && !_player._isSkilling && _player._soul.isUseDashSkill)
        {
            _player.ChangeState("FOLLOW");
            CurrentTimeClear("MoveToSoul");
            _player._isSkilling = true;
        }
        else
            return;
    }


    public override void EventDefault()
    {
        _player.PlayerInput.OnRollingPressed  -= HandleFollowSoul;
        _triggerCompo.OnStrongAttackTrigger -= Skill;
    }


    protected override void Skill()
    {
        Collider[] collider = Physics.OverlapBox(transform.position, _skillSize,
             Quaternion.identity, _whatIsEnemy);

        collider.ToList().ForEach(x => x.GetComponentInChildren<IDamgable>().
        ApplyDamage(_strongDamage, false, 0, _player));

        CameraManager.Instance.ShakeCamera(_strongDamage / 3, 1);
    }

    public override void SkillFeedback()
    {
        base.SkillFeedback();
    }
}
