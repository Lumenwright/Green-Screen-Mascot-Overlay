using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] MoveShark sharkScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if(Input.GetKey(KeyCode.X)){
            canvas.SetActive(!canvas.activeInHierarchy);
        }
    /*    else if((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))){
             if(Input.GetKey(KeyCode.Alpha8)){
                sharkScript.HideShark();
            }
            else if(Input.GetKey(KeyCode.Alpha7))
            {
                sharkScript.ResetShark();
            }
        }*/
        
    }
}
