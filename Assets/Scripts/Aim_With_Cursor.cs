using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_With_Cursor : MonoBehaviour
{
    public float maxRotationAngle = 45f;
    public float minRotationAngle = -3f;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        

        Vector3 direction = mousePosition - transform.position;
        //using Atan(Ratio to Angles)
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;

        angle = Mathf.Clamp(angle, minRotationAngle, maxRotationAngle);

        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
    }
}
