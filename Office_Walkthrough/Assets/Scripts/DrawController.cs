using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// Controls the Movement of the Drawer
/// 
/// </summary>

public class DrawController : MonoBehaviour, InterfaceScripts
{
    public Transform drawer;
    
    public Vector3 startPos;
    public Vector3 endPos;
    Vector3 target;
    bool openStatus = false;

    public float speed;
    public void OnInteraction()
    {
        if (!openStatus)
        {
            openStatus = true;
            target = drawer.localPosition == startPos ? endPos : startPos;
        }
    }

    void Start()
    {
        openStatus = false;
    }

    void Update()
    {
        if (openStatus)
        {
            float step = speed * Time.deltaTime;
            drawer.localPosition = Vector3.MoveTowards(drawer.localPosition, target, step);

            if (Vector3.Distance(drawer.localPosition, target) < 0.00001f)
            {
                openStatus = false;
            }
        }
    }
}
