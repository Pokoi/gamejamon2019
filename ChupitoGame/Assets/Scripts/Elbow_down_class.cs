using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elbow_down_class : Joints_class
{
    private float delta_time;
    public override void KeepKeyPress()
    {
        RotateDown(delta_time);
        //throw new System.NotImplementedException();
    }

    public override void KeepKeyUp()
    {
        //throw new System.NotImplementedException();
    }

    public override void KeyDown()
    {
        //throw new System.NotImplementedException();
    }

    public override void KeyUp()
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    public void Start(Transform joint_transform, float max_angle, float min_angle, KeyCode active_key, float aceleration_axis, float speed_animation)
    {
        JointStart(joint_transform, max_angle, min_angle, active_key, aceleration_axis, speed_animation);

    }

    // Update is called once per frame
    public void Update(float deltaTime)
    {
        delta_time = deltaTime;
        JointUpdate(delta_time);

    }
}
