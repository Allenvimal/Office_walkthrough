using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour, InterfaceScripts
{
    MaterialController materialController;

    private void Start()
    {
        materialController = GetComponentInParent<MaterialController>();
    }

    public void OnInteraction()
    {
        materialController.objectToChange.material = this.gameObject.GetComponent<Renderer>().material;
    }
}
