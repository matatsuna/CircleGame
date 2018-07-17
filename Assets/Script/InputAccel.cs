using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAccel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        Vector3 dir = Vector3.zero;
        float r = 15.0f;
        float x = -Input.acceleration.x;
        float y = Input.acceleration.y;
        float rad = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
        float theta = Mathf.Atan2(x, y) - Mathf.PI / 2;

        dir.x = r * Mathf.Cos(theta);
        dir.y = 1;
        dir.z = r * Mathf.Sin(theta);
        transform.position = dir;

        var target = Quaternion.Euler(new Vector3(0, -rad, 0));
        transform.rotation = target;

    }
}
