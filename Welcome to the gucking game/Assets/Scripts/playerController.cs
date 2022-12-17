using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //side2side
    public float speed=30;

    //jumping
    private Rigidbody playerRb;
    public float jumpForce;
     

    public bool isOnGround=true;

    //powerups
    public bool hasDoubleJump=false;
    public bool usedDoubleJump=false;


    public bool hasRadioactive=false;

    public float powerupExpiry=3;
    public float doubleJumpTimer;
    public float radioactiveTimer;
    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        doubleJumpTimer+=Time.deltaTime;
        radioactiveTimer+=Time.deltaTime;

        
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector3.right*Time.deltaTime*speed);
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left*Time.deltaTime*speed);
        }
        
        if(Input.GetKeyDown(KeyCode.UpArrow)&& isOnGround){
            playerRb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            isOnGround=false;
            if((usedDoubleJump==false)&&hasDoubleJump){
                isOnGround=true;
                usedDoubleJump=true;
            }
        }

        if(doubleJumpTimer>powerupExpiry){
            hasDoubleJump=false;
        }

        if(radioactiveTimer>powerupExpiry&&hasRadioactive){
            Destroy(gameObject);
            hasRadioactive=false;
        }

        
    }

    private void OnCollisionEnter(Collision collision){
        isOnGround=true;
        usedDoubleJump=false;
    }

    void OnTriggerEnter(Collider other){

        if(other.CompareTag("DoubleJump")){
            doubleJumpTimer=0;
            Destroy(other.gameObject);
            hasDoubleJump=true;
        }

        if(other.CompareTag("Radioactive")){
            radioactiveTimer=0;
            Destroy(other.gameObject);
            hasRadioactive=true;
        }
        
    }

    

        
}

