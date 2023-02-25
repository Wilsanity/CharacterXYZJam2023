using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyerctrl : MonoBehaviour
{
  public float xrot;
  public float yrot;
  public CharacterController CC;
  public Transform cam;
  public Transform camC;
  public float sens=2;
  public float speed=2;
  public float lerp = 0.2f;
  public float distance = 7f;
  public Transform ch;
  public Animator an;
  Vector3 ec;
  void Start()
{
  Application.targetFrameRate=60;
}
  void Update()
  {
    Vector3 xh = ch.TransformDirection(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))/10*speed);
    Vector3 grav = new Vector3(0,-7.97f/3*Time.deltaTime,0);
    if (Input.GetAxis("Mouse ScrollWheel") > 0){
      distance -=0.75f;
    }else if (Input.GetAxis("Mouse ScrollWheel") < 0){
      distance +=0.75f;
    }
    if (xh != Vector3.zero){
      ch.transform.localRotation=Quaternion.Lerp(ch.transform.localRotation,Quaternion.Euler(0, -45, 0),lerp);
    }
    an.SetFloat("walk",Mathf.Abs(xh.x)+Mathf.Abs(xh.z));
    CC.Move(xh);
    CC.Move(grav);
  }
}
