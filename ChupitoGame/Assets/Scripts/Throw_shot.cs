using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_shot : MonoBehaviour
{
    public Rigidbody2D rigidbody_to_move;
    public int force_magnitude   = 10;
    public int torque_multiplier = 50;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody_to_move.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) ThrowRigidbody();     
    }

    void ThrowRigidbody()
    {
        rigidbody_to_move.WakeUp();
        rigidbody_to_move.AddForce(rigidbody_to_move.transform.right * force_magnitude, ForceMode2D.Impulse);
        rigidbody_to_move.AddTorque(force_magnitude * torque_multiplier);
    }
   
}
