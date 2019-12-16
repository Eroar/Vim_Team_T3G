using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreLoader : MonoBehaviour
{
    BinaryWriter writer;
    BinaryReader reader;
    string path;
    int[] scores;
    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "scores.txt");

        writer = new BinaryWriter(File.Open(path,FileMode.Create));
        reader = new BinaryReader(File.Open(path, FileMode.Open));
        scores = new int[10];
        addScore(3);
    }
    void addScore(int score)
    {
        scores = getScores();
        int index, lowest;
        lowest = index = int.MaxValue;
        for(int i = 0;i<scores.Length;i++)
        {
            if(lowest>scores[i])
            {
                lowest = scores[i];
                index = i;
            }
        }
        if(lowest<score)
        {
            scores[index] = score;
        }
        writer.Write(scores.Length);
        for(int i = 0;i<scores.Length;i++)
        {
            writer.Write(scores[i]);
        }
    }
    int[] getScores()
    {
        int size;
        size = reader.ReadInt32();
        scores = new int[size];
        for(int i = 0;i<size;i++)
        {
            scores[i] = reader.ReadInt32();
        }
        return scores;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
