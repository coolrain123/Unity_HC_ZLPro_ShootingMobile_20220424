using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace coolRain
{
    public class SystemAttack : MonoBehaviour
    {
        [SerializeField, Header("�o�g���s")]
        private Button btnAttack;
        [SerializeField, Header("�l�u")]
        private GameObject Bullet;
        [SerializeField, Header("�l�u�̤j�ƶq")]
        private int bulletCountMax = 3;
        [SerializeField, Header("�l�u�ͦ���m")]
        private Transform traFire;
        [SerializeField, Header("�l�u�o�g�t��"), Range(0, 3000)]
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
