using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AtomsDictionaryUtils 
{
    public static Dictionary<string, Color> dictionary = new Dictionary<string, Color>
    {
        {"H", Color.white},
        {"C", Color.black},
        {"N", Color.blue},
        {"O", Color.red},
        {"F", Color.green},
        {"Cl", Color.green},
        {"Br", new Color(122,12,12)},
        {"I", new Color(122,12,117)},
        {"He", new Color(0,237,245)},
        {"Ne", new Color(0,237,245)},
        {"Ar", new Color(0,237,245)},
        {"Xe", new Color(0,237,245)},
        {"Kr", new Color(0,237,245)},
        {"P", new Color(245,151,0)},
        {"S", new Color(245,245,0)},
        {"B", new Color(255,171,122)},
        {"Li", new Color(122,12,117)},
        {"Na", new Color(122,12,117)},
        {"K", new Color(122,12,117)},
        {"Rb", new Color(122,12,117)},
        {"Cs", new Color(122,12,117)},
        {"Be", new Color(0,125,15)},
        {"Mg", new Color(0,125,15)},
        {"Ca", new Color(0,125,15)},
        {"Sr", new Color(0,125,15)},
        {"Ba", new Color(0,125,15)},
        {"Ra", new Color(0,125,15)},
        {"Ti", Color.grey},
        {"Fe", new Color(163,109,0)}
    };

    public static Color GetAtomColor(string type)
    {
        Color toReturn;
        try
        {
            toReturn = dictionary[type];
        }catch(KeyNotFoundException e)
        {
            //Debug.Log("Type not found: " + type);
            toReturn = Color.magenta;
        }
        return toReturn;
    }
}
