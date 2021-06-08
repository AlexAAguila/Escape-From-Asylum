using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Script : MonoBehaviour {
   public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject box, shapes;
    public GameObject bss;

    //Creating the booleans for the items
    bool cubeIn;
    bool sphereIn;
    bool cylinderIn;

    //Accessing completion

    Vector3 cPos, sPos, cyPos;//To record where the items originally were
    // Use this for initialization
    void Start () {
        //Records the positions of where the items are currently at
        cPos = cube.transform.position;
        sPos = sphere.transform.position;
        cyPos = cylinder.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)//Goes through the trigger block
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject == cube)// Making sure the first block is the cube one
        {
            Debug.Log("Yay Cube");
            cubeIn = true;//cube boolean becomes true
            
            
            
        }
        else if (collider.gameObject == sphere && cubeIn == true)//Making sure the cube is already in and the next one is the sphere
        {
            Debug.Log("Yay sphere");
            
            sphereIn = true;//sphere bool becomes true
        }
        else if (collider.gameObject == cylinder && cubeIn && sphereIn)///Making sure the cube and sphere is already in and the next one is cylinder 
        {
            Debug.Log("Yay cylinder");
            cylinderIn = true;//cylinder bool becomes true
            
            //now all the shapes become a child to the box parent
            cylinder.transform.SetParent(box.transform);
            sphere.transform.SetParent(box.transform);
            cube.transform.SetParent(box.transform);

            //Now the fading function happens that makes the items and the box become invisible
            box.GetComponent<Maze_Script>().mazeVisible();
            shapes.GetComponent<Maze_Script>().mazeVisible();
            bss.GetComponent<Black_Screen_Script>().boxC = true;


        }
        else
        {
            //If the if statements above aren't qualified
            //The items are rested and all the booleans become false again and the puzzle restarts
            cube.transform.position = cPos;
            sphere.transform.position = sPos;
            cylinder.transform.position = cyPos;
            cubeIn = false;
            sphereIn = false;
            cylinderIn = false;
        }

    }
}
