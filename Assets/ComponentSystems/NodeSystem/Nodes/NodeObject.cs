using System;
using System.Collections.Generic;
using UnityEngine;

using NodeSystem.ScriptableObjects;

namespace NodeSystem
{
    public class NodeObject : MonoBehaviour, IEquatable<NodeObject>
    {
        public int Id;
        public NodeAsset NodeAsset;
        public List<NodeObject> Neighbours;

        public bool Equals(NodeObject other)
        {
            return this.Id == other.Id;
        }
    }
}