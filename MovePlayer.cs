using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float velocity;
    public float rotateVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float advance = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        Debug.Log(advance);
        this.gameObject.transform.Translate(Vector3.forward*velocity*advance);
        this.gameObject.transform.Rotate(Vector3.up * rotateVelocity * rotate);
    }
}
