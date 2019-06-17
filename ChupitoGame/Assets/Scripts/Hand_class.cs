using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_class : MonoBehaviour
{
    //Sprite de la mano
    private SpriteRenderer sprite;

    //Agarrando
    [HideInInspector]
    public bool agarrando;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.blue;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) CatchGlass();
        else { sprite.color = Color.blue; agarrando = false; }

    }

    private void CatchGlass()
    {
        sprite.color = Color.red;
        agarrando = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var glassComponent = other.gameObject.GetComponent<Glass>();
        if (agarrando && glassComponent != null && this.transform.childCount <= 0 && glassComponent.hand != this.gameObject) {
            other.gameObject.transform.parent = this.transform;
            glassComponent.hand = this.gameObject;
            glassComponent.agarrado = true;
            glassComponent.gameObject.GetComponent<Rigidbody2D>().Sleep();
        }
    }


}
