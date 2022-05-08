using UnityEngine;


namespace coolRain
{
    public class PlayerUIFollow : MonoBehaviour
    {
        [SerializeField, Header("¦ì²¾")]
        private Vector3 v3offset;

        private string namePlayer = "¾Ô¤h";
        private Transform traPlayer;

        private void Awake()
        {
            traPlayer = GameObject.Find(namePlayer).transform;
        }

        private void Update()
        {
            Follow();
        }
        private void Follow()
        {
            transform.position = traPlayer.position + v3offset;
        }
    }
}

