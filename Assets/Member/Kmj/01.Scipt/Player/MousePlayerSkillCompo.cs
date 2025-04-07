using UnityEngine;

public class MousePlayerSkillCompo : MonoBehaviour
{
    [SerializeField] private GameObject _barrierEffect;

    [SerializeField] private MousePlayerEnergy _energyCompo;

    [SerializeField] private EntityStat _stat;

    [SerializeField] private PlayerInputSO _trigger;
    [SerializeField] private Transform barrierTrans;
    [SerializeField] private MousePlayer _player;

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
       
    }

    private void HandleBarrierPressed()
    {
        if (_energyCompo.isEnergyNotzero && !_player._isSkilling)
        {
            _player.ChangeState("SHELD");
            _player._isSkilling = true;
            _barrierEffect.SetActive(true);
            _energyCompo.UseEnergy(10);
        }
    }

    public void HandleBarrierCanceled()
    {
        if (_player._isSkilling)
        {
            _player.ChangeState("IDLE");
            _player._isSkilling = false;
            _barrierEffect.SetActive(false);
        }
    }

    public void StopState()
    {
        _player.ChangeState("IDLE");
    }
}
