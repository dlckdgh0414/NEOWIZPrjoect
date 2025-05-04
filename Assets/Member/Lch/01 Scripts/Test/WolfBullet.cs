using UnityEngine;

public class WolfBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    private float timer = 0f;
    private Vector3 direction;

    public void Fire(Vector3 dir)
    {
        direction = dir.normalized;
        timer = 0f;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        timer += Time.deltaTime;

        if (timer >= lifeTime)
            Destroy(gameObject);
    }
}

