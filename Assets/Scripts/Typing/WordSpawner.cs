using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {

    #region Singleton
    private static WordSpawner wordSpawner;
    public static WordSpawner Get_WordSpawner()
    {
        if (wordSpawner == null)
        {
            wordSpawner = FindObjectOfType<WordSpawner>().GetComponent<WordSpawner>();
            if (wordSpawner == null)
            {
                GameObject container = new GameObject();
                container.name = "wordSpawner";
                wordSpawner = container.AddComponent(typeof(WordSpawner)) as WordSpawner;
            }
        }
        return wordSpawner;
    }
    #endregion

    private List<string> curTags;
    private List<string> curDic;

    private InputController inputController;
    private WordManager wordManager;

    public void Update_curTags(List<string> tags)
    {
        curTags.Clear();
        foreach (string s in tags)
        {
            if (WordDictionary.Dic.ContainsKey(s))
                curTags.Add(s);
            else
                Debug.LogError("you input wrong Tag! Fuck you : " + s);
        }
    }
    public void Initialize_curDic()
    {
        curDic.Clear();
        curDic = WordDictionary.Get_WordsFromDic(curTags);
    }
    

    public Word Push_Word(WordOwner owner)
    {
        int randIndex = (int)(UnityEngine.Random.Range(0, curDic.Count));
        Word word = new Word(curDic[randIndex], owner);
        curDic.Remove(curDic[randIndex]);
        return word;
    }

    private void Start()
    {
        curTags = new List<string>();
        curDic = new List<string>();

        inputController = InputController.Get_InputController();
        wordManager = WordManager.Get_WordManager();
    }
    
    
}
