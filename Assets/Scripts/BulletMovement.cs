using UnityEngine;
using Photon.Pun;

public class BulletMovement : MonoBehaviour, IPunObservable
{
	[SerializeField] private float _speed = 1f;
	private Rigidbody2D _rigi;
	
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		
	}
	
	protected void Start()
	{
		_rigi = GetComponent<Rigidbody2D>();
	}
    
	private void FixedUpdate()
	{
		//if(PhotonNetwork.IsMasterClient)
		//{
			_rigi.AddForce(transform.forward * _speed);
		//}
    }
}
