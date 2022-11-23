using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Random=UnityEngine.Random;

public class WordGenerator : MonoBehaviour
{
    
    

    public static String[] GenerateDict()
    {
        int dictLen = 1091;
        string[] words = new string[dictLen];
        System.Random rand = new System.Random();
        string path = "Assets/BookFormatted.txt";
        StreamReader reader = new StreamReader(path);
        string line;
        // Read and display lines from the file until the end of
        // the file is reached.
        int i = 0;
        while ((line = reader.ReadLine()) != null)
        {
            words[i]= line.TrimEnd('\n');
            i++;
        }
        return words;
    }

    public static String GenerateSentence(String[] words){
        //print(word);
        //choose sentence if they
        string sentence = "";
        int num = (int)Random.Range(1, words.Length-1);   
        sentence+=words[num];
        Debug.Log(words[30]);
        return sentence;
    }
}
