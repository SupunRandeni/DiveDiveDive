using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidableObject : MonoBehaviour
{
    public int collisionValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if (collision.gameObject.CompareTag("Player"))
    	{
    		collisionManager.instance.changeCollisionCount(collisionValue);
    	}
    }
}
