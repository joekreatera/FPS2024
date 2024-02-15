using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float velocity;
    public float rotateVelocity;

    Rigidbody body;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
        body = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    bool wasGrounded = false;
    int jumps = 0;
    void FixedUpdate()
    {
        float advance = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        this.gameObject.transform.Rotate(Vector3.up * rotateVelocity * rotate);
        RaycastHit hit;
        bool crash = Physics.Raycast(this.gameObject.transform.position, Vector3.down, out hit, 1.2f);
        Debug.Log("Crash? " + crash + jumps);

        Vector3 vel = body.velocity;
        Vector3 dir = this.gameObject.transform.TransformDirection(Vector3.forward) * velocity * advance;
        dir.y = vel.y;
        if (crash && jumps > 0 && vel.y < 0) {
            jumps = 0;
        }
        if (Input.GetButtonDown("Jump") && jumps == 1 && !crash)
        {
            dir.y = 10;
            jumps = 2;
        }

        if (Input.GetButtonDown("Jump") && crash && jumps == 0 ) {
            jumps = 1;
            dir.y = 10;
        }


        body.velocity = dir;

    }
        
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.gameObject.transform.position, Vector3.down);
    }

    void MovePlayerV1() {
        float advance = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        this.gameObject.transform.Translate(Vector3.forward * velocity * advance);
        this.gameObject.transform.Rotate(Vector3.up * rotateVelocity * rotate);
    }
}
