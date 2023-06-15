using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollider : MonoBehaviour
{
    private int _bananas = 0;

    [SerializeField]
    private Text bananasText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            _bananas++;
            bananasText.text = "Bananas: " + _bananas;
            Debug.Log("Bananas: " + _bananas);
        }
    }
}