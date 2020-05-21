using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionManager : MonoBehaviour
{
	public static collisionManager instance;
	public Text text;
	int collisions;
    // Start is called before the first frame update
    void Start()
    {
    	if (instance == null)
    	{
    		instance = this;
    	}
        
    }

    public void changeCollisionCount (int collision)
    {
    	collisions +=collision;
    	text.text = "Collisions: " + collisions.ToString();
    }
}
