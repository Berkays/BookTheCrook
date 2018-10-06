using UnityEngine;

using NodeSystem.Runtime;
using NodeSystem;

public class MovementMarkerHandler : MonoBehaviour
{
    public GameObject MovementMarkerPrefab;
    public PlayerVariable Player;

    public Transform MarkerContainer;
    private const int POOL_SIZE = 5;
    private const float MARKER_Y = -0.49f;
    private GameObject[] movementMarkers = null;

    void Start()
    {
        this.MarkerContainer = GameObject.Find("MovementMarkerContainer").transform;

        poolObjects();
    }

    public void ShowMarkers()
    {
        if (movementMarkers == null)
            poolObjects();

        var nodeManager = FindObjectOfType<NodeManager>();

        var connectedNodes = nodeManager.GetNodes<MovementNode>(Player.Value.CurrentNode);

        HideMarkers();
        for (int i = 0; i < connectedNodes.Count; i++)
        {
            var obj = movementMarkers[i];

            //Set marker node id
            var markerComponent = obj.GetComponent<MovementMarker>();
            markerComponent.NodeId = connectedNodes[i].Id;

            //Set marker position
            Vector3 nodePos = connectedNodes[i].transform.localPosition;
            Vector3 pos = new Vector3(nodePos.x, MARKER_Y, nodePos.z);
            obj.transform.localPosition = pos;

            obj.SetActive(true);
        }
    }

    public void HideMarkers()
    {
        for (int i = 0; i < POOL_SIZE; i++)
            movementMarkers[i].SetActive(false);
    }

    private void poolObjects()
    {
        movementMarkers = new GameObject[POOL_SIZE];

        for (int i = 0; i < POOL_SIZE; i++)
        {
            var obj = GameObject.Instantiate(MovementMarkerPrefab, Vector3.zero, Quaternion.Euler(-90, 0, 0),MarkerContainer);
            obj.SetActive(false);

            movementMarkers[i] = obj;
        }
    }
}
