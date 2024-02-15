using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", 3);
    }

    void SelfDestroy() {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        SelfDestroy();
        CancelInvoke("SelfDestroy");
    }
}
