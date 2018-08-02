using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordDisplay : MonoBehaviour {
    
    public TextMeshPro mainText;
    public TextMeshPro typingText;
    public TextMeshPro subText;
    
    public void Reset_typingText()
    {
        typingText.text = "";
    }

    public void Update_typingText(Word word)
    {
        int typedLength = word.CurIndex;
        string typedText = mainText.text.Substring(0, typedLength);
        typingText.text = typedText;
    }

}
