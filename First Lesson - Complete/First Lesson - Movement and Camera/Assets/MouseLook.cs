using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100;

    float myrotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void LateUpdate()
    {
        float mouse_vertical = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        myrotation = Mathf.Clamp(myrotation - mouse_vertical, -90f, 90f);

        gameObject.transform.localRotation = Quaternion.Euler(myrotation, 0f, 0f);
    }

}
