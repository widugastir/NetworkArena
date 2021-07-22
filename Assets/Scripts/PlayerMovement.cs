using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _speed = 5;
	[SerializeField] private PhotonView _photonView;
	
	private void Start()
	{
		_photonView = GetComponent<PhotonView>();
	}
	
	private void Update()
	{
		if(_photonView.IsMine)
		{
		    if(Input.GetKey(KeyCode.D))
		    	transform.Translate(Vector3.right * Time.deltaTime * _speed);
		    	
		    if(Input.GetKey(KeyCode.A))
		    	transform.Translate(Vector3.right * Time.deltaTime * -_speed);
		    	
		    if(Input.GetKey(KeyCode.W))
		    	transform.Translate(Vector3.up * Time.deltaTime * _speed);
		    	
		    if(Input.GetKey(KeyCode.S))
		    	transform.Translate(Vector3.up * Time.deltaTime * -_speed);
		}
    }
}
