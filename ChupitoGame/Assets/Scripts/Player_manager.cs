using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_manager : MonoBehaviour
{
    public GameObject body;
    private Mouth_class mouth;
    #region player states
    public float alcohol_stamina;
    public float MAX_ALCOHOL_STAMINA;
    public int drinked_glasses;
    public float sake;
    public float vodka;
    public float ron;
    public float whisky;
    public float vino;
    #endregion

    #region shoulder
    public Shoulder_class my_shoulder;
    public Transform my_shoulder_transform;
    public float max_angle_shoulder;
    public float min_angle_shoulder;
    public float aceleration_axis_shoulder;
    public float speed_animation_shoulder;
    public KeyCode active_key_shoulder;
    #endregion

    #region elbow
    public Elbow_up_class my_elbow_up;
    public Elbow_down_class my_elbow_down;
    public Transform my_elbow_transform;
    public float max_angle_elbow;
    public float min_angle_elbow;
    public float aceleration_axis_elbow;
    public float speed_animation_elbow;
    public KeyCode active_key_elbow_up;
    public KeyCode active_key_elbow_down;
    #endregion

    #region HUD
    private Image BarraborrachoLeft;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        mouth = body.GetComponent<Mouth_class>();
        my_shoulder = new Shoulder_class();
        my_elbow_up = new Elbow_up_class();
        my_elbow_down = new Elbow_down_class();
        my_shoulder.Start(my_shoulder_transform, max_angle_shoulder, min_angle_shoulder, active_key_shoulder, aceleration_axis_shoulder,speed_animation_shoulder);
        my_elbow_up.Start(my_elbow_transform, max_angle_elbow, min_angle_elbow, active_key_elbow_up, aceleration_axis_elbow,speed_animation_elbow);
        my_elbow_down.Start(my_elbow_transform, max_angle_elbow, min_angle_elbow, active_key_elbow_down, aceleration_axis_elbow,speed_animation_elbow);

        //HUD
        BarraborrachoLeft = GameObject.Find("Fill Amonut Left").GetComponent<Image>();

        
        drinked_glasses = 0;
    }

    // Update is called once per frame
    void Update()
    {
        my_shoulder.Update(Time.deltaTime);
        my_elbow_up.Update(Time.deltaTime);
        my_elbow_down.Update(Time.deltaTime);
        drinked_glasses += mouth.GetDrinkedGlass();
        alcohol_stamina = drinked_glasses * 10;
        BarraborrachoLeft.fillAmount = (alcohol_stamina * MAX_ALCOHOL_STAMINA) / 100;
        

        
    }

}
