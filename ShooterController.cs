using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public GameObject bulletOriginal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")) {
           GameObject bullet = Instantiate(bulletOriginal, this.transform.position, Quaternion.identity);
            Vector3 dir = this.transform.TransformDirection(Vector3.forward);
            Physics.IgnoreCollision(this.GetComponent<Collider>(), bullet.GetComponent<Collider>());
            bullet.GetComponent<Rigidbody>().AddForce(dir*20, ForceMode.Impulse);
        }


    }
}
