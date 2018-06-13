using UnityEngine;

public class LightController : MonoBehaviour {
    public float maxLight = 10f;
    public float minLight = 0f;
    public float simpleLightStep = 0.05f;
    public float torchIntensityRadiusRatio = 0.05f;

    private Light torch;
    private CircleCollider2D triggerCollider;
    private GameObject player;

	void Start () {
        torch = GetComponent<Light>();
        triggerCollider = GetComponent<CircleCollider2D>();
        player = GameObject.FindWithTag(Constants.PLAYER_TAG);
	}
	
	void Update () 
    {
        SimpleTorch();
	}

    private void SimpleTorch() 
    {
        if (Input.GetKey(KeyCode.L)) 
        {
            IncreaseLight();
        }
        else
        {
            DimLight();
        }
        UpdateTriggerColliderSize();
    }

    private void IncreaseLight() 
    {
        torch.intensity = Mathf.Min(torch.intensity + simpleLightStep * Time.deltaTime, maxLight);
    }

    private void DimLight()
    {
        torch.intensity = Mathf.Max(torch.intensity - simpleLightStep * Time.deltaTime, minLight);
    }

    private void UpdateTriggerColliderSize()
    {
        triggerCollider.radius = torch.intensity * torchIntensityRadiusRatio;
    }
}
