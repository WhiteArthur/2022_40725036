using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tnu40725036
{
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField, Header("生成敵人物件")]
        private GameObject goEnemy;
        [SerializeField, Header("敵人生成點")]
        private Transform[] traSpawn;
        [SerializeField, Header("生成延遲"), Range(0,3)]
        private float delay = 1;
        [SerializeField, Header("生成間隔"), Range(0, 3)]
        private float interval = 0.7f;

        private void Awake()
        {
            InvokeRepeating("Spawn", delay, interval);
        }

        private void Spawn()
        {
            int ran = Random.Range(0, traSpawn.Length);
            Instantiate(goEnemy, traSpawn[ran].position, Quaternion.identity);
        }

    }
}
