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
  public Transform hlook;
  public Animator an;
  public AudioSource[] asource;
  Vector3 ec;
  void Start()
{
  StartCoroutine(audiow());
  Application.targetFrameRate=60;
}

  IEnumerator audiow(){
    yield return new WaitForSeconds(0.35f);
    asource[Random.Range(0,2)].Play();
    asource[0].volume = Mathf.Clamp(Mathf.Abs(Input.GetAxis("Horizontal"))+Mathf.Abs(Input.GetAxis("Vertical")),0,0.5f);
    asource[1].volume = Mathf.Clamp(Mathf.Abs(Input.GetAxis("Horizontal"))+Mathf.Abs(Input.GetAxis("Vertical")),0,0.5f);
    StartCoroutine(audiow());
  }
  void Update()
  {
    Vector3 xh = hlook.TransformDirection(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))/10*speed);
    Vector3 grav = new Vector3(0,-7.97f/3*Time.deltaTime,0);
    if (Input.GetAxis("Mouse ScrollWheel") > 0){
      distance -=0.75f;
    }else if (Input.GetAxis("Mouse ScrollWheel") < 0){
      distance +=0.75f;
    }
    if (xh != Vector3.zero){
      ch.transform.rotation=Quaternion.Lerp(ch.transform.rotation,Quaternion.LookRotation(xh, Vector3.up),lerp);
    }
    an.SetFloat("walk",Mathf.Abs(xh.x)+Mathf.Abs(xh.z));
    CC.Move(xh);
    CC.Move(grav);
  }
}
