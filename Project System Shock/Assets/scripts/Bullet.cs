using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 startingP;
    public Vector3 endingP;
    void Awake()
    {
        StartCoroutine(shoot());
    }
    IEnumerator shoot(){
        for(float i=0;i<=1.3f;i+=0.1f){
            yield return new WaitForSeconds(0.01f);
            transform.position = Vector3.LerpUnclamped(startingP,endingP,i);
        }
        Destroy(this.gameObject);
    }
}
