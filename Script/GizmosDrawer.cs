using System.Collections.Generic;
using UnityEngine;
using LumenCat92.TimeCounter;

namespace LumenCat92.GizmosDrawer
{
    public class GizmosDrawerManager : MonoBehaviour
    {
        public static GizmosDrawerManager Instance { private set; get; }
        public bool drawGizmos = true;
        private List<GizmoInfo> gizmosToDraw = new List<GizmoInfo>();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
        }

        public void DrawLine(Vector3 startPosition, Vector3 endPosition, float duration, Color color, bool shouldDraw = true)
        {
            if (!shouldDraw) return;
            var gizmoInfo = new GizmoInfo { StartPosition = startPosition, EndPosition = endPosition, Duration = duration, Color = color };
            AddGizmoInfo(gizmoInfo);
        }

        public void DrawLine(Vector3 startPosition, Vector3 dir, float dist, float duration, Color color, bool shouldDraw = true)
        {
            if (!shouldDraw) return;
            var gizmoInfo = new GizmoInfo { StartPosition = startPosition, EndPosition = startPosition + dir * dist, Duration = duration, Color = color };
            AddGizmoInfo(gizmoInfo);
        }

        public void DrawSphere(Vector3 startPosition, float size, float duration, Color color, bool shouldDraw = true)
        {
            if (!shouldDraw) return;
            var gizmoInfo = new SphereGizmoInfo { StartPosition = startPosition, Radius = size, Duration = duration, Color = color, GizmoType = GizmoInfo.GizmosType.Sphere };
            AddGizmoInfo(gizmoInfo);
        }

        // public void DrawChangePoint(IGizmosDrawerConnector connector, Vector3 startPoint, Vector3 endPoint, float duration, Color color)
        // {
        //     DrawSphere(endPoint, 0.5f, duration, color);
        //     DrawLine(startPoint, endPoint, duration, color);
        // }

        void AddGizmoInfo(GizmoInfo info)
        {
            gizmosToDraw.Add(info);
            TimeCounterManager.Instance.SetTimeCounting(info.Duration, () => { info.NeedRemove = true; });
        }

        private void OnDrawGizmos()
        {
            if (drawGizmos)
                for (int i = 0; i < gizmosToDraw.Count; i++)
                {
                    var info = gizmosToDraw[i];
                    if (info.NeedRemove)
                    {
                        gizmosToDraw.RemoveAt(i--);
                        continue;
                    }
                    else
                    {
                        UnityEngine.Gizmos.color = info.Color;
                        switch (info.GizmoType)
                        {
                            case GizmoInfo.GizmosType.Line:
                                UnityEngine.Gizmos.DrawLine(info.StartPosition, info.EndPosition);
                                break;
                            case GizmoInfo.GizmosType.Sphere:
                                var sphereInfo = info as SphereGizmoInfo;
                                UnityEngine.Gizmos.DrawSphere(sphereInfo.StartPosition, sphereInfo.Radius);
                                break;
                        }
                    }
                }
        }

        public class GizmoInfo
        {
            public enum GizmosType { Line, Sphere }
            public GizmosType GizmoType { set; get; } = GizmosType.Line;
            public Vector3 StartPosition { get; set; } = Vector3.zero;
            public Vector3 EndPosition { get; set; } = Vector3.zero;
            public Color Color { set; get; } = Color.magenta;
            public float Duration { get; set; } = 0f;
            public bool NeedRemove { set; get; } = false;
        }

        public class SphereGizmoInfo : GizmoInfo
        {
            public float Radius { set; get; }
        }
    }
}