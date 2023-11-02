using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemsCollecor : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private Text cherriesText;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        cherries++; 
        
        cherriesText.text = "Cherries: " + cherries;
    }


}
