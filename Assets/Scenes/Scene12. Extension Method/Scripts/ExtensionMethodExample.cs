using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class ExtensionMethodExample : MonoBehaviour
{
    string s = "Test Convention";

    private void Start()
    {
        string s2 = s.ChangeUpper();
        Debug.Log("s2 : " + s2);

        char ch = 'n';
        bool found = s.Found(ch);
        Debug.Log("found  : " + found);
    }
}


public static class ExClass
{
    public static string ChangeUpper(this String str)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var ch in str)
        {
            if (ch >= 'A' && ch <= 'Z')
                sb.Append((char)('a' + ch - 'A'));
            else if (ch >= 'a' && ch <= 'z')
                sb.Append((char)('A' + ch - 'a'));
            else
                sb.Append(ch);
        }

        return sb.ToString();
    }

    public static bool Found(this String str, char ch)
    {
        int position = str.IndexOf(ch);
        return position >= 0;
    }
}