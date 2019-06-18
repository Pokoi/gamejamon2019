using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_creator : MonoBehaviour
{
    public int points;
    public int sake;
    public int vodka;
    public int absenta;
    public int whisky;
    public int wine;

    public int points_2;
    public int sake_2;
    public int vodka_2;
    public int absenta_2;
    public int whisky_2;
    public int wine_2;
    public GameObject[] buttons_sake;
    public GameObject[] buttons_vodka;
    public GameObject[] buttons_absenta;
    public GameObject[] buttons_whisky;
    public GameObject[] buttons_wine;
    public Text puntos_player_1;
    public GameObject[] buttons_sake_2;
    public GameObject[] buttons_vodka_2;
    public GameObject[] buttons_absenta_2;
    public GameObject[] buttons_whisky_2;
    public GameObject[] buttons_wine_2;
    public Text puntos_player_2;

    public void SetPointsSake(int n)
    {
        points += sake;
        if (points >= n)
        {
            
            sake = n;
            points -= n;
        }
        else
        {
            sake = points;
            points = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            buttons_sake[i].gameObject.GetComponent<Image>().color = new Color32(138, 138, 138,255);
        }
        for (int i = 0; i < 10; i++)
        {
            if (i < sake)
                buttons_sake[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255,255);
            //else
            //    buttons_sake[i].gameObject.GetComponent<Image>().color = new Color(138, 138, 138);
        }
        puntos_player_1.text = points.ToString() + "/10";

    }
    public void SetPointsVodka(int n)
    {
        points += vodka;
        if (points >= n)
        {
            
            vodka = n;
            points -= n;
        }
        else
        {
            vodka = points;
            points = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            buttons_vodka[i].gameObject.GetComponent<Image>().color = new Color32(138, 138, 138, 255);
        }
        for (int i = 0; i < 10; i++)
        {
            if (i < vodka)
                buttons_vodka[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //else
            //    buttons_sake[i].gameObject.GetComponent<Image>().color = new Color(138, 138, 138);
        }
        puntos_player_1.text = points.ToString() + "/10";
    }
    public void SetPointsAbsenta(int n)
    {
        points += absenta;
        if (points >= n)
        {

            absenta = n;
            points -= n;
        }
        else
        {
            absenta = points;
            points = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            buttons_absenta[i].gameObject.GetComponent<Image>().color = new Color32(138, 138, 138, 255);
        }
        for (int i = 0; i < 10; i++)
        {
            if (i < absenta)
                buttons_absenta[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //else
            //    buttons_sake[i].gameObject.GetComponent<Image>().color = new Color(138, 138, 138);
        }
        puntos_player_1.text = points.ToString() + "/10";
    }
    public void SetPointsWhisky(int n)
    {
        points += whisky;
        if (points >= n)
        {

            whisky = n;
            points -= n;
        }
        else
        {
            whisky = points;
            points = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            buttons_whisky[i].gameObject.GetComponent<Image>().color = new Color32(138, 138, 138, 255);
        }
        for (int i = 0; i < 10; i++)
        {
            if (i < whisky)
                buttons_whisky[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //else
            //    buttons_sake[i].gameObject.GetComponent<Image>().color = new Color(138, 138, 138);
        }
        puntos_player_1.text = points.ToString() + "/10";
    }
    public void SetPointsWine(int n)
    {
        points += wine;
        if (points >= n)
        {

            wine = n;
            points -= n;
        }
        else
        {
            wine = points;
            points = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            buttons_wine[i].gameObject.GetComponent<Image>().color = new Color32(138, 138, 138, 255);
        }
        for (int i = 0; i < 10; i++)
        {
            if (i < wine)
                buttons_wine[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //else
            //    buttons_sake[i].gameObject.GetComponent<Image>().color = new Color(138, 138, 138);
        }
        puntos_player_1.text = points.ToString() + "/10";
    }


    public void SetPointsSake2(int n)
    {
        points_2 += sake_2;
        if (points_2 >= n)
        {

            sake_2 = n;
            points_2 -= n;
        }
        else
        {
            sake_2 = points_2;
            points_2 = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            buttons_sake_2[i].gameObject.GetComponent<Image>().color = new Color32(138, 138, 138, 255);
        }
        for (int i = 0; i < 10; i++)
        {
            if (i < sake_2)
                buttons_sake_2[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //else
            //    buttons_sake[i].gameObject.GetComponent<Image>().color = new Color(138, 138, 138);
        }
        puntos_player_2.text = points.ToString() + "/10";

    }
    public void SetPointsVodka2(int n)
    {
        points_2 += vodka_2;
        if (points_2 >= n)
        {

            vodka_2 = n;
            points_2 -= n;
        }
        else
        {
            vodka_2 = points_2;
            points_2 = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            buttons_vodka_2[i].gameObject.GetComponent<Image>().color = new Color32(138, 138, 138, 255);
        }
        for (int i = 0; i < 10; i++)
        {
            if (i < vodka_2)
                buttons_vodka_2[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //else
            //    buttons_sake[i].gameObject.GetComponent<Image>().color = new Color(138, 138, 138);
        }
        puntos_player_2.text = points.ToString() + "/10";
    }
    public void SetPointsAbsenta2(int n)
    {
        points_2 += absenta_2;
        if (points_2 >= n)
        {

            absenta_2 = n;
            points_2 -= n;
        }
        else
        {
            absenta_2 = points_2;
            points_2 = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            buttons_absenta_2[i].gameObject.GetComponent<Image>().color = new Color32(138, 138, 138, 255);
        }
        for (int i = 0; i < 10; i++)
        {
            if (i < absenta_2)
                buttons_absenta_2[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //else
            //    buttons_sake[i].gameObject.GetComponent<Image>().color = new Color(138, 138, 138);
        }
        puntos_player_2.text = points.ToString() + "/10";
    }
    public void SetPointsWhisky2(int n)
    {
        points_2 += whisky_2;
        if (points_2 >= n)
        {

            whisky_2 = n;
            points_2 -= n;
        }
        else
        {
            whisky_2 = points_2;
            points_2 = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            buttons_whisky_2[i].gameObject.GetComponent<Image>().color = new Color32(138, 138, 138, 255);
        }
        for (int i = 0; i < 10; i++)
        {
            if (i < whisky_2)
                buttons_whisky_2[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //else
            //    buttons_sake[i].gameObject.GetComponent<Image>().color = new Color(138, 138, 138);
        }
        puntos_player_2.text = points.ToString() + "/10";
    }
    public void SetPointsWine2(int n)
    {
        points_2 += wine_2;
        if (points_2 >= n)
        {

            wine_2 = n;
            points_2 -= n;
        }
        else
        {
            wine_2 = points_2;
            points_2 = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            buttons_wine_2[i].gameObject.GetComponent<Image>().color = new Color32(138, 138, 138, 255);
        }
        for (int i = 0; i < 10; i++)
        {
            if (i < wine_2)
                buttons_wine_2[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //else
            //    buttons_sake[i].gameObject.GetComponent<Image>().color = new Color(138, 138, 138);
        }
        puntos_player_2.text = points.ToString() + "/10";
    }

}
