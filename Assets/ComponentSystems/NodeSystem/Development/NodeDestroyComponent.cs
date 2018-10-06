using UnityEngine;

namespace NodeSystem.Development
{
    [ExecuteInEditMode()]
    public class NodeDestroyComponent : MonoBehaviour
    {

#if UNITY_EDITOR
        void OnDestroy()
        {
            if (Application.isPlaying)
                return;

            var nodeHelper = FindObjectOfType<NodeHelper>();

            if (nodeHelper != null)
                nodeHelper.Destroy(this.GetComponent<NodeObject>());
        }
#endif
    }
}