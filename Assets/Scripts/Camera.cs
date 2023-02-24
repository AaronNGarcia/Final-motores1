using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float sensitivity = 1f;
    private Vector3 rotate;
    float x;
    public float tiempo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()   
    {
        tiempo = Time.deltaTime;
          
        if (tiempo == 0)
        {

        }
        else
        {
            x = Input.GetAxis("Mouse Y");
            rotate = new Vector3(x * sensitivity, 0);
            transform.eulerAngles = transform.eulerAngles - rotate;
        }


    }
    

}

