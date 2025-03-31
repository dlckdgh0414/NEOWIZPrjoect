
using DG.Tweening;
using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerAtkCam : MonoBehaviour
{
    [SerializeField] private EntityAnimatorTrigger _triggerCompo;
    [SerializeField] private Transform _cam;

    private void Awake()
    {
        _triggerCompo.OnAttackTriggerEnd += ShakeCam;
    }

    private void OnDisable()
    {
        _triggerCompo.OnAttackTriggerEnd -= ShakeCam;
    }

    private void ShakeCam() => _cam.DOShakePosition(0.5f, 0.6f,6, 90f);
}
