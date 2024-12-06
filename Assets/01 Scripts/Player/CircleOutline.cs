using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleOutline : MonoBehaviour
{
    public int segments = 100;
    private LineRenderer lineRenderer;
    Color currentColor = CONSTANTS.RED_COLOR;
    void Start()
    {
        Observer.AddListeners(CONSTANTS.ChooseColor_ACTION, onChooseColor);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material.renderQueue = 3100;
        CreatePoints();
    }
    private void FixedUpdate()
    {
        lineRenderer.startColor = currentColor;
        lineRenderer.endColor = currentColor;
    }
   
    private void onChooseColor(object[] datas)
    {
        string colorTag = datas[0] == null ? "null" : (string)datas[0];

        currentColor = GetColorByTag(colorTag);
    }

    private Color GetColorByTag(string colorTag)
    {
         Color color = colorTag switch
        {
            CONSTANTS.RED_TAG => CONSTANTS.RED_COLOR,
            CONSTANTS.YELLOW_TAG => CONSTANTS.YELLOW_COLOR,
            CONSTANTS.BLUE_TAG => CONSTANTS.BLUE_COLOR,
            CONSTANTS.ORANGE_TAG => CONSTANTS.ORANGE_COLOR,
            CONSTANTS.GREEN_TAG => CONSTANTS.GREEN_COLOR,
            CONSTANTS.PURPLE_TAG => CONSTANTS.PURPLE_COLOR,
            _ => CONSTANTS.NULL_COLOR
        };
      
        return color;
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
    private void OnDestroy()
    {
        Observer.RemoveListeners(CONSTANTS.ChooseColor_ACTION, onChooseColor);
    }
}
