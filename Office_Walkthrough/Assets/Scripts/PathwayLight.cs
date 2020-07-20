using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathwayLight : MonoBehaviour
{
    public GameObject pathwayLight;
    public Renderer pathwayLightRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pathwayLight.SetActive(true);
            pathwayLightRenderer.materials[1].EnableKeyword("_EMISSION");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pathwayLight.SetActive(false);
            pathwayLightRenderer.materials[1].DisableKeyword("_EMISSION");
        }
    }

}
