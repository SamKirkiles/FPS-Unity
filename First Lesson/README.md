# Section 1 - First Person Player Movement and Mouse Look 

Add a capsule to the scene and attach a Camera as a child. In the inspector, add a rigid body component.

![Image of Yaktocat](https://i.imgur.com/sueh0nH.png)

We need to add a script to control the player character. Add a script component to the main player character called PlayerMove.

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody rb; // Create a reference to the rigid body of this game object

    // Start is called before the first frame update
    void Start()
    { 
      // Start code here..
    }

    // Update is called once per frame
    void Update()
    {
      // Update code here...
    }
}
```

In the start method, we need to access the rigid body component we added in the inspector. 

```
// Add this to void Start()

// Turn off the cursor
Cursor.visible = false;
Cursor.lockState = CursorLockMode.Locked;


rb = GetComponent<Rigidbody>(); // Get access to the rigid body of the player capsule
```

In the update method, we need to check if the move controls are pressed down.

```

// Add this to void Update()

float horizontal = Input.GetAxis("Horizontal"); // returns a value between -1 and 1 depending on if a or d is pressed down
float vertical = Input.GetAxis("Vertical"); // returns a value between -1 and 1 depending on if w or s is pressed down

rb.AddForce(horizontal, 0, 0);
rb.AddForce(0, 0, vertical);
```

Now, if we run our game, the capsule will keep rolling on its head when we press the move keys! To fix this, we need to lock rotation on the rigid body component in the right inspector to the Y axis only as follows.


![Image of Yaktocat](https://i.imgur.com/SQmQc83.png)

Create a new script on the camera called MouseLook. We want moving the mouse up and down to make the player look up and down. To do this we need to get the mouse data and apply it as a rotation to the camera. 


```
// Add to the Update method of MouseLook.cs

float mouse_vertical = Input.GetAxis("Mouse Y");
gameObject.transform.Rotate(-mouse_vertical, 0, 0);

```

We have a major issue though, we can rotate the mouse all the way around 360. This is certainly not good. To fix this, we need to clam the values of the mouse so that it can't rotate more than 90 degrees up or down. To fix this, we will clamp the value of our rotation between 90 degrees up and down.

```
        float mouse_vertical = Input.GetAxis("Mouse Y");

        myrotation = Mathf.Clamp(myrotation - mouse_vertical, -90f, 90f);

        gameObject.transform.localRotation = Quaternion.Euler(myrotation, 0f, 0f);
```

# Section 2 - Fixing the Timing Issues

Different computers run at different speeds. Our method void Update() is called every frame. However, if one computer is running at 60 fps and one is running at 30, the player will move and look around twice as fast on the 60 fps comptuer as the 30 fps computer. To fix this, we need to use a property called `Time.deltaTime` which holds the time in seconds since the last frame. If we multiply the amount we move our mouse by by time.deltaTime, we will have a consistent speed across all computers which run our game.

In `PlayerMove.cs`, update our code to the following:

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody rb;
    public float movementSpeed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // returns a value between -1 and 1 depending on if a or d is pressed down
        float vertical = Input.GetAxis("Vertical"); // returns a value between -1 and 1 depending on if w or s is pressed down

        rb.AddRelativeForce(horizontal * Time.deltaTime * movementSpeed, 0, 0);
        rb.AddRelativeForce(0, 0, vertical * Time.deltaTime * movementSpeed);

        // Horizontal Look

        float mouse_horizontal = Input.GetAxis("Mouse X");
        gameObject.transform.Rotate(0,mouse_horizontal,0);


    }
}

```

and in `MouseLook.cs` our code should now look like


```
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
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_vertical = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        myrotation = Mathf.Clamp(myrotation - mouse_vertical, -90f, 90f);

        gameObject.transform.localRotation = Quaternion.Euler(myrotation, 0f, 0f);

    }
}

```

