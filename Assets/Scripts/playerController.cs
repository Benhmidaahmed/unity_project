using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public int runSpeed;
    private int JumpCount = 0;
    private bool canJump = true;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;

        if (JumpCount == 2)
        {
            canJump = false;
        }

        if (Input.GetKeyDown("space") && canJump)
        {
            rb2d.velocity = Vector3.up * 4.5f;
            anim.SetTrigger("jump");
            JumpCount += 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpCount = 0;
            canJump = true;

        }
    }
}
