using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] Transform penemy;
    List<Transform> enemies;

    [SerializeField] float distance;
    [SerializeField] int row;
    [SerializeField] int columns;
    // Start is called before the first frame update
    void Awake()
    {
        enemies = new List<Transform>();
    }
    void Start()
    {
        SpawnRow(new Vector2(-5,2));
    }

    void AddEnemy(Vector2 pos)
    {
        enemies.Add(Instantiate(penemy));
        enemies[enemies.Count - 1].SetParent(this.transform);
        enemies[enemies.Count - 1].position = new Vector3(pos.x,pos.y,0);
    }
    void SpawnRow(Vector2 pos)
    {
        for(int i = 0;i<row;i++)
        {
            AddEnemy(new Vector2(i * distance, 0) + pos);
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
