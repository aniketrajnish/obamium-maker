using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToRotate : MonoBehaviour
{
    [SerializeField] float sensitivity;
    Vector3 mouseReference;
    Vector3 mouseOffset;  

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                mouseOffset = (Input.mousePosition - mouseReference);
                float rot = -(mouseOffset.x + mouseOffset.y) * sensitivity;
                transform.Rotate(new Vector3(0, 0, rot));
            }
            mouseReference = Input.mousePosition;
        }
        
    }

    
}
