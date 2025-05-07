using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputSO", menuName = "Scriptable Objects/PlayerInputSO")]
public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
{
    [SerializeField] private LayerMask whatIsGround;

    public event Action OnAttackPressd, OnJumpPressd, OnInteracetPressd, OnSprintPressd
        ,OnSheldPressd,OnHandleFollowSoulPressed,OnRollingPressed, OnSheldCanceld
        ,OnMouseAttackkeyPressed, OnAttackTimeCountEvent;

    public event Action OnSkillTreeOpen;

    public event Action OnClickMovePressed;

    private Controls _control;
    private Vector2 _screenPos;
    private Vector3 _worldPos;

    public Vector2 MovementKey { get;  set; }

    private void OnEnable()
    {
        if(_control == null)
        {
            _control = new Controls();
            _control.Player.SetCallbacks(this);
        }

        _control.Player.Enable();
    }

    private void OnDisable()
    {
        _control.Player.Disable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnAttackTimeCountEvent?.Invoke();
        if (context.canceled)
            OnAttackPressd?.Invoke();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnInteracetPressd?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnJumpPressd?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movementKey = context.ReadValue<Vector2>();
        MovementKey = movementKey;
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnSprintPressd?.Invoke();
    }

    public void OnMousePos(InputAction.CallbackContext context)
    {
        _screenPos = context.ReadValue<Vector2>();
    }

    public Vector3 GetWorldPosition(out RaycastHit hit)
    {
        Camera main = Camera.main;
        Debug.Assert(main != null, "No main camera in this scene");

        Ray cameraRay = main.ScreenPointToRay(_screenPos);
        if (Physics.Raycast(cameraRay, out hit, main.farClipPlane, whatIsGround))
        {
            _worldPos = hit.point;
        }
        return _worldPos;
    }

    public void OnSheldSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnSheldPressd?.Invoke();
        else if (context.canceled)
            OnSheldCanceld?.Invoke();


    }

    public void OnRolling(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnRollingPressed?.Invoke();
    }

    public void OnStrongAttackSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnHandleFollowSoulPressed?.Invoke();
    }

    public void OnOpenSkillTree(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnSkillTreeOpen?.Invoke();
    }

    public void OnClickAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnMouseAttackkeyPressed?.Invoke();
    }
}
