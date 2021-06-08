using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectables_Script : MonoBehaviour {

    public bool isSelected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {/*
        if (transform.parent != null)
            Debug.Log(transform.name + " Current Parent " + transform.parent.name);

        else
            Debug.Log(transform.name + " No Parent ");
            */
        Debug.Log(transform.name+" isSelected "+ isSelected);
	}


    void OnCollisionEnter(Collision collision)//This is called in case the object hits a wall
    {
      
        if (isSelected)
        {
            isSelected = false;//This was added so then when the object hits a wall it doesn't permanently stay independent
            this.transform.SetParent(null);//If the object hits a wall, it's no longer the child of the reticle
            this.GetComponent<Rigidbody>().useGravity = true;//Gives it gravity so it falls
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;


        }



    }
}
