using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTiger : MonoBehaviour
{
    [SerializeField] float bounceSpeed = 0.01f;
    [SerializeField] float bounceAmplitude = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float side = Mathf.Sin(Time.time*bounceSpeed)*bounceAmplitude;
       Vector3 temp = transform.localPosition;
       temp.z = side;
       transform.localPosition = temp;
    }
}
