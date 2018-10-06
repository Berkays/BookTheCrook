using UnityEngine;

using NodeSystem;
using NodeSystem.Runtime;

public class ActionLineDrawer : MonoBehaviour
{

    public GameObject LinePrefab;
    public Transform LineContainer;

    private Player player;

    private const int POOL_SIZE = 8;
    private GameObject[] actionLines = null;

    void Start()
    {
        this.LineContainer = GameObject.Find("ActionLineContainer").transform;
        this.player = this.transform.parent.GetComponent<Player>();

        poolObjects();
    }

    public void ShowLines()
    {
        if (actionLines == null)
            poolObjects();

        //Find all possible actions
        var nodeManager = FindObjectOfType<NodeManager>();

        var movementNodes = nodeManager.GetNodes<NodeObject>(player.CurrentNode);
        //var interactionNodes = nodeManager.GetNodes<InteractionNode>(Player.Value.CurrentNode);




        int i;
        for (i = 0; i < movementNodes.Count; i++)
        {
            var node = movementNodes[i];

            var obj = actionLines[i];
            obj.transform.localPosition = Vector3.zero;

            Vector3 actionPosition = node.transform.localPosition;
            Vector3 lineOrigin = Vector3.Lerp(this.transform.position, actionPosition, 0.1f);

            var lineRenderer = obj.GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, lineOrigin);
            lineRenderer.SetPosition(1, actionPosition);

            lineRenderer.material.SetColor("Color_79D781FF", node.NodeAsset.NodeColor);

            obj.SetActive(true);
        }

        for (; i < POOL_SIZE; i++)
            actionLines[i].SetActive(false);
    }

    public void HideLines()
    {
        for (int i = 0; i < POOL_SIZE; i++)
            actionLines[i].SetActive(false);
    }

    private void poolObjects()
    {
        actionLines = new GameObject[POOL_SIZE];
        for (int i = 0; i < POOL_SIZE; i++)
        {
            var obj = GameObject.Instantiate(LinePrefab, Vector3.zero, Quaternion.identity, this.LineContainer);
            obj.SetActive(false);
            actionLines[i] = obj;
        }
    }

}
