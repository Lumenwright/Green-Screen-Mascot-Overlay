using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneParameters : MonoBehaviour
{
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

    }

    public void UpdateShadowOpacity(float opacity){
        renderer.material.SetFloat("_ShadowIntensity", opacity);
        PlayerPrefs.SetFloat(Parameters.ShadowOpacity, opacity);
    }

}
