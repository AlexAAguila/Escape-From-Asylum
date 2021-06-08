using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Screen_Script : MonoBehaviour {
    public float fadeOutDuration;//Is set in Unity
    public float timePassed;
    public float completion;
    bool isFading;
    public bool mazeC, boxC;
    float target;
    // Use this for initialization
    void Start () {
        fadeOut();
        mazeC=false;
        boxC = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (isFading)
        {
            timePassed += Time.deltaTime;//This is to make the fading visual effect happen
        }
        if (timePassed < fadeOutDuration && isFading == true)
        {
            float newAlpha;
                if (target == 0)
                {
                     newAlpha = 1 - timePassed / fadeOutDuration;//To set the value for Alpha which is dependant on the fading variables
                
                }
                else
                {
                     newAlpha = (1+timePassed) / fadeOutDuration;
                }
                    Color newColor = this.GetComponent<MeshRenderer>().material.color;//This is receiving the current colour of the child
                     newColor.a = newAlpha;//So it's only adjusting the Alpha
          

                    this.GetComponent<MeshRenderer>().material.color = newColor;//The child's material gets changed to the Alpha changing colour
            if (newAlpha < .1 )
            {


                fadeReset();
                //newColor.a = .12f;
                Debug.Log("fade Reset");
            }


        }

        if (mazeC && boxC) 
        {
            fadeIn();
        }
    }

    void fadeIn()
    {
        this.gameObject.SetActive(true);

        isFading = true;
        target = 1;

    }

    void fadeOut()
    {
        isFading = true;
        target = 0;
    }

    void fadeReset()
    {
        isFading = false;
        timePassed = 0;

        Debug.Log("I'm working");
    }
}
