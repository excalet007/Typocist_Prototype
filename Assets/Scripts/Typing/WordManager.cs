using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    #region singleton
    private static WordManager wordManager;
    public static WordManager Get_WordManager()
    {
        if (wordManager == null)
        {
            wordManager = FindObjectOfType<WordManager>().GetComponent<WordManager>();
            if (wordManager == null)
            {
                GameObject container = new GameObject();
                container.name = "WordManager";
                wordManager = container.AddComponent(typeof(WordManager)) as WordManager;
            }
        }
        return wordManager;
    }
    #endregion

    private WordSpawner wSpawner;
    private List<WordOwner> wOwners;

    private void Start()
    {
        wSpawner = WordSpawner.Get_WordSpawner();
        wOwners = new List<WordOwner>();
    }

    private void Update()
    {
        foreach (char letter in Input.inputString)
            {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                foreach (WordOwner owner in wOwners)
                {
                    if(owner.Check_Typed(letter));
                }
            }
        }

    }

    public void Add_wordOwner(WordOwner owner)
    {
        if (wOwners.Contains(owner) == false)
        {
            wOwners.Add(owner);
            owner.Request_word();
            owner.Request_word();
            owner.Display_word();
        }
    }

    public void Remove_wordOwner(WordOwner owner)
    {
        wOwners.Remove(owner);
    }

    public void Reset_typings()
    {
        foreach (WordOwner owner in wOwners) owner.Reset_typing();
    }

}
