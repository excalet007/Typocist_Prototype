using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Word {

    private string text;
    public string Text
    {
        get { return text; }
    }
    private int curIndex;
    public int CurIndex
    {
        get { return curIndex; }
    }
    private WordOwner wordOwner;
    
    public Word(string _text, WordOwner _wordOwner)
    {
        text = _text;
        wordOwner = _wordOwner;
        curIndex = 0;
    }

    public void Reset_index()
    {
        curIndex = 0;
    }

    public void Enter_Text()
    {

    }

    public bool Check_Typed(char typed)
    {
        if (typed == text[curIndex])
        {
            curIndex++;
            if(curIndex > text.Length -1)
            {
                wordOwner.Enter_word();
            }
            return true;
        }
        return false;
    }
}
