using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Joints_class
{
    //maxima apertura que puede alcanzar la articulación 
    public float max_angle;
    //minimo angulo que puede alcanzar la articulación
    public float min_angle;
    //angulo actual
    private float current_angle;
    //el valor del angulo
    private float axis_value = 0;
    public float max_last_axis_value = 0;
    //tecla que acciona la articulación
    public KeyCode active_key;
    //velocidad con la que se incrementa el axis value
    public float speed_animation;
    public float aceleration_axis;
    private Transform my_transform;

    protected void JointStart(Transform joint_transform, float max_angle, float min_angle, KeyCode active_key, float aceleration_axis, float speed_animation)
    {
        my_transform = joint_transform;
        this.max_angle = max_angle;
        this.min_angle = min_angle;
        this.active_key = active_key;
        this.aceleration_axis = aceleration_axis;
        this.speed_animation = speed_animation;
    }


    protected void JointUpdate(float deltaTime)
    {
        if (Input.GetKey(active_key))
        {
            KeepKeyPress();
            if (axis_value <= 1) 
                axis_value += deltaTime * aceleration_axis;

            if (axis_value > 1)
                axis_value = 1;
               
            max_last_axis_value = axis_value;

        }
        else
        {
            KeepKeyUp();
            axis_value = 0;
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


    protected void RotateUp(float deltaTime)
    {
        if(my_transform.localEulerAngles.z <= max_angle)
            my_transform.localEulerAngles += new Vector3(0,0,1) * axis_value* speed_animation * deltaTime;
       
    }
    protected void RotateDown(float deltaTime)
    {
        if(my_transform.localEulerAngles.z >= min_angle)
            my_transform.localEulerAngles -= new Vector3(0, 0, 1) * axis_value * speed_animation * deltaTime;

    }
    protected void RestoreDown(float deltaTime)
    {
        if (my_transform.eulerAngles.z >= min_angle)
            my_transform.eulerAngles -= new Vector3(0, 0, 1) * max_last_axis_value * speed_animation * deltaTime;
    }
    public float GetAxixValue() {
        return axis_value;
    }
    public abstract void KeepKeyPress();
    public abstract void KeepKeyUp();
    public abstract void KeyDown();
    public abstract void KeyUp();
}
