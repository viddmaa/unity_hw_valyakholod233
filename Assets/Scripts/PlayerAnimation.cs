using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator ac;
    public bool IsMoving { get; set; }
    public bool IsJumping { get; set; }

    void Start()
    {
        ac = GetComponent<Animator>();

    }

    void Update()
    {
        ac.SetBool("IsMoving", IsMoving);
        ac.SetBool("IsJumping", IsJumping);
    }
}



