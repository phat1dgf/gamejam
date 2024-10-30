using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleOutline : MonoBehaviour
{
    public int segments = 100;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        CreatePoints();
    }

    void CreatePoints()
    {
        float angle = 0f;
        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * 3.5f;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * 3.5f;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += 360f / segments;
        }
    }
}
