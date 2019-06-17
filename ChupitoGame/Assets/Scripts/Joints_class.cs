using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Joints_class
{
    //maxima apertura que puede alcanzar la articulación 
    public float max_angle;
    //minimo angulo que puede alcanzar la articulación
    public float min_angle;
    //el valor del angulo
    private float axis_value = 0;
    //tecla que acciona la articulación
    public KeyCode active_key;
    //velocidad con la que se incrementa el axis value
    public float aceleration_animation;


    void Update(float deltaTime)
    {
        if (Input.GetKey(active_key))
        {
            KeepKeyPress();
            if (axis_value <= 1)
                axis_value += deltaTime * aceleration_animation;

        }
        else
        {
            if (axis_value >= 0)
                axis_value -= deltaTime * aceleration_animation;
        }
        if (Input.GetKeyDown(active_key))
        {
            KeyDown();
        }
        if (Input.GetKeyUp(active_key))
        {
            KeyUp();
        }


    }

  
    public float GetAxixValue() {
        return axis_value;
    }
    public abstract void KeepKeyPress();
    public abstract void KeyDown();
    public abstract void KeyUp();
}
