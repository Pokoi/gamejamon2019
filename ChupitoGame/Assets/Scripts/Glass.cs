using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{

    //RigidBody
    [HideInInspector]
    public Rigidbody2D rb;
    //Direccion a la que va
    [HideInInspector]
    public bool IsLeft = true;
    //Si está agarrado
    [HideInInspector]
    public bool agarrado = false;
    //GlassManager
    [HideInInspector]
    public GlassManager GlassManager;

    //Determina el movimiento
    public int force_magnitude = 10;
    public int torque_multiplier = 50;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        #region movimiento

        if (!agarrado)
        {
            //Vector que calcula la posicion
            Vector3 tempVect;

            //Movimiento
            if (IsLeft)
                tempVect = Vector3.left * 2 * Time.deltaTime;
            else
                tempVect = Vector3.right * 2 * Time.deltaTime;

            transform.position += tempVect;
        }

        #endregion

        #region Lanzamiento
        else
        {
            if (Input.GetMouseButtonDown(0)) ThrowRigidbody();
        }
        #endregion

    }

    private void ThrowRigidbody()
    {
        rb.WakeUp();
        rb.AddForce(rb.transform.right * force_magnitude, ForceMode2D.Impulse);
        rb.AddTorque(force_magnitude * torque_multiplier);
    }
}
