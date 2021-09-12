using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRolling : MonoBehaviour
{
    public static bool IsRollin;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    public static void roll()
    {
        Debug.Log("Rol begin");
        IsRollin = true;
    }

    // Update is called once per frame
    public void RollEnd()
    {
        Debug.Log("Rol eindig");
        IsRollin = false;
        transform.Rotate(0, 0, 0);
        //transform.localScale = Vector3.one;
    }
}
