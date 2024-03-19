using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
	[SerializeField] private GameObject _player;
	[SerializeField] private float _minSpawnZoneX, _maxSpawnZoneX, _minSpawnZoneZ, _maxSpawnZoneZ;

	private const float _spawnZoneY = 0.55f;

	private void Start()
	{
		Vector3 randomSpawnZone = new Vector3(Random.Range(_minSpawnZoneX, _maxSpawnZoneX), _spawnZoneY, Random.Range(_minSpawnZoneZ, _maxSpawnZoneZ));
		PhotonNetwork.Instantiate(_player.name, randomSpawnZone, Quaternion.identity);
	}
}
