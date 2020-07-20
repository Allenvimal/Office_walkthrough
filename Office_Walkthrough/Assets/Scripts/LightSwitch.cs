using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, InterfaceScripts
{
    public Renderer[] lightObject;
    public Transform lightSwitch;

    public Vector3 startPos;
    public Vector3 endPos;
    Vector3 target;
    public bool openStatus = false;

    public float speed;
    bool lightStatus;
    public void OnInteraction()
    {
        if (!openStatus)
        {
            openStatus = true;
            target = lightSwitch.localRotation.eulerAngles == startPos ? endPos : startPos;
            lightStatus = !lightStatus;

            foreach (Renderer renderer in lightObject)
            {
                if (lightStatus)
                    renderer.materials[1].EnableKeyword("_EMISSION");
                else
                    renderer.materials[1].DisableKeyword("_EMISSION");
            }
        }
    }
    void Start()
    {
        openStatus = false;
        startPos = lightSwitch.localRotation.eulerAngles;
    }

    void Update()
    {
        if (openStatus)
        {
            float step = speed * Time.deltaTime * 10;

            lightSwitch.localRotation = Quaternion.Lerp(lightSwitch.localRotation, Quaternion.Euler(target), step);

            if (lightSwitch.localRotation.eulerAngles == target)
            {
                openStatus = false;
            }
        }
    }
}
