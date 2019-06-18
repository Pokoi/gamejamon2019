using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth_class : MonoBehaviour
{
    private int drinked_glasses;
    private Glass last_glass_class;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Glass>())
        {
            if (collision.gameObject.GetComponent<Glass>().GetContentGlass())
            {
                last_glass_class = collision.gameObject.GetComponent<Glass>();
                drinked_glasses++;                
                collision.gameObject.GetComponent<Glass>().DrinkGlass();
                collision.gameObject.GetComponent<Glass>().GlassManager.spawnGlass();
                collision.gameObject.GetComponent<Glass>().removeCollider();
            }
        }
        
    }
    public bool GetDrinkedGlass()
    {
        int glasses = drinked_glasses;
        drinked_glasses = 0;
        
        return glasses > 0;
    }
    public Glass GetLastGlass()
    {
        return last_glass_class;
    }
}
