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

		[SerializeField, Header("���ʳt��") , Range(0, 300)]
		private float speed = 12f;

		[SerializeField, Header("�����V�ϥ�")]
		private Transform traDirection;

		[SerializeField, Header("�����V�ϥܽd��"), Range(0, 5)]
		private float rangeDirection = 2.5f;
		[SerializeField, Header("�������t��"), Range(0, 100)]
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

		private void UpdateDirectionIconPos() 
		{
			Vector3 pos = transform.position + new Vector3(-joystick.Horizontal, 0.5f, -joystick.Vertical) * rangeDirection;
			traDirection.position = pos;
		} 
		private void LookDirectionIcon() 
		{
			//���o���V���� = �|�줸.���V����(��V�ϥ�-�����m)
			Quaternion Look = Quaternion.LookRotation(traDirection.position - transform.position);
			//���⨤�׳]�w = �|�줸.����(���⨤�� , ���V���� , ��t* �@�V���ɶ�)
			transform.rotation = Quaternion.Lerp(transform.rotation, Look, speedTurn * Time.deltaTime);
			//���⪺�کԨ� = �T���V�q(0 ,�쥻���کԨ�.Y ,0)
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		}
	}
}

