using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{

    //RigidBody
    [HideInInspector]
    private Rigidbody2D rb;
    //Direccion a la que va
    [HideInInspector]
    public bool IsLeft = true;
    //Si está agarrado
    [HideInInspector]
    public bool agarrado = false;
    //GlassManager
    [HideInInspector]
    public GlassManager GlassManager;
    //indica si el vaso esta lleno o vacio 
    private bool full;

    //Determinar si el objeto esta activo
    [HideInInspector]
    public bool isActive = true;

    //Determina el movimiento
    public int force_magnitude = 10;
    public int torque_multiplier = 50;

    //Render del objeto
    private Renderer render;

    //Mesa
    private GameObject table;

    //En el aire
    private bool onAir = false;

    //Hand reference
    [HideInInspector]
    public GameObject hand;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
        table = GameObject.Find("Table");
        full = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
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
                if (Input.GetKeyDown(KeyCode.Space) && !onAir) {
                    ThrowRigidbody();
                }
            }
            #endregion

            #region ComprobarVision
            if (transform.position.y < table.transform.position.y - 2)
                GlassManager.RemoveGlass(this.gameObject);
            #endregion
        }

    }

    internal void restartObject(GameObject _padre)
    {
        isActive = true;
        this.gameObject.SetActive(true);
        agarrado = false;
        GlassManager = _padre.GetComponent<GlassManager>();
        IsLeft = GlassManager.direccionDeSpawnIsLeft;
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.WakeUp();
        }
        hand = null;
        onAir = false;
    }

    private void ThrowRigidbody()
    {
        onAir = true;
        rb.isKinematic = false;
        rb.WakeUp();
        var multiplicador = GlassManager.player_manager.my_shoulder.GetAxixValue();

        rb.AddForce(rb.transform.right * force_magnitude * multiplicador, ForceMode2D.Impulse);
        rb.AddTorque(force_magnitude * torque_multiplier);
        this.transform.parent = GlassManager.poolGlass.transform;

    }
    public bool GetContentGlass() { return full; }
    public void DrinkGlass() { full = false; }




}
