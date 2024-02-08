using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float advance = Input.GetAxis("Vertical");
        Debug.Log(advance);
        this.gameObject.transform.Translate(Vector3.forward*velocity*advance);
    }
}
