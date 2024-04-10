using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controlChanger : MonoBehaviour
{
    PlayerInput control;
    bool isDroneInputEnabled;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<PlayerInput>();
        isDroneInputEnabled = false; // Ensure the initial state is set correctly
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any necessary update logic here if needed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isDroneInputEnabled)
            {
                // Disable Drone_Inputs and enable XRI Default Input Actions
                control.actions["Drone_Inputs"].Disable();
                control.actions["XRI Default Input Actions"].Enable();
                isDroneInputEnabled = false;
            }
            else
            {
                // Enable Drone_Inputs and disable XRI Default Input Actions
                control.actions["XRI Default Input Actions"].Disable();
                control.actions["Drone_Inputs"].Enable();
                isDroneInputEnabled = true;
            }
        }
    }
}
