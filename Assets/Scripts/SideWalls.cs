using UnityEngine;

public class SideWalls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball") 
        {
            GetComponent<AudioSource>().Play();
            GameManager.Score(transform.name);
            hitInfo.gameObject.SendMessage ("ResetBall");
        }
    }
}