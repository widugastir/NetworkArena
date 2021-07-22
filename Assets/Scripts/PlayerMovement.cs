using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour, IPunObservable
{
	[SerializeField] private float _speed = 5;
	[SerializeField] private PhotonView _photonView;
	[SerializeField] private SpriteRenderer _renderer;
	
	private Vector3 _position;
	private bool _lookAtRight = true;
	
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if(stream.IsWriting)
		{
			stream.SendNext(_position);
			stream.SendNext(_lookAtRight);
		}
		else
		{
			_position = (Vector3) stream.ReceiveNext();
			_lookAtRight = (bool) stream.ReceiveNext();
		}
	}
	
	private void Start()
	{
		_photonView = GetComponent<PhotonView>();
		if(_photonView.IsMine)
		{
			_position = transform.position;
		}
	}
	
	private void Update()
	{
		if(_photonView.IsMine)
		{
			if(Input.GetKey(KeyCode.D))
			{
				_position += Vector3.right * Time.deltaTime * _speed;
				_lookAtRight = true;
			}
		    	
			if(Input.GetKey(KeyCode.A))
			{
			    _position += Vector3.right * Time.deltaTime * -_speed;
				_lookAtRight = false;
			}
		    	
		    if(Input.GetKey(KeyCode.W))
			    _position += Vector3.up * Time.deltaTime * _speed;
		    	
		    if(Input.GetKey(KeyCode.S))
			    _position += Vector3.up * Time.deltaTime * -_speed;
			   
		}
		
		transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime * 6f);
		
		if(_lookAtRight)
			_renderer.flipX = false;
		else
			_renderer.flipX = true;
    }
}
