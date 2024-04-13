using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwitch : MonoBehaviour
{
    public GameObject locomotionSystem;
    public Rigidbody droneRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void SwitchToDrone()
    {
        locomotionSystem.gameObject.SetActive(false);
        droneRB.isKinematic = true;
    }

    public void SwitchOffDrone()
    {
        locomotionSystem.gameObject.SetActive(true);
        droneRB.isKinematic = false;
    }

}
