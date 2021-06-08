using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_Script : MonoBehaviour {
    public GameObject maze, start, end;
    public float fadeOutDuration;//Is set in Unity
    public float timePassed;
    public AudioSource wrong, complete;
    bool isFading;

    public GameObject bss;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isFading)
        {
            timePassed += Time.deltaTime;//This is to make the fading visual effect happen
        }
        if (timePassed < fadeOutDuration && isFading==true)
        {
            foreach (Transform child in maze.transform)
            {
                float newAlpha = 1- timePassed / fadeOutDuration;//To set the value for Alpha which is dependant on the fading variables
                Color newColor = child.GetComponent<MeshRenderer>().material.color;//This is receiving the current colour of the child
                newColor.a = newAlpha;//So it's only adjusting the Alpha

                child.GetComponent<MeshRenderer>().material.color = newColor;//The child's material gets changed to the Alpha changing colour
            }
        }
        
    }

    public void mazeVisible()//This is called when the puzzle is completed
    {
        isFading = true;
        Debug.Log("MazeVisible");
        
    }

    public void mazeStart(bool wallHit, bool mazeFinished)//Code for the maze
    {
        Color disappear, appear, startAppear;

        disappear = new Color(0, 0, 0, 0);//Sets object to disappear
        appear = new Color(0,255,0,255);//Set's the end block's colour
        startAppear = new Color(255, 248, 0, 255);//beginning block's colour

        if (wallHit==false && mazeFinished==false)//When the maze starts
        {
            start.GetComponent<MeshRenderer>().material.color = disappear;//Sets start to disappear
            end.GetComponent<MeshRenderer>().material.color = appear;//Sets end to reappear
        }
        else if (wallHit == true && mazeFinished==false)//Tests if wall is hit before reaching the end
        {
            start.GetComponent<MeshRenderer>().material.color = startAppear;//Start reappears
            end.GetComponent<MeshRenderer>().material.color = disappear;//end Disappears
            wrong.Play();
            Debug.Log("Maze wall is hit");
            
        }
       else if (wallHit == false && mazeFinished==true)//If the end is hit and wall hasn't been touched
        {
            Vector3 newPos = new Vector3(-100, 0, 0);//setting item to move
            start.GetComponent<Transform>().transform.Translate(newPos);//Start moves to another location
            end.GetComponent<Transform>().transform.Translate(newPos);//End moves to another location
            //I did this because the maze is always there and when the reticle goes by it the start and end blocks kept reappearing
            start.GetComponent<MeshRenderer>().material.color = disappear;
            end.GetComponent<MeshRenderer>().material.color = disappear;
            Debug.Log("Completed");
            complete.Play();
            bss.GetComponent<Black_Screen_Script>().mazeC = true;
            end.gameObject.SetActive(false);


        }
    }
    
}
