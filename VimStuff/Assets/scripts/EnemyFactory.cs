﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] Transform penemy;
    List<Transform> enemies;

    [SerializeField] float distance;
    [SerializeField] float left;
    [SerializeField] float right;
    // Start is called before the first frame update
    private void Awake()
    {
        enemies = new List<Transform>();
    }
    void Start()
    {
        SpawnRow(10, 3);
    }

    void AddEnemy(Vector2 pos)
    {
        enemies.Add(Instantiate(penemy));
        enemies[enemies.Count - 1].SetParent(this.transform);
        enemies[enemies.Count - 1].localPosition = new Vector3(pos.x,pos.y,0);
    }
    void SpawnRow(int count,float height)
    {
        for(int i = 0;i<count;i++)
        {
            AddEnemy(new Vector2(left + (float)(left-right)/(float) i, 0) + new Vector2(0,height));
        }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
