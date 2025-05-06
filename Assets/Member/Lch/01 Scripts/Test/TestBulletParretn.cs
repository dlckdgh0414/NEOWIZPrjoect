using UnityEngine;

public class TestBulletParretn : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireInterval = 0.3f;
    public float rotationStep = 10f;

    private float timer = 0f;
    private float currentRotation = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            FireFourWay();
            timer = 0f;
        }
    }

    void FireFourWay()
    {
        for (int i = 0; i < 4; i++)
        {
            float angle = i * 90f + currentRotation;
            Quaternion rot = Quaternion.Euler(0, angle, 0);
            Vector3 dir = rot * Vector3.forward;

            GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(dir));
            //bulletObj.GetComponent<WolfBullet>().Fire(dir);
        }

        currentRotation += rotationStep;
    }
}
