using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_Player : MonoBehaviour {
    // it check's player's range
    // range variable
    // send message

    private CircleCollider2D collider;
    private WordManager wordManager;

    public void Set_Range(float radius)
    {
        collider.radius = radius;
    }

    private void Start()
    {
        collider = this.GetComponent<CircleCollider2D>();
        wordManager = WordManager.Get_WordManager();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.CompareTag("Enemy"))
        {
            wordManager.Add_wordOwner(collision.gameObject.GetComponentInChildren<WordOwner>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //wordManager.Remove_wordOwner(collision.gameObject.GetComponentInChildren<WordOwner>());
        }
    }
}
