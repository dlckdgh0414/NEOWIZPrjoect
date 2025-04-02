using System;
using UnityEngine;

public class MousePlayerSkillCompo : MonoBehaviour
{
    [SerializeField] private ParticleSystem _barrierEffect;

    [SerializeField] private StatSO _barrierHp;

    [SerializeField] private EntityStat _stat;

    [SerializeField] private EntityAnimatorTrigger _trigger;
    public float BarrierHp { get; set; }

    private void Awake()
    { 
        _trigger.OnBarrierPressed += HandleBarrierPressed;
        
    }

    private void OnDisable()
    {
        _trigger.OnBarrierPressed -= HandleBarrierPressed;
    }

    private void Update()
    {
        if (BarrierHp <= 0)
            _barrierEffect.Pause();
    }

    private void HandleBarrierPressed()
    {
       _barrierEffect = Instantiate(_barrierEffect,transform.position, Quaternion.identity);

        BarrierHp = _stat.GetStat(_barrierHp).Value;

        _barrierEffect.Play();
    }
}
