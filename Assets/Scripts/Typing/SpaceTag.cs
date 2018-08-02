using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTag : MonoBehaviour {

    private Collider2D checkBox;
    public List<string> spaceTag = new List<string>();

    private void Start()
    {
        checkBox = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WordSpawner wordSpawner = WordSpawner.Get_WordSpawner();
            wordSpawner.Update_curTags(spaceTag);
            wordSpawner.Initialize_curDic();
        }
    }
}
