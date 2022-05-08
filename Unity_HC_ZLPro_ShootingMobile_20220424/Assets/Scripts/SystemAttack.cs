using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace coolRain
{
    public class SystemAttack : MonoBehaviour
    {
        [SerializeField, Header("發射按鈕")]
        private Button btnAttack;
        [SerializeField, Header("子彈")]
        private GameObject Bullet;
        [SerializeField, Header("子彈最大數量")]
        private int bulletCountMax = 3;
        [SerializeField, Header("子彈生成位置")]
        private Transform traFire;
        [SerializeField, Header("子彈發射速度"), Range(0, 3000)]
        private float speedFire = 500f;

        private int bullerCountCurrent;
        private void Awake()
        {
            btnAttack.onClick.AddListener(Fire);
        }
        private void Fire()
        {
            Instantiate(Bullet, traFire.position, Quaternion.identity);
        }

    }

}
