using UnityEngine;
using Photon.Pun;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private PhotonView _photonView;
    
	protected void Start()
	{
		_photonView = GetComponent<PhotonView>();
	}
    
    void Update()
    {
	    if(_photonView.IsMine)
	    {
	    	if(Input.GetKeyDown(KeyCode.G))
		    	PhotonNetwork.Instantiate(_bulletPrefab.name, Vector3.zero, Quaternion.identity);
	    }
    }
}
