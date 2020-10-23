using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
 public KeyCode moveUp;
 public KeyCode moveDown;
 public float speed = 15f;
 private Rigidbody2D rigBody;
 void Awake (){
     rigBody = GetComponent<Rigidbody2D>(); 
 }
 // Update is called once per frame
 void Update () {
  if (Input.GetKey (moveUp)) {
     rigBody.velocity = new Vector2(0,speed);
  } else if (Input.GetKey (moveDown)) {
     rigBody.velocity = new Vector2(0,-speed);
  } else {
     rigBody.velocity = new Vector2(0, 0);
  }
 }
} 