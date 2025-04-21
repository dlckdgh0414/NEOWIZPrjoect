using System;
using System.Collections;
using UnityEngine;

public class CatchTrigger : MonoBehaviour,IEntityComponet
{

    private Wolf _wolf;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player._movement.CanMove = false;
            player.transform.rotation = Quaternion.Euler(86f,0,0);
            CatcingPlayer(player);
        }
    }

    private void CatcingPlayer(Player player)
    {
        StartCoroutine(PlayerDamgeTimer(1f,player));
      
    }

    private IEnumerator PlayerDamgeTimer(float timer,Player player)
    {
        while(true)
        {
            yield return new WaitForSeconds(timer);
            if (player.TryGetComponent(out IDamgable damgable))
            {
                damgable.ApplyDamage(20, false, 0, _wolf);
            }
            yield return null;
        }
    }

    public void Initialize(Entity entity)
    {
        _wolf = entity as Wolf;
    }
}
