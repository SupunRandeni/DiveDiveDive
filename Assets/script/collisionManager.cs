using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionManager : MonoBehaviour
{
	public static collisionManager instance;
	public Text text;
	float collisions;
    // Start is called before the first frame update
    void Start()
    {
    	if (instance == null)
    	{
    		instance = this;
    	}
        
    }

    public void changeCollisionCount (float collision)
    {
    	collisions +=collision;

    	// sub's health counter
        float maxCollisionNumber = 20f;
        float healthPercentage = 100f - (collisions/maxCollisionNumber*100f);
        if (healthPercentage<0){
            healthPercentage = 0.0f;
        }
    	text.text = "Hull strength : " + healthPercentage.ToString("0") + " %";
    	if (healthPercentage < 0.5f) {
            GameObject sub = GameObject.Find("sub");
        	subControl subControl = sub.GetComponent<subControl>();
        	subControl.maydayMayday = true;
        }
    }
}
