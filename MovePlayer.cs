using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float velocity;
    public float rotateVelocity;

    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float advance = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");

        bool crash = Physics.Raycast(this.gameObject.transform.position, Vector3.down, 1.2f);
        Debug.Log(crash);

        this.gameObject.transform.Rotate(Vector3.up * rotateVelocity * rotate);
        // problema: cuando va en una rampa , brinca sin razon 
        Vector3 currentVelocity = this.gameObject.transform.TransformDirection(Vector3.forward)  * velocity * advance;
        currentVelocity.y = body.velocity.y;
        
        body.velocity = currentVelocity;
        body.angularVelocity = Vector3.zero;



    }

    void MovePlayerV1() {
        float advance = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        this.gameObject.transform.Translate(Vector3.forward * velocity * advance);
        this.gameObject.transform.Rotate(Vector3.up * rotateVelocity * rotate);
    }
}
