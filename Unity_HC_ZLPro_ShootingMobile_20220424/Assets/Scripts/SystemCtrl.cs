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

		[SerializeField, Header("移動速度") , Range(0, 300)]
		private float speed = 12f;

		[SerializeField, Header("角色方向圖示")]
		private Transform traDirection;

		[SerializeField, Header("角色方向圖示範圍"), Range(0, 5)]
		private float rangeDirection = 2.5f;
		[SerializeField, Header("角色旋轉速度"), Range(0, 100)]
		private float speedTurn = 1.5f;


		private Rigidbody rig;
		private void Awake()
		{
			rig = GetComponent<Rigidbody>();
		}
		private void Update()
		{
			//GetJoyStickValue();
			UpdateDirectionIconPos();
			LookDirectionIcon();
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

		private void UpdateDirectionIconPos() 
		{
			Vector3 pos = transform.position + new Vector3(-joystick.Horizontal, 0.5f, -joystick.Vertical) * rangeDirection;
			traDirection.position = pos;
		} 
		private void LookDirectionIcon() 
		{
			//取得面向角度 = 四位元.面向角度(方向圖示-角色位置)
			Quaternion Look = Quaternion.LookRotation(traDirection.position - transform.position);
			//角色角度設定 = 四位元.插值(角色角度 , 面向角度 , 轉速* 一幀的時間)
			transform.rotation = Quaternion.Lerp(transform.rotation, Look, speedTurn * Time.deltaTime);
			//角色的歐拉角 = 三維向量(0 ,原本的歐拉角.Y ,0)
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		}
	}
}

