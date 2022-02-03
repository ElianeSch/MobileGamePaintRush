using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{

    public int rows;
    public int columns;
    public Vector2 cellSize;



    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float sqrRt = Mathf.Sqrt(transform.childCount);
        rows = Mathf.CeilToInt(sqrRt);
        columns = Mathf.CeilToInt(sqrRt);

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = parentWidth / (float)columns;
        float cellHeight = cellWidth;

        cellSize.x = cellWidth;
        cellSize.y = cellHeight;

        int columnCount = 0;
        int rowCount = 0;

        for (int i=0;i<rectChildren.Count;i++)
        {
            rowCount = i / columns;
            columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = (cellSize.x * columnCount);
            var yPos = (cellSize.y * rowCount);

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 0, yPos, cellSize.y);
        }
    
    
    }

    public override void CalculateLayoutInputVertical()
    {
       
    }


    public override void SetLayoutHorizontal()
    {
        
    }

    public override void SetLayoutVertical()
    {
        
    }
}
