using System;
using UnityEngine;

public class TestSkillTree : MonoBehaviour
{
    [SerializeField] private PlayerInputSO input;
    [SerializeField] private Canvas canvas;
    private bool _isOpen;

    private void Awake()
    {
        input.OnSkillTreeOpen += HandleSkillTreeOpen;
    }

    private void HandleSkillTreeOpen()
    {
        _isOpen = !_isOpen;
        canvas.gameObject.SetActive(_isOpen);
    }
}
