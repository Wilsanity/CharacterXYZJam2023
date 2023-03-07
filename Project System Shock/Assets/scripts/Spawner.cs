using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int[] positions;
    public int waves;
    public GameObject[] types;
    public int startnum;
    public int addup;
    public int currenemies;
    void Start()
    {
        StartCoroutine(j());
    }
    IEnumerator j(){
        for(int i = 1; i <= waves; i++){
            for(int e = 1; e <= startnum+(addup*i); e++){
                currenemies+=1;
                GameObject enemy = GameObject.Instantiate(types[Random.Range(0,2)]);
                enemy.transform.position= new Vector3(Random.Range(positions[0],positions[1]),0,Random.Range(positions[2],positions[3]));
            }
            while (currenemies!=0){
                yield return new WaitForSeconds(1);
            }
        }
    }
}
