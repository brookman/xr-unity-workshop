using System.Collections;
using System.Collections.Generic;
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
        transform.LookAt(playerPosition);

        if (!IsNearPlayer())
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            animator.Play("Attack");
        }
    }

    private bool IsNearPlayer()
    {
        return Vector3.Distance(transform.position, playerPosition) < 1f;
    }
}
