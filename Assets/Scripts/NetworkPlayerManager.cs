using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NetworkPlayerManager : MonoBehaviourPunCallbacks
{
	[SerializeField] private GameObject _playerPrefab;
	
	private void Start()
    {
	    PhotonNetwork.Instantiate(_playerPrefab.name, Vector3.zero, Quaternion.identity);
    }
    
	public override void OnLeftRoom()
	{
		SceneManager.LoadScene(0);
	}
}
