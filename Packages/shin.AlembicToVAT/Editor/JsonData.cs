using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace shin.AlembicToVAT
{
    [System.Serializable]
    public class JsonData
    {
        public int numOfFrame = 0;
        public Vector3 posMin = Vector3.zero;
        public Vector3 posMax = Vector3.zero;
    }
}