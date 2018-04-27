using UnityEngine;

public class MoveCactus : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public Vector3 playerPosition = Vector3.zero;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // TODO
    }

    private bool IsReadyToAttack()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Walk");
    }

    private bool IsNearPlayer()
    {
        return Vector3.Distance(transform.position, playerPosition) < 1f;
    }
}