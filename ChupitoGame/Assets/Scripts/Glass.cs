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
    public int force_magnitude = 500;
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

    public enum kind_shot {sake,vodka,absenta,wine,whisky};
    public kind_shot my_shot;

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
                if (Input.GetKeyDown(KeyCode.Space) && !onAir)
                {
                    ThrowRigidbody();
                }
            }
            #endregion

            #region ComprobarVision
            if (transform.position.y < table.transform.position.y - 2)
                destroy();
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
        full = true;
        GetComponent<Collider2D>().isTrigger = false;
    }

    private void ThrowRigidbody()
    {
        onAir = true;
        rb.isKinematic = false;
        rb.WakeUp();
        var multiplicador = 1;//(GlassManager.player_manager.my_shoulder.GetAxixValue() + GlassManager.player_manager.my_elbow_down.GetAxixValue() + GlassManager.player_manager.my_elbow_up.GetAxixValue())/3;
        rb.AddForce(rb.transform.right * force_magnitude * multiplicador, ForceMode2D.Impulse);
        Debug.Log(force_magnitude * multiplicador + " axis: " + multiplicador);
        rb.AddTorque(force_magnitude * torque_multiplier);
        this.transform.parent = GlassManager.poolGlass.transform;
        Invoke("destroy", 5);

    }
    public bool GetContentGlass() { return full; }
    public void DrinkGlass() { full = false; }
    public void destroy() {
        CancelInvoke("destroy");
        GlassManager.RemoveGlass(this.gameObject);
    }

    public void removeCollider() {
        GetComponent<Collider2D>().isTrigger = true;
    }




}
