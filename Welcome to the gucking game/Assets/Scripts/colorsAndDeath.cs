using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorsAndDeath : MonoBehaviour
{
    public GameObject player;
    public Renderer myRenderer;
    public Material[] material;

    public float colorCD=1.5f;
    public float timer;



    // Start is called before the first frame update
    void Start()
    {
        myRenderer=gameObject.GetComponent<Renderer>();
        myRenderer.sharedMaterial=material[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Comma)&&timer>colorCD){
            myRenderer.sharedMaterial=material[1];
            timer=0;
        }

        if(Input.GetKeyDown(KeyCode.Period)&&timer>colorCD){
            myRenderer.sharedMaterial=material[2];
            timer=0;
        }

        if(Input.GetKeyDown(KeyCode.Slash)&&timer>colorCD){
            myRenderer.sharedMaterial=material[3];
            timer=0;
        }

    }
    void OnTriggerEnter(Collider other){
        if(((other.gameObject.tag=="Obstacle"))&&(GameObject.FindWithTag("Win Flag")==false))
        {
            Destroy(gameObject);
        }
    }
        
}

