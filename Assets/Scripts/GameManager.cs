using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;

    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    public Transform Player01;
    public Transform Player02;
    public Transform theBall;

    Vector3 Player01Position;
    Vector3 Player02Position;

    public static int playerScore01 = 0;
    public static int playerScore02 = 0;

    public GUISkin theSkin;

    void Start(){
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update(){

        //Move walls to edge locations
        topWall.size = new Vector2(mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2(0f, mainCamera.ScreenToWorldPoint (new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomWall.size = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        //Move the players to a fixed distance from the edges of the screen:
        Player01.position.Set(mainCamera.ScreenToWorldPoint(new Vector3(50f, 0f, 0f)).x, 0f, 0f);
        Player02.position.Set(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width - 50f, 0f, 0f)).x, 0f, 0f);

    }

    public static void Score(string wallName)
    {
        if (wallName == "rightWall")
        {
            playerScore01 += 1;
        }
        else
        {
            playerScore02 += 1;
        }
        Debug.Log("Player 1 score is: " + playerScore01);
        Debug.Log("Player 2 score is: " + playerScore02);
    }

    void OnGUI() 
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150, 25, 100, 100), "" + playerScore01);
        GUI.Label(new Rect(Screen.width / 2 +150, 25, 100, 100), "" + playerScore02);

        if(GUI.Button(new Rect(Screen.width/2 -121/2,35,121,53),"RESET")){
            playerScore01 = 0;
            playerScore02 = 0;
            theBall.gameObject.SendMessage("ResetBall");
        }
    }
}