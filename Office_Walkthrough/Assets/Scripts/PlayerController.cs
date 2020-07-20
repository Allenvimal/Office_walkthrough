using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    float buffer = 0.05f;

    public float rotationalSpeed;

    float xRorate;
    new public GameObject camera;

    UIManager uIManager;

    public AudioSource sfxAudio;
    public AudioClip clickSound;

    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        var horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(horizontal, 0f, vertical);

        var hRotation = Input.GetAxis("Mouse X") * rotationalSpeed * Time.deltaTime;
        var vRotation = Input.GetAxis("Mouse Y") * rotationalSpeed * Time.deltaTime;

        xRorate -= vRotation;
        xRorate = Mathf.Clamp(xRorate, -75f, 75f);
        camera.transform.localRotation = Quaternion.Euler(xRorate, 0f, 0f);

        transform.Rotate(Vector3.up * hRotation);

        PointerControl();

    }

    void PointerControl()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.5f))
        {
            if (hit.collider.tag == "Interactable")
            {
                uIManager.OnInetractableObjectEnter();

                if (Input.GetMouseButtonDown(0))
                {
                    //Interaction action;
                    hit.collider.gameObject.GetComponent<InterfaceScripts>().OnInteraction();
                    sfxAudio.PlayOneShot(clickSound);
                }
            }
            else
            {
                uIManager.OnInetractableObjectExit();
            }

        }
        else
        {
            uIManager.OnInetractableObjectExit();
        }
    }
}
