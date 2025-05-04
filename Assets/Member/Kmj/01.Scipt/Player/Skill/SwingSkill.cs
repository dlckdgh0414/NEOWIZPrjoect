using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

    public class SwingSkill : SkillCompo
    {
        
        private Player _player;
        [SerializeField] private MousePlayer _soul;
        
        
        public override void GetSkill()
        {
            _player = _entity as Player;
            _player.PlayerInput.OnAttackPressd += Skill;    
            
            base.GetSkill();
        }

        private void HandleSwing()
        {
            if (CanUseSkill("SWING") && !_player._isSkilling && _player._soul.isUseDashSkill)
            {
                _player.ChangeState("SWING");
                CurrentTimeClear("SWING");
                _player._isSkilling = true;
            }
            else
                return;
        }
        public override void SkillFeedback()
        {
            base.SkillFeedback();
        }

        protected override void Skill()
        {
            if (_player.isUsePowerAttack)
            {
                _soul.transform.position = _player.transform.forward;
            
                _soul.ChangeState("STOP");

                 StartCoroutine(WaitSwing());
            }

        }
        
        

        public override void EventDefault()
        {
            base.EventDefault();
        }

        private IEnumerator WaitSwing()
        {
            yield return new WaitForSeconds(0.2f);
            
            _soul.rbCompo.AddForce(transform.forward * 20f, ForceMode.Impulse);
        }
    }
    