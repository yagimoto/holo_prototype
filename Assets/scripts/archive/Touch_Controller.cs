using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Controller : MonoBehaviour
{
    public Camera camera;

    public float sensitivity = 0.01f;
    
    public GameObject cube;
    
    public enum Mode
    {
        MoveCamera,
        ChangeScale,
        ChangePos,
        ChangeColor,
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private float x = 0;
    
    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(0);

        
        if (Input.touchCount == 2)
        {
            cube.transform.localScale = new Vector3(Vector3.one.x + touch.deltaPosition.magnitude, Vector3.one.y + touch.deltaPosition.magnitude, Vector3.one.z + touch.deltaPosition.magnitude);
            //camera.transform.Translate(-touch.deltaPosition * sensitivity);
            
        } else if (Input.touchCount == 1)
        {

            Vector3 rot = camera.transform.rotation.eulerAngles;
            rot.x += -touch.deltaPosition.y * 0.05f;
            rot.y += -touch.deltaPosition.x * 0.05f;
            
            camera.transform.rotation = Quaternion.Euler(rot);
        }

    }
    
    public void changeMode()
}
