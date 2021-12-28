using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public GameObject[] enemies;
    Transform monsterSpawnTrs;
    int stage;
    int remainMonsterCount;
    // Start is called before the first frame update
    void Start()
    {
        stage = 1;
        monsterSpawnTrs = GameObject.Find("EnemySpawnTrs").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SpawnMonster();
            Debug.Log(stage);
            Debug.Log(remainMonsterCount);
        }
        if(remainMonsterCount<=0)
        {
            StageEndSystem();
            StageStartSystem();
        }
    }

    void StageStartSystem()
    {
        remainMonsterCount = stage / 50 + 1;
    }


    void StageEndSystem()
    {
        stage++;
    }
    public void SpawnMonster()
    {
        remainMonsterCount--;
        int randRange = Random.Range(0,enemies.Length-1);
        Instantiate(enemies[randRange], monsterSpawnTrs.position, Quaternion.Euler(new Vector3(0,-180,0)));
    }
}
