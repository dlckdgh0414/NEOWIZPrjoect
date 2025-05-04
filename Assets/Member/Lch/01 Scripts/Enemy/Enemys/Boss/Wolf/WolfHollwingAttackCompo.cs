using UnityEngine;

public class WolfHollwingAttackCompo : Attack
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float rotationStep = 10f;
    private float currentRotation = 0f;
    private Entity _entity;
    public override void EnemyAttack(Transform target, Entity entity)
    {
      _entity = entity;
    }

    public void FireFourWay()
    {
        for (int i = 0; i < 4; i++)
        {
            float angle = i * 90f + currentRotation;
            Quaternion rot = Quaternion.Euler(0, angle, 0);
            Vector3 dir = rot * Vector3.forward;

            GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(dir));
            bulletObj.GetComponent<WolfBullet>().Fire(dir,_entity);
        }

        currentRotation += rotationStep;
    }
}
