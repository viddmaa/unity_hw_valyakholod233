using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool IsActivated { get; private set; } = false;
    private Collider2D checkpointCollider;

    private void Awake()
    {
        checkpointCollider = GetComponent<Collider2D>();
    }

    public void ActivateCheckpoint()
    {
        if (!IsActivated)
        {
            IsActivated = true;
            if (checkpointCollider != null)
            {
                checkpointCollider.enabled = false;
            }
        }
    }
}