using UnityEngine;

public class WolfCatchAttackCompo : Attack
{
    [SerializeField] private CatchTrigger[] catchTriggers;
    public override void EnemyAttack(Transform target, Entity entity)
    {
        foreach (var trigger in catchTriggers)
        {
            trigger.enabled = true;
        }
    }

    public void CatchStop()
    {
        foreach(var trigger in catchTriggers)
        {
            trigger.CatStopPlayer();
            trigger.enabled = false;
        }
    }
}
