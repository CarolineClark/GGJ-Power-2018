using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    public float maxLight = 10f;
    public float minLight = 0f;
    public float simpleLightStep = 0.05f;
    private Light torch;

	void Start () {
        torch = GetComponent<Light>();
	}
	
	void Update () 
    {
        SimpleTorch();
	}

    void SimpleTorch() 
    {
        if (Input.GetKey(KeyCode.L)) 
        {
            IncreaseLight();
        }
        else
        {
            DimLight();
        }

    }

    void IncreaseLight() 
    {
        torch.intensity = Mathf.Min(torch.intensity + simpleLightStep * Time.deltaTime, maxLight);
    }

    void DimLight()
    {
        torch.intensity = Mathf.Max(torch.intensity - simpleLightStep * Time.deltaTime, minLight);
    }
}
