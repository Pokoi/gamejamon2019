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
    public GameObject[] buttons_sake;
    public GameObject[] buttons_vodka;
    public GameObject[] buttons_absenta;
    public GameObject[] buttons_whisky;
    public GameObject[] buttons_wine;

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
    }

}
