using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Random=UnityEngine.Random;

public class WordGenerator : MonoBehaviour
{
    private static int dictLen = 369652;
    private static string[] words = new string[dictLen];

    public static void GenerateDict()
    {
        
        System.Random rand = new System.Random();
        string path = "Assets/wordsByLen.txt";
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
    }

    public static String GenerateSentence(){
        //print(word);
        int sentenceLen= 10;
        int minlength = 2, maxlength = 7;
        string sentence = "";
        for(int i = 0; i< sentenceLen; i++){
            int num = (int)Random.Range(0, dictLen);
            while(words[num].Length<minlength||words[num].Length>maxlength) 
            {
                num = Random.Range(0, dictLen);
            }
            sentence+= words[num];
            sentence+= " ";
        }
        return sentence;
    }
}
