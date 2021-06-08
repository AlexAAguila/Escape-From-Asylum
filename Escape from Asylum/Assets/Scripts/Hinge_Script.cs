using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinge_Script : MonoBehaviour {
    public Component[] hingeJoints;
    public bool hinges;
	// Use this for initialization
	void Start () {
        /*
        hingeJoints = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody joint in hingeJoints)
            joint.useGravity = false;

        Debug.Log("Is happening");
        */
    }
	
	// Update is called once per frame
	void Update () {
        
       // if (gameObject.GetComponent<Selectables_Script>().isSelected)
      //  {
            hingeJoints = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody joint in hingeJoints)
                joint.useGravity = false;

          /*  Debug.Log("Is happening");
        }
        else
        {
            hingeJoints = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody joint in hingeJoints)
                joint.useGravity = true;

        }
        
        */
    }

    void hingeSpring()
    {
        hinges= true;
    }
}
