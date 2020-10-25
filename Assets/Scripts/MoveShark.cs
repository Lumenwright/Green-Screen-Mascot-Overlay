using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// Put this on the thing with the renderer
///
public class MoveShark : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 0.1f;
    [SerializeField] float bounceSpeed = 0.1f;
    [SerializeField] float bounceAmplitude = 0.001f;
    [SerializeField] Transform root;
    [SerializeField] Transform plane;
    Renderer renderer;
    float startY;

// methods for the sliders to pass values into
    public void UpdateBounceAmplitude(float amount){
        bounceAmplitude = amount;
        PlayerPrefs.SetFloat(Parameters.BounceHeight, amount);
    }
    public void UpdateBounceSpeed(float amount){
        bounceSpeed = amount;
        PlayerPrefs.SetFloat(Parameters.BounceSpeed, amount);
    }
    public void UpdateForwardSpeed(float amount){
        forwardSpeed = amount;
        PlayerPrefs.SetFloat(Parameters.ForwardSpeed, amount);
    }
    public void UpdateHeight(float amount){
        startY = amount;
        PlayerPrefs.SetFloat(Parameters.Height, amount);
    }

    public void UpdatePlaneHeight(float amount){
        Vector3 planeT = plane.position;
        planeT.y = amount;
        plane.position = planeT;
    }
    public void UpdateScale(float scaleFactor){
        root.localScale = scaleFactor * Vector3.one;
        PlayerPrefs.SetFloat(Parameters.Scale, scaleFactor);
    }

    void Start(){
        startY = root.position.y;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float up = Mathf.Sin(Time.time*bounceSpeed)*bounceAmplitude + startY;
       Vector3 temp = root.position;
       temp.y = up;
       root.position = temp;
       root.Translate(Vector3.forward*forwardSpeed);
    }

    void OnBecameInvisible()
    {
        root.transform.rotation = root.transform.rotation*Quaternion.Euler(180f*Vector3.up);
        Vector3 temp = root.position;
        temp.y = startY;
        root.position = temp;
    }

    public void HideShark(){
        root.gameObject.SetActive(false);
    }

    public void ResetShark(){
        root.gameObject.SetActive(true);
        Vector2 screenMax = Camera.main.WorldToScreenPoint(renderer.bounds.max);
        Vector2 screenMin = Camera.main.WorldToScreenPoint(renderer.bounds.min);
        while((screenMax.x > 0 && screenMax.x < 1) ||( screenMin.x > 0 && screenMin.x <1) ){
        root.transform.position += Vector3.forward;
        }
        OnBecameInvisible();
    }
}
