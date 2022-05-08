using UnityEngine;
/// <summary>
/// 工具 > 選項 > C# > IntellSense >顯示來自未匯入命名空間....
/// </summary>
//namespace 命名空間 程式區塊
namespace coolRain
{
	/// <summary>
	/// 控制系統:荒野亂鬥移動系統
	/// 虛擬搖桿控制腳色移動
	/// </summary>
	public class SystemCtrl : MonoBehaviour
	{
		[SerializeField, Header("虛擬搖桿")]
		private Joystick joystick;

		[SerializeField, Header("移動速度")]
		private float speed = 12f;
		private Rigidbody rig;
		private void Awake()
		{
			rig = GetComponent<Rigidbody>();
		}
		private void Update()
		{
			//GetJoyStickValue();
		}

		private void FixedUpdate()
		{
			Move();
		}

		/// <summary>
		/// 取得虛擬搖桿值
		/// </summary>
		private void GetJoyStickValue() 
		{
			print("<color=yellow>水平:" + joystick.Horizontal + "</color>" + " <color=yellow>垂直:" + joystick.Vertical + "</color>");
		}
		/// <summary>
		/// 移動
		/// </summary>
		private void Move()
		{
			//剛體.加速度 = 三維向量(X Y Z)
			rig.velocity = new Vector3(joystick.Horizontal, 0, joystick.Vertical )* speed;

		}
	}
}

