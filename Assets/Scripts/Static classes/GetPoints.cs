using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetPoints
{
    private static Transform[] _points;
    public static Transform[] _GetPoints{
        get
        {
            if(_points == null)
                _points = GameObject.FindGameObjectWithTag("PointsContainer").GetComponent<PointCointenier>().Points;
            return _points;
        }
    }
}
