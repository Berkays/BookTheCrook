using UnityEngine;

using NodeSystem.Runtime;

public class PlayerSpawner : MonoBehaviour
{
    public LevelInfo levelInfo;
    public GameObject LocalPlayerPrefab;
    public GameObject RemotePlayerPrefab;

    public PlayerVariable LocalPlayer;
    public PlayerVariable RemotePlayer;

    public void SpawnPlayers()
    {
        var nodeManager = FindObjectOfType<NodeManager>();


        var localPlayerObj = GameObject.Instantiate(LocalPlayerPrefab, Vector3.zero, Quaternion.identity);

        Player localPlayer = localPlayerObj.GetComponent<Player>();
        localPlayer.CurrentNode = levelInfo.CopSpawnNode; //Set spawn position
        localPlayer.transform.position = nodeManager[localPlayer.CurrentNode].transform.localPosition;

        LocalPlayer.Value = localPlayer;

        var remotePlayerObj = GameObject.Instantiate(RemotePlayerPrefab, Vector3.zero, Quaternion.identity);
        Player remotePlayer = remotePlayerObj.GetComponent<Player>();
        remotePlayer.CurrentNode = levelInfo.ThiefSpawnNode;
        remotePlayer.transform.position = nodeManager[remotePlayer.CurrentNode].transform.localPosition;

        RemotePlayer.Value = remotePlayer;
    }
}
