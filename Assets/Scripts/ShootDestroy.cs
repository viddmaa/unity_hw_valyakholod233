using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPoint.x > 1.1f || screenPoint.x < -0.1f ||
            screenPoint.y > 1.1f || screenPoint.y < -0.1f)
        {
            Destroy(gameObject);
        }
    }
}
