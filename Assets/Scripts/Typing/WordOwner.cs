﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordOwner : MonoBehaviour {
    
    private List<Word> words;
    private WordSpawner wSpawner;
    private WordDisplay wDisplay;
    
    private void Start()
    {
        wSpawner = WordSpawner.Get_WordSpawner();
        wDisplay = GetComponentInChildren<WordDisplay>();
        words = new List<Word>();

    }

    public void Display_word()
    {
        wDisplay.mainText.text =words[0].Text;
        wDisplay.subText.text = words[1].Text;
        wDisplay.typingText.text = "";
    }

    public void Reset_typing()
    {
        wDisplay.typingText.text = "";
        words[0].Reset_index();
    }

    public virtual void Enter_word()
    {
        words.Remove(words[0]);
        Request_word();
        Display_word();

        WordManager.Get_WordManager().Reset_typings();
    }

    public void Request_word()
    {
        Add_word(wSpawner.Push_Word(this));
    }

    public void Add_word(Word word)
    {
        words.Add(word);
    }

    public void Remove_Word(Word word)
    {
        words.Remove(word);
    }

    public bool Check_Typed(char letter)
    {
        if(words.Count > 0)
        {
            words[0].Check_Typed(letter);
            wDisplay.Update_typingText(words[0]);
            return true;
        }
        return false;
    }

}
