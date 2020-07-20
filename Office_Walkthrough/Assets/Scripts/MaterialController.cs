using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 
/// Change material of the object
/// 
/// </summary>

public class MaterialController : MonoBehaviour, InterfaceScripts
{
    public Renderer objectToChange;

    public Animator animator;

    public void OnInteraction()
    {
        animator.SetTrigger("trigger");
    }

}
