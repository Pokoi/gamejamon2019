using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_class : MonoBehaviour
{
    //Sprite de la mano
    private SpriteRenderer hand_sprite;
    private SpriteRenderer hand_glass_sprite;
    public GameObject other_hand;

    public bool isleftHand;    

    //Agarrando
    [HideInInspector]
    public bool agarrando;

    //Key code
    public KeyCode myControl;

    // Start is called before the first frame update
    void Start()
    {
        hand_glass_sprite = other_hand.GetComponent<SpriteRenderer>();
        hand_sprite = GetComponent<SpriteRenderer>();
        //hand_sprite.color = Color.blue;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(myControl)) CatchGlass();
        else {
            agarrando = false;
           
        }

    }

    private void CatchGlass()
    { 
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
            glassComponent.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            glassComponent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            hand_sprite.enabled = false;
            hand_glass_sprite.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<Glass>())
        {
            other.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            hand_sprite.enabled = true;
            hand_glass_sprite.enabled = false;

        }

    }


}
