using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyai : MonoBehaviour
{
    Spawner sp;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        sp = GameObject.Find("spawner").GetComponent<Spawner>();
    }
    private void FixedUpdate() {
        if(health <=0){
            sp.currenemies-=1;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer==3){
            Destroy(other.gameObject);
            health-=1;
        }else{
            print(other.gameObject.layer);
        }
    }


}   
