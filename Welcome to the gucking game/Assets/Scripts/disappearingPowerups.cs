using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearingPowerups : MonoBehaviour
{
    public float turnSpeed=35;

    private float expiryTime=3f;
    public float expiryTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        expiryTimer+=Time.deltaTime;

        transform.Rotate(Vector3.up, turnSpeed*Time.deltaTime);

        if(expiryTimer>expiryTime){
            Destroy(gameObject);
        }
        
    }
    
}
