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
    void FixedUpdate()
    {   
        float advance = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");

        this.gameObject.transform.Rotate(Vector3.up * rotateVelocity * rotate);
        RaycastHit hit;
        bool crash = Physics.Raycast(this.gameObject.transform.position, Vector3.down, out hit ,1.2f );
        
        body.AddForce(this.gameObject.transform.TransformDirection(Vector3.forward) * velocity * advance, ForceMode.Impulse);


        Vector3 xzVel = body.velocity;
        xzVel.y = 0;

        if (xzVel.magnitude > 5) {
            xzVel = this.gameObject.transform.TransformDirection(Vector3.forward) * 5;
            xzVel.y = body.velocity.y;
            body.velocity = xzVel;
        }
        

        xzVel = body.velocity;
        xzVel.z = 0;
        xzVel.x = 0;

        if (advance <= 0) {
            body.velocity = xzVel;
        }

    }

    void MovePlayerV1() {
        float advance = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        this.gameObject.transform.Translate(Vector3.forward * velocity * advance);
        this.gameObject.transform.Rotate(Vector3.up * rotateVelocity * rotate);
    }
}
