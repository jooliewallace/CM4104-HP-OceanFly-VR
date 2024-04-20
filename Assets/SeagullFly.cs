using UnityEngine;

public class SeagullFly : MonoBehaviour
{
    public float speed = 3f;

    Rigidbody seagullRigidbody;
    Animator seagullAnimator;

    void Start()
    {
        seagullRigidbody = GetComponent<Rigidbody>();
        seagullAnimator = GetComponent<Animator>();
        //StartFlying();
    }

    void Update()
    {
        // Move forward
        seagullRigidbody.velocity = transform.forward * speed;
    }

    //void StartFlying()
    //{
    //    seagullAnimator.SetTrigger("Flap");
    //}
}
