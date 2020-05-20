using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
	public Transform subTransform;

    void FixedUpdate()
    {
        this.transform.position = new Vector3(
        	Mathf.Clamp(subTransform.position.x, -12f, 44f),
        	Mathf.Clamp(subTransform.position.y, -20f, 10f),
        	 this.transform.position.z);
    	

        // this.transform.position = new Vector3(
        // 	subTransform.position.x,
        // 	subTransform.position.y,
        // 	 this.transform.position.z);
    }
}
