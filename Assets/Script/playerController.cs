using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody bodyRig;
    private void Awake()
    {
        bodyRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            checkJumpForce();
        }
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;
        dir.y = bodyRig.velocity.y;
        bodyRig.velocity = dir;

        Vector3 faceDir = new Vector3(xInput, 0, zInput);
        if (faceDir.magnitude > 0)
        {
            transform.forward = faceDir;

        }
    }

    void checkJumpForce()
    {
        bodyRig.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
    }
}
