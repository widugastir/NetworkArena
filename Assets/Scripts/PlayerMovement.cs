using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour, IPunObservable
{
	[SerializeField] private float _speed = 5;
	[SerializeField] private PhotonView _photonView;
	
	private Vector3 _position;
	
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if(stream.IsWriting)
		{
			stream.SendNext(_position);
		}
		else
		{
			_position = (Vector3) stream.ReceiveNext();
		}
	}
	
	private void Start()
	{
		_photonView = GetComponent<PhotonView>();
	}
	
	private void Update()
	{
		if(_photonView.IsMine)
		{
			if(Input.GetKey(KeyCode.D))
				_position = transform.position + Vector3.right * Time.deltaTime * _speed;
		    	//transform.Translate(Vector3.right * Time.deltaTime * _speed);
		    	
		    if(Input.GetKey(KeyCode.A))
			    _position = transform.position + Vector3.right * Time.deltaTime * -_speed;
			//transform.Translate(Vector3.right * Time.deltaTime * -_speed);
		    	
		    if(Input.GetKey(KeyCode.W))
			    _position = transform.position + Vector3.up * Time.deltaTime * _speed;
			//transform.Translate(Vector3.up * Time.deltaTime * _speed);
		    	
		    if(Input.GetKey(KeyCode.S))
			    _position = transform.position + Vector3.up * Time.deltaTime * -_speed;
			//transform.Translate(Vector3.up * Time.deltaTime * -_speed);
		}
		
		transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime * 3f);
    }
}
