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



