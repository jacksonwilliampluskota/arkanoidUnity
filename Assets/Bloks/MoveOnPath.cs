using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class MoveOnPath: MonoBehaviour {

    public bool DoOnPlay;
    public Transform[] Waypoints;
    public float Duration;
    public int Loops = -1;
    public PathType PathType = PathType.Linear;

    private List<Vector3> _points = new List<Vector3>();
    public Ease EaseMode = Ease.Linear;
    public bool ClosePath;

    public List<Vector3> Points
    {
        get
        {
            if (_points == null || (_points.Count != Waypoints.Length))
            {
                UpdatePointList();
            }
            return _points;
        }
        set { _points = value; }
    }

    public void Start()
    {
        if (DoOnPlay)
            Do();
    }

    public void Do()
    {
        var pnts = Points.ToArray();
        transform.DOPath(pnts, Duration, PathType, PathMode.Sidescroller2D, 1, Color.magenta)
            .SetEase(EaseMode)
            .SetOptions(ClosePath)
            .SetLoops(Loops);
    }

    public void UpdatePointList()
    {
        _points = new List<Vector3>();
        for (int i = 0; i < Waypoints.Length; i++)
        {
            _points.Add(Waypoints[i].position);
        }
    }
}
