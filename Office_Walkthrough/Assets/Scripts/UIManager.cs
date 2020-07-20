using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour

{

    public Image gazePointer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInetractableObjectEnter()
    {
        gazePointer.color = Color.red;
    }

    public void OnInetractableObjectExit()
    {
        gazePointer.color = Color.white;
    }
}
