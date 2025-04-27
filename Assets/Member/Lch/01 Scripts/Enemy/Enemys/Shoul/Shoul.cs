using UnityEngine;

public class Shoul : BTEnemy
{
    public void BackStepEnemy(Transform target, float power, Transform enemy)
    {
        enemy.LookAt(target);
        _rbCompo.AddForce(Vector3.up * 1.5f, ForceMode.Impulse);

        _rbCompo.AddForce(-enemy.forward * power, ForceMode.Impulse);
        Debug.Log("È÷ÆR");
    }
}
