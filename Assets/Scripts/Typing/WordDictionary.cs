using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDictionary : MonoBehaviour {

    #region Singleton
    private static WordDictionary wordDic;
    public static WordDictionary Get_WordDic()
    {
        if(wordDic == null)
        {
            wordDic = FindObjectOfType<WordDictionary>().GetComponent<WordDictionary>();
            if(wordDic == null)
            {
                GameObject container = new GameObject();
                container.name = "WordDictonary";
                wordDic = container.AddComponent(typeof(WordDictionary)) as WordDictionary;
            }
        }
        return wordDic;
    }
    #endregion

    #region Utility Function
    public static List<string> Get_WordsFromDic(List<string> tag)
    {
        List<string> list = new List<string>();
        foreach(string x in tag)
        {
            if (Dic.ContainsKey(x))
            {
                foreach(string y in Dic[x])
                {
                    list.Add(y);
                }
            }
        }    
        return list;
    }


    #endregion
            
    #region DataBase
    //https://en.wikipedia.org/wiki/List_of_breads
    static List<string> Bread = new List<string>()
    { "sweet burn", "corn bread", "bagel", "rye", "bolani", "bread roll", "chapati", "carrot bread", "pan cake", "cake", "crepe", "curry bread", "hardtack", "toast",
    "kaya toast", "lagana", "crispy bread", "lavish", "flat bread", "naan", "pita","pizza", "potato bread", "pretzel", "rice bread", "scone", "tea cake", "tortilla",
        "white bread", "zweiback"};

    //https://en.wikipedia.org/wiki/List_of_coffee_drinks
    static List<string> Coffee = new List<string>()
    { "affogato", "americano", "bicerin", "breve", "crema", "latte", "corretto", "cappuccino", "cafe mocha", "espresso", "Frappuccino",
        "iced coffee", "kopi", "luwak", "cafe latte", "lungo", "romano", "ristretto"};

    //https://simple.wikipedia.org/wiki/List_of_vegetables
    static List<string> Vegetable = new List<string>()
    {
        "aubergine", "asparagus", "legume", "bean", "pea", "lentil", "sprout", "soy bean", "green bean", "black bean", "broccoli", "celery", "fiddleheads", "fennel",
        "greens", "bok choy", "chard", "collard greens", "kale", "spinach", "quinoa", "lettuce", "arugula", "onion", "shallot", "scallion", "leek", "garlic", "chives", "parsley",
        "pepper", "bell pepper", "rhubarb", "carrot", "ginger", "turnip", "radish", "wasabi", "squash", "acorn", "pumpkin", "tomato", "tuber", "taro", "yam", "potato",
        "cucumber", "taro"
    };

    //https://simple.wikipedia.org/wiki/List_of_fruits
    static List<string> Fruit = new List<string>()
    {
        "apple", "apricot", "avocado", "banana", "bilberry", "blackberry", "blueberry", "currant", "cherry", "cherimoya", "cloudberry", "coconut", "cranberry",
        "date", "dragonfruit" , "pitaya", "durian", "elderberry", "gooseberry", "grape", "raisin", "guava", "honeyberry", "huckleberry", "jackfruit", "jambul",
        "japanese plum", "jujube", "juniper berry", "kiwano", "horned melon", "kiwi", "lemon", "lime", "mango", "mangosteen", "marionberry", "melon",
        "cantaloupe", "honeydew", "watermelon", "miracle fruit", "mulberry", "nectarine", "nance", "olive", "orange", "blood orange", "clementine",
        "mandarine", "tangerine", "papaya", "passionfruit", "peach", "pear", "persimmon", "plantain", "plum", "prune", "dried plum", "pineapple", "pineberry",
        "plumcot", "raspberry", "star apple", "star fruit", "strawberry", "surinam cherry", "tamarillo", "yuzu", "white currant", "white sapote"
    };


    #endregion

    #region Initialize Dictionary
    public static Dictionary<string, List<string>> Dic = new Dictionary<string, List<string>>()
    {
        {"Fruit", Fruit}, {"Vegetable", Vegetable}, {"Bread", Bread}, {"Coffee", Coffee}
    };
    #endregion
}
