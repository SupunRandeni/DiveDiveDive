using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sampleManager : MonoBehaviour
{
	public static sampleManager instance;
	public Text text;
	int samples;

    // Start is called before the first frame update
    void Start()
    {
    	if (instance == null)
    	{
    		instance = this;
    	}
        
    }

    public void ChangeSampleCount (int sampleCount)
    {
    	samples +=sampleCount;
    	text.text = "Samples  :" + samples.ToString();
    }
}
