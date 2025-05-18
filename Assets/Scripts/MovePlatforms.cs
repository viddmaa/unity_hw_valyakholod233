using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float moveStep = speed * Time.deltaTime;

        if (movingRight)
        {
            transform.Translate(Vector3.right * moveStep);
            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * moveStep);
            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }
}
