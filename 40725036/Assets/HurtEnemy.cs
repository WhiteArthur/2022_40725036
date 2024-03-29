using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tnu40725036
{
    public class HurtEnemy : HurtSystem 
    {
        /// <summary>
        /// 敵人受傷:彈出受傷數字
        /// </summary>
        //子類別:父類別 - 繼承語法
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;
        [SerializeField, Header("畫布傷害數值")]
        private GameObject goCanvasHurt;
        [SerializeField, Header("經驗值道具")]
        private GameObject goExp;

        private string parameterDead = "敵人死亡";
        private Animator ani;
        private EnemySystem enemySystem;

        private void Start()
        {
            ani = GetComponent<Animator>();
            enemySystem = GetComponent<EnemySystem>();

            hp = data.hp;
        }

        public override void GetHurt(float damage)
        {
            base.GetHurt(damage);

            GameObject temp = Instantiate(goCanvasHurt, transform.position, Quaternion.identity);

            temp.GetComponent<HurtNumberEffect>().UpdateHurtNumber(damage);

        }

        public override void Dead()
        {
            base.Dead();

            ani.SetTrigger(parameterDead);
            enemySystem.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 2);

            DropExp();
        }
        private void DropExp()
        {
            float randwom =  Random.value;

            if(randwom <= data.expDropProbability)
            {
                GameObject tempExp = Instantiate(goExp, transform.position, Quaternion.identity);

                tempExp.AddComponent<Exp>().typeExp = data.typeExp;
            }
        }

    }

}
