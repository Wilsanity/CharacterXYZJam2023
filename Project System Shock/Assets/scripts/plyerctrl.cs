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
  Vector3 ec;
  void Start()
{
  Application.targetFrameRate=60;
    Cursor.lockState = CursorLockMode.Locked;
}
  void Update()
  {
    Vector3 xh = camC.TransformDirection(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))/10*speed);
    Vector3 grav = new Vector3(0,-7.97f/3*Time.deltaTime,0);
    xrot += Input.GetAxis("Mouse X")/2;
    yrot -= Input.GetAxis("Mouse Y")/2;
    yrot = Mathf.Clamp(yrot, -30f, 30f);
    if (Input.GetAxis("Mouse ScrollWheel") > 0){
      distance -=0.75f;
    }else if (Input.GetAxis("Mouse ScrollWheel") < 0){
      distance +=0.75f;
    }
    if (xh != Vector3.zero){
      ch.transform.localRotation=Quaternion.Lerp(ch.transform.localRotation,Quaternion.Euler(0, xrot*sens, 0),lerp);
    }
    distance=Mathf.Clamp(distance,0.5f,10);
    RaycastHit hit;
    if (Physics.Raycast(camC.position, camC.TransformDirection(Vector3.back), out hit, 10)){
      cam.position=Vector3.Lerp(cam.position,hit.point,0.3f);
    }else{
      cam.localPosition=Vector3.Lerp(cam.localPosition,new Vector3(0,0,-distance),0.3f);
    }
    camC.transform.localRotation = Quaternion.Lerp(camC.transform.localRotation,Quaternion.Euler(yrot*sens, xrot*sens, 0),lerp);
    CC.Move(xh);
    CC.Move(grav);
  }
}
