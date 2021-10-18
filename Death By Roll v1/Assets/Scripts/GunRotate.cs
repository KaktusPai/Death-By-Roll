using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    public GameObject gun;
    public Vector3 tempPosition;

    void Start()
    {
        tempPosition = Vector3.zero;
    }

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        //Change Z index to -1 or 1 depending on front or behind character
        if (transform.rotation.z >= 0)
        {
            tempPosition = gun.transform.position;
            tempPosition.z = 2;
            gun.transform.position = tempPosition;
        } else if (transform.rotation.z < 0)
        {
            tempPosition = gun.transform.position;
            tempPosition.z = -2;
            gun.transform.position = tempPosition;
        }
    }

}
