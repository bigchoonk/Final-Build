using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObstacles : MonoBehaviour
{


    public float gravityForce;
    
    ///part for obstacles
    public GameObject obstaclePrefab;


    public float speed;

    public float countdown=7;
    

    public int delay=3;
    public float delayTimer;

    public float timer;
    
    private int spawnPosX=-85;
    private float spawnRangeZ=10.5f;



    

    //part for players
    public GameObject player;
    public GameObject enemy;

    //spawn players
    private float spawnPositionX=202.11f;
    private float spawnPositionY=.5f;
    private float spawnPositionZ=9.5f;


    //scorekeeping
    public int winCondition=3;
    public int playerScore=0;
    public int enemyScore=0;
    public bool gameOver=false;

    //bandaid for the powerups
    public GameObject winFlag;



    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerSpawnPosition=new Vector3(spawnPositionX,spawnPositionY,-spawnPositionZ);
        Vector3 enemySpawnPosition=new Vector3(spawnPositionX,spawnPositionY,spawnPositionZ);

        Instantiate(player,playerSpawnPosition,player.transform.rotation);
        Instantiate(enemy,enemySpawnPosition,enemy.transform.rotation);
        
        Physics.gravity*=gravityForce;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        delayTimer+=Time.deltaTime;
        timer+=Time.deltaTime;

        Vector3 playerSpawnPosition=new Vector3(spawnPositionX,spawnPositionY,spawnPositionZ);
        Vector3 enemySpawnPosition=new Vector3(spawnPositionX,spawnPositionY,-spawnPositionZ);
        Vector3 respawnPosition=new Vector3(spawnPositionX,spawnPositionY,Random.Range(spawnPositionZ,-spawnPositionZ));

        Vector3 winFlagSpawnPosition=new Vector3(0,0,0);



        while(timer>countdown&&delayTimer>delay&&!gameOver){
            Vector3 spawnPosition=new Vector3(spawnPosX,4,Random.Range(spawnRangeZ,-spawnRangeZ));
            Instantiate(obstaclePrefab,spawnPosition, obstaclePrefab.transform.rotation);
            delayTimer=0;
        }

        transform.Translate(Vector3.forward*Time.deltaTime*speed*-1);

       if(GameObject.FindWithTag("Player")==null){
            
            
            if(enemyScore==winCondition){
                gameOver=true;
            }
            else if(enemyScore!=winCondition){
                Instantiate(player,respawnPosition,player.transform.rotation);
                enemyScore+=1;
            }
            
        }

        if(GameObject.FindWithTag("Enemy")==false){
            if(playerScore==winCondition){
                gameOver=true;
            }
            else{
                Instantiate(enemy,respawnPosition,enemy.transform.rotation);
                playerScore+=1;
            }
        }
        if(gameOver){
            Instantiate(winFlag,winFlagSpawnPosition,winFlag.transform.rotation);
        }
        
    }
}

