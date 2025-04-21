using System;
using System.Collections;
using UnityEngine;

public class CatchTrigger : MonoBehaviour
{
    [SerializeField] private Wolf _wolf;
    private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _player = player;
             _player._movement.CanMove = false;
            _player.transform.rotation = Quaternion.Euler(86f,0,0);
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
    }

    private IEnumerator PlayerDamgeTimer(float timer)
    {
        while(true)
        {
            yield return new WaitForSeconds(timer);
            if (_player.TryGetComponent(out IDamgable damgable))
            {
                damgable.ApplyDamage(20, false, 0, _wolf);
            }
            yield return null;
        }
    }
}
