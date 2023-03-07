using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public ParticleSystem sys;
    public plyerctrl pc;
    public Camera c;
    public Transform rHand;
    public GameObject BullPref;
    float fov;
    void Start(){
        fov = c.fieldOfView;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = c.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject g = GameObject.Instantiate(BullPref);
                g.transform.position = rHand.position;
                Bullet bull = g.GetComponent<Bullet>();
                bull.startingP = rHand.position;
                bull.endingP = hit.point;
            }
        }if(Input.GetMouseButton(1)){
            pc.speed = 0.6f;
            c.fieldOfView = Mathf.Lerp(c.fieldOfView,fov/3*2,0.2f);
        }else{
            pc.speed = 1.2f;
            c.fieldOfView = Mathf.Lerp(c.fieldOfView,fov,0.2f);
        }
    }
}
