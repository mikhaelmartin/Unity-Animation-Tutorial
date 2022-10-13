using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLoopAnimation : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    int direction = 1;
    float t = 0;
    void Update()
    {
        // direction change
        if (t > 1 )
            direction = -1;        
        else if(t<0)
            direction = 1;        

        // change t parameter (horizontal axis of the curve)
        t += direction * Time.deltaTime;

        // get value from animationCurve (vertical axis of the curve)
        var y = curve.Evaluate(t);

        // interpolate
        transform.position = startPos + new Vector3(0, y, 0);
    }
}
