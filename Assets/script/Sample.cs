using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    public int sampleValue = 1;
    private void OnTriggerEnter2D(Collider2D collectSample)
    {
    	if (collectSample.gameObject.CompareTag("Player"))
    	{
    		sampleManager.instance.ChangeSampleCount(sampleValue);
    	}
    }
}
