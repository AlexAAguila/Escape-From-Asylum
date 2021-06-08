using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleController : MonoBehaviour {

    public GameObject reticle;
    RaycastHit hit;
    public GameObject currentlySelected;
    GameObject test;
    public GameObject maze;
	// Use this for initialization
	void Start () {
		
	}

    //Change is to determine if the maze game started or not
    // 0 means it hasn't started, 1 means it has
    int change = 0;

    void FixedUpdate () {

        //This is for the maze script
    if(Physics.Raycast(transform.position,transform.forward, out hit))
        {
            #region MazeControls
           
            
            if (change == 1 && hit.collider.tag == "MazeFinish")//If the end block is hit while change is still 1 then the fading function happens
            {
                maze.GetComponent<Maze_Script>().mazeVisible();
                maze.GetComponent<Maze_Script>().mazeStart(false, true);//Walls weren't hit and the end block was
                Debug.Log("Hit maze end");

            }
            
            else if(hit.collider.tag =="MazeWall")//If the wall is hit, it puts change back to 0 and makes the beginning block reappear and the ending block disappear
            {
                Debug.Log("Hit maze wall");
                change = 0;
                maze.GetComponent<Maze_Script>().mazeStart(true,false);//Wall was hit and end block wasn't hit

            }
             
            //Turns change to 1 and calls the maze start function
            else if (hit.collider.tag == "MazeStart")// This is when the reticle hits the beginning block of the maze
            {
                Debug.Log("Hit maze Start");
                maze.GetComponent<Maze_Script>().mazeStart(false,false);//Neither wall nor end block has been hit
                change = 1;
            }
            #endregion
            #region Deselect
            if (currentlySelected!=null)
            {
                if(Input.GetKeyDown(KeyCode.S ))
                {
                    currentlySelected = null;
                }
                
            }
            #endregion
            #region Select
            if (hit.collider.tag =="Selectable")
            {
                if(Input.GetKeyDown(KeyCode.S))//Button to pick things up, can be changed because Alt + e is a hot key
                {
                    if(currentlySelected==null)
                    {
                        currentlySelected = hit.collider.gameObject;//gameobject componenet becomes the selected object
                        currentlySelected.transform.SetParent(this.gameObject.transform);//Sets the item to be the child of the reticle
                        currentlySelected.GetComponent<Rigidbody>().useGravity = false;//To turn off gravity when the item is selected so it follows the reticle
                        currentlySelected.GetComponent<Selectables_Script>().isSelected = true;//To state that the variable is selected
                        //currentlySelected.GetComponent<Hinge_Script>().hinges = true;
                        currentlySelected.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                    }
                    
                }
                else if (Input.GetKeyUp(KeyCode.S))
                {
                    currentlySelected.GetComponent<Selectables_Script>().isSelected = false;//If e is let go, then it's no longer selected
                    currentlySelected.GetComponent<Rigidbody>().useGravity = true;//Adds gravity to the item again
                    currentlySelected.transform.SetParent(null);//It's not a child to anything anymore
                    currentlySelected.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    currentlySelected = null;//Gameobject component becomes null

                }
            }
            #endregion
            if(hit.collider.name=="RectangleSlot")
            {
                Debug.Log("Put rectangle in the slot!");
            }
        }
        else
        {
            if (currentlySelected != null)//If the item comes out of the reticle without e button being released
            {
                currentlySelected.GetComponent<Selectables_Script>().isSelected = false;//The bool becomes false from the Selected script
                currentlySelected.transform.SetParent(null);//It's not a child to anything anymore
                currentlySelected.GetComponent<Rigidbody>().useGravity = true;//Adds gravity to the item again
                currentlySelected.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                currentlySelected = null;//Gameobject component becomes null

            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
       Gizmos.DrawRay(transform.position, transform.forward);


    }
}
