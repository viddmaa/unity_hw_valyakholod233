using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    private GameObject lastCheckpoint;

    void Start()
    {
        lastCheckpoint = GameObject.Find("CheckPoint1");
        Animator animator = lastCheckpoint.GetComponent<Animator>();
        animator.SetTrigger("enable");
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            if (collision.gameObject != lastCheckpoint)
            {
                Animator animator = lastCheckpoint.GetComponent<Animator>();
                animator.SetTrigger("disable");
                lastCheckpoint = collision.gameObject;
                animator = lastCheckpoint.GetComponent<Animator>();
                animator.SetTrigger("enable");
            }
        }

        if (collision.gameObject.name == "DeadZone")
            gameObject.transform.position = lastCheckpoint.transform.position + Vector3.up;
    }
}