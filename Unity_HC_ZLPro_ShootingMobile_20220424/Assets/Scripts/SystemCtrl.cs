using UnityEngine;
/// <summary>
/// �u�� > �ﶵ > C# > IntellSense >��ܨӦۥ��פJ�R�W�Ŷ�....
/// </summary>
//namespace �R�W�Ŷ� �{���϶�
namespace coolRain
{
	/// <summary>
	/// ����t��:��ð����ʨt��
	/// �����n�챱��}�Ⲿ��
	/// </summary>
	public class SystemCtrl : MonoBehaviour
	{
		[SerializeField, Header("�����n��")]
		private Joystick joystick;

		[SerializeField, Header("���ʳt��")]
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
		/// ���o�����n���
		/// </summary>
		private void GetJoyStickValue() 
		{
			print("<color=yellow>����:" + joystick.Horizontal + "</color>" + " <color=yellow>����:" + joystick.Vertical + "</color>");
		}
		/// <summary>
		/// ����
		/// </summary>
		private void Move()
		{
			//����.�[�t�� = �T���V�q(X Y Z)
			rig.velocity = new Vector3(joystick.Horizontal, 0, joystick.Vertical )* speed;

		}
	}
}

