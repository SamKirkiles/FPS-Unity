using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_vertical = Input.GetAxis("Mouse Y");
        gameObject.transform.Rotate(-mouse_vertical, 0, 0);
    }
}
