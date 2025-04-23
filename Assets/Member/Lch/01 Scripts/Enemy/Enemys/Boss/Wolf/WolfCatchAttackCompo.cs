using UnityEngine;

public class WolfCatchAttackCompo : Attack
{
    [SerializeField] private CatchTrigger[] catchTriggers;
    public override void EnemyAttack(Transform target, Entity entity)
    {
        foreach (var trigger in catchTriggers)
        {
            trigger.gameObject.SetActive(true);
        }
    }

    public void CatchStop()
    {
        foreach(var trigger in catchTriggers)
        {
            trigger.CatStopPlayer();
            trigger.gameObject.SetActive(false);
        }
    }
}
