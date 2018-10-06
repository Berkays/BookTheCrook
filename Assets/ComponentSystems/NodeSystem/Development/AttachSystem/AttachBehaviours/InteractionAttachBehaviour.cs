using UnityEditor;
using UnityEngine;

namespace NodeSystem.Development
{
    public class InteractionAttachBehaviour : NodeAttachBehaviour
    {
        public override bool Attach(GameObject objToAttach)
        {
            bool attachMade = base.Attach(objToAttach);

            var interaction = objToAttach.GetComponent<Interactable>();

            if (interaction != null)
            {
                var component = this.GetComponent<InteractionNode>();

                Undo.RecordObject(component, "Attach Interaction");
                component.Interaction = interaction;

                return true;
            }

            return attachMade;
        }
    }
}