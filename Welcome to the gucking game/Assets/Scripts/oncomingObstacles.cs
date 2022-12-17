using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oncomingObstacles : MonoBehaviour
{
    public float speed=25;
    private float outOfBounds=214;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*speed*-1);


        if(transform.position.x>outOfBounds){
            Destroy(gameObject);
        }
        
    }
}
