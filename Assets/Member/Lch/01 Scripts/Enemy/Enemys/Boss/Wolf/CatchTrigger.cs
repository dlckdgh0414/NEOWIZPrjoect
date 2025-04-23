using System;
using System.Collections;
using UnityEngine;

public class CatchTrigger : MonoBehaviour
{
    [SerializeField] private Wolf _wolf;
    private Player _player;
    private IDamgable damgable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _player = player;
             _player._movement.CanMove = false;
            _player.transform.rotation = Quaternion.Euler(86f,0,0);
            damgable = _player.GetComponentInChildren<IDamgable>();
            _wolf.mainAnim.speed = 0f;
            CatcingPlayer();
        }
    }

    private void CatcingPlayer()
    {
        StartCoroutine(PlayerDamgeTimer(1f));
      
    }

    public void CatStopPlayer()
    {
        _player._movement.CanMove = true;
        _player.transform.rotation = Quaternion.identity;
        _wolf.mainAnim.speed = 1f;
    }

    private IEnumerator PlayerDamgeTimer(float timer)
    {
        while(true)
        {
            yield return new WaitForSeconds(timer);
            damgable.ApplyDamage(20, false, 0, _wolf);
            yield return null;
        }
    }
}
