using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordGenerator : MonoBehaviour
{
    private static string[] words = new string[369651];

    public static string GenerateSentence()
    {
        int minlength = 1, maxlength = 7;
        System.Random rand = new System.Random();
        string path = "Assets/wordsByLen.txt";
        StreamReader reader = new StreamReader(path);
        o

        int index = rand.Next(3);
        return sentences[index];
    }
}
