using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            if (collectionSoundEffect != null)
            {
                collectionSoundEffect.Play();
            }
            else
            {
                Debug.LogWarning("Collection sound effect AudioSource is not assigned on " + gameObject.name);
            }

            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
        }
    }
}