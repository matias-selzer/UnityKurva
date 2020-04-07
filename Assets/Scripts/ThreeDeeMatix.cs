using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDeeMatix 
{
    private List<Atom>[,,] cells;
    private float cellSize;
    private float maxX = 0, maxY = 0, maxZ = 0, minX = 0, minY = 0, minZ = 0;
    private int row, col, depth;
    private int maxAtomsInCell = 0;

    public int MaxAtomsInCell
    {
        get
        {
            return maxAtomsInCell;
        }

        set
        {
            maxAtomsInCell = value;
        }
    }

    public ThreeDeeMatix(float cellSize, float maxX, float maxY, float maxZ, float minX, float minY, float minZ)
    {
        this.cellSize = cellSize;
        this.maxX = maxX;
        this.maxY = maxY;
        this.maxZ = maxZ;
        this.minX = minX;
        this.minY = minY;
        this.minZ = minZ;

        row =(int)((maxX-minX) / cellSize)+1;
        col = (int)((maxY - minY) / cellSize)+1;
        depth = (int)((maxZ - minZ) / cellSize)+1;

        cells = new List<Atom>[row, col, depth];
        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                for(int k = 0; k < depth; k++)
                {
                    cells[i, j, k] = new List<Atom>();
                }
            }
        }
    }

    public void InsertAtom(Atom a)
    {
        int targetCellx = (int)((a.getPosition().x-minX) / cellSize);
        int targetCelly = (int)((a.getPosition().y - minY) / cellSize);
        int targetCellz = (int)((a.getPosition().z - minZ) / cellSize);

        //Debug.Log("Rows - Cols - Depth: " + row + " - " + col + " - " + depth);
        //Debug.Log("Atom position: " + a.getPosition());
       // Debug.Log("new atom at: " + targetCellx + " - " + targetCelly + " - " + targetCellz);

        cells[targetCellx, targetCelly, targetCellz].Add(a);
        if(cells[targetCellx, targetCelly, targetCellz].Count > maxAtomsInCell)
        {
            maxAtomsInCell = cells[targetCellx, targetCelly, targetCellz].Count;
        }
    }

    public void PrintAllMatrix()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                for (int k = 0; k < depth; k++)
                {
                    if (cells[i, j, k].Count > 0)
                    {
                        Debug.Log(i + " - " + j + " - " + k);
                        Debug.Log("cant: " + cells[i, j, k].Count);
                    }
                }
            }
        }
    }


    public void AssignDensityLevel()
    {
        //Debug.Log("max: " + maxAtomsInCell);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                for (int k = 0; k < depth; k++)
                {
                    if (cells[i, j, k].Count > 0)
                    {
                        //float newDensityLevel = cells[i, j, k].Count* generalOpacity / maxAtomsInCell*1.0f;
                        foreach (Atom a in cells[i, j, k])
                        {
                            a.Density= (cells[i, j, k].Count);
                        }
                    }
                }
            }
        }
    }
}
