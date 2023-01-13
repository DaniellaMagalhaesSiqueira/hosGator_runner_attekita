using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent OnPlayerHitted;
    private Rigidbody2D plyRB;
    private bool canJump;
    private Animator animator;
    public float jumpFactor = 5f;
    public float fowardFactor = 0.2f;
    private float fowardForce = 0f;
    private bool isEnable;
    public Transform startPlayerPosition;
    void Start()
    {
        plyRB = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        canJump = true;
        isEnable = false;
    }

    public void SetActive()
    {
        isEnable = true;
        canJump = true;
        animator.Play("player_running");
        plyRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.transform.localPosition = startPlayerPosition.localPosition;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (!isEnable) return;
        if (canJump)
        {
            canJump = false;

            if(transform.position.x < 0)
            {
                fowardForce = fowardFactor;
            }
            else
            {
                fowardForce = 0f;
            }

            plyRB.velocity = new Vector2(fowardForce, jumpFactor);
            animator.Play("player_jump");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isEnable) return;
        if(collision.gameObject.tag == "Obstacle")
        {
            plyRB.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.Play("player_hurt");
            isEnable = false;
            OnPlayerHitted.Invoke();
        }
        else
        {
            animator.Play("player_running");
        }
        canJump = true;
    }
}
