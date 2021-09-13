using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    // Player references

    // Player variables
    public int ammo;
    public int maxAmmo;
    // GUI References
    public TMP_Text ammoText;
    
    void Start()
    {
        // Set values to maxvalue at start
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {


        // Update GUI
        ammoText.text = ammo.ToString() + "/" + maxAmmo.ToString();
    }
}
