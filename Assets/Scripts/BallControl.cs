using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class BallControl : MonoBehaviour
{
    
    private Rigidbody2D myRigidbody;
    private float ballSpeed = 80;

    void Start(){
        StartCoroutine(DelayTheStart());
    }

    
    void Update(){
        myRigidbody = GetComponent<Rigidbody2D>();
        float xVel = myRigidbody.velocity.x;
        if(xVel < 18 && xVel > -18 && xVel != 0){
            if(xVel > 0){
                Vector3 v = GetComponent<Rigidbody2D>().velocity;
                v.x = 20;
                GetComponent<Rigidbody2D>().velocity = v;
            }else{
                Vector3 v = GetComponent<Rigidbody2D>().velocity;
                v.x = -20;
                GetComponent<Rigidbody2D>().velocity = v;
            }
        }
    }

    IEnumerator DelayTheStart() {
        Debug.Log("Before Waiting 2 seconds");
        yield return new WaitForSeconds(2);
        Debug.Log("After Waiting 2 Seconds");
        GoBall();
    }

    void OnCollisionEnter2D(Collision2D colInfo) {
      if (colInfo.collider.tag == "Player") {
        Vector3 v = GetComponent<Rigidbody2D>().velocity;
        v.y = myRigidbody.velocity.y/2 + colInfo.collider.attachedRigidbody.velocity.y/3;
        GetComponent<Rigidbody2D>().velocity = v;
        GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.2f);
        GetComponent<AudioSource>().Play();
      }
    }

    void GoBall(){
        int randomNumber = Random.Range(0, 2);
        if (randomNumber <= 0.5) {
         
          myRigidbody.AddForce (new Vector2(ballSpeed, 10));
        } else {
          
          myRigidbody.AddForce (new Vector2(-ballSpeed, -10));
        }
    }

    public void ResetBall()
    {
    myRigidbody.velocity = new Vector2(0,0);
    transform.position = new Vector2 (0, 6);
    Invoke ("GoBall", 1);
    }

}