using System;
using System.Collections;
using UnityEngine;

public class MousePlayerSkillCompo : MonoBehaviour
{
    [SerializeField] private GameObject _barrierEffect;

    [SerializeField] private StatSO _barrierHp;

    [SerializeField] private EntityStat _stat;

    [SerializeField] private PlayerInputSO _trigger;
    [SerializeField] private Transform barrierTrans;

    private bool _isSheld = false;
    public float BarrierHp { get; set; }

    private void Awake()
    {

        _trigger.OnSheldPressd += HandleBarrierPressed;
        _trigger.OnSheldCanceld += HandleBarrierCanceled;
    }

    private void OnDisable()
    {
        _trigger.OnSheldPressd -= HandleBarrierPressed;
        _trigger.OnSheldCanceld -= HandleBarrierCanceled;
    }

    private void Update()
    {
        if (BarrierHp <= 0)
            _barrierEffect.gameObject.SetActive(false);

        if(_isSheld)
        {
            BarrierHp -= 10 * Time.deltaTime;
        }
    }

    private void HandleBarrierPressed()
    {
        _isSheld = true;
        BarrierHp = _stat.GetStat(_barrierHp).Value;

        if(BarrierHp < 0)
        {
            _isSheld = false;
            _barrierEffect.SetActive(false);
        }

        _barrierEffect.SetActive(true);
    }

    private void HandleBarrierCanceled()
    {
        _isSheld = false;
        _barrierEffect.SetActive(false);
    }
}
