using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_manager : MonoBehaviour
{
    public GameObject body;
    private Mouth_class mouth;
    private Glass last_glass_class;
    public GameObject myHand;

    #region player states
    public enum player_number { player_1, player_2 };
    public player_number my_player;
    public float alcohol_stamina;
    public float MAX_ALCOHOL_STAMINA;
    public float drinked_glasses;
    public float sake;
    public float vodka;
    public float absenta;
    public float whisky;
    public float wine;
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
    private Image barraBorracho;
    public TextMesh pointText;
    #endregion

    //Si es el player de la izquierda
    public bool isPlayerLeft;

    //Referencia al gameManager
    private Game_manager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        //normalizamos los valores 
        sake = sake / 10;
        vodka = vodka / 10;
        absenta = absenta / 10;
        whisky = whisky / 10;
        wine = wine / 10;

        mouth = body.GetComponent<Mouth_class>();
        my_shoulder = new Shoulder_class();
        my_elbow_up = new Elbow_up_class();
        my_elbow_down = new Elbow_down_class();
        if (my_player == player_number.player_1)
        {
            sake = PlayerPrefs.GetInt("sake");
            vodka = PlayerPrefs.GetInt("vodka");
            absenta = PlayerPrefs.GetInt("absenta");
            whisky = PlayerPrefs.GetInt("whisky");
            wine = PlayerPrefs.GetInt("wine");
            my_shoulder.Start(my_shoulder_transform, max_angle_shoulder, min_angle_shoulder, active_key_shoulder, aceleration_axis_shoulder, speed_animation_shoulder, true);

        }
        else
        {
            sake = PlayerPrefs.GetInt("sake_2");
            vodka = PlayerPrefs.GetInt("vodka_2");
            absenta = PlayerPrefs.GetInt("absenta_2");
            whisky = PlayerPrefs.GetInt("whisky_2");
            wine = PlayerPrefs.GetInt("wine_2");
            my_shoulder.Start(my_shoulder_transform, max_angle_shoulder, min_angle_shoulder, active_key_shoulder, aceleration_axis_shoulder, speed_animation_shoulder, false);

        }

        my_elbow_up.Start(my_elbow_transform, max_angle_elbow, min_angle_elbow, active_key_elbow_up, aceleration_axis_elbow, speed_animation_elbow);
        my_elbow_down.Start(my_elbow_transform, max_angle_elbow, min_angle_elbow, active_key_elbow_down, aceleration_axis_elbow, speed_animation_elbow);

        //HUD
        if (isPlayerLeft)
            barraBorracho = GameObject.Find("Fill Amonut Left").GetComponent<Image>();
        else
            barraBorracho = GameObject.Find("Fill Amonut Right").GetComponent<Image>();

        //Referencia al gameManager
        GameManager = GameObject.Find("GameManager").GetComponent<Game_manager>();

        drinked_glasses = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPlaying())
        {

            my_shoulder.Update(Time.deltaTime);
            my_elbow_up.Update(Time.deltaTime);
            my_elbow_down.Update(Time.deltaTime);
            my_shoulder.SetControlFeeling(alcohol_stamina, MAX_ALCOHOL_STAMINA);
            my_elbow_up.SetControlFeeling(alcohol_stamina, MAX_ALCOHOL_STAMINA);
            my_elbow_down.SetControlFeeling(alcohol_stamina, MAX_ALCOHOL_STAMINA);


            if (mouth.GetDrinkedGlass())
            {
                last_glass_class = mouth.GetLastGlass();
                drinked_glasses++;
                switch (last_glass_class.my_shot)
                {
                    case Glass.kind_shot.sake:
                        alcohol_stamina += 30 * (1 - sake);
                        break;
                    case Glass.kind_shot.absenta:
                        alcohol_stamina += 30 * (1 - absenta);
                        break;
                    case Glass.kind_shot.vodka:
                        alcohol_stamina += 30 * (1 - vodka);
                        break;
                    case Glass.kind_shot.whisky:
                        alcohol_stamina += 30 * (1 - whisky);
                        break;
                    case Glass.kind_shot.wine:
                        alcohol_stamina += 30 * (1 - wine);
                        break;
                    default:
                        alcohol_stamina += 30;
                        break;
                }
            };
            alcohol_stamina = alcohol_stamina - 0.05 < 0 ? 0 : alcohol_stamina - 0.05F;
            barraBorracho.fillAmount = (alcohol_stamina / MAX_ALCOHOL_STAMINA);
        }

        pointText.text = drinked_glasses.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var glass = collision.gameObject.GetComponent<Glass>();
        if (glass && glass.hand != null && glass.hand != myHand)
        {
            drinked_glasses -= 0.5f;
        }
    }
}
