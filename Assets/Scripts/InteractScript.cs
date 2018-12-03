using System;
using UnityEngine;
using UnityEngine.Tilemaps;
public class InteractScript : MonoBehaviour
{

    public bool Start;
    
    public Tilemap Grid;
    public Tilemap Tracks;
    public Tilemap Interactables;

    public TileBase Straight;
    public TileBase StraightSide;
    public TileBase Curved;
    public TileBase Curved90;
    public TileBase Curved180;
    public TileBase Curved270;

    private String[] AcceptsTop =
    {
        "Straight Track",
        "Curved Track",
        "Curved Track 90",
        "Splitter var 1",
        "Splitter var 2",
        "Splitter var 4",
        "Splitter var 5",
        "Splitter var 6",
        "Splitter var 7",
        "Blockade",
        "Tunnel Down"
    };

    private String[] AcceptsBottom =
    {
        "Straight Track",
        "Curved Track 180",
        "Curved Track 270",
        "Splitter var 2",
        "Splitter var 3",
        "Splitter var 4",
        "Splitter var 5",
        "Splitter var 7",
        "Splitter var 8",
        "Blockade",
        "Tunnel Up"
    };
    
    private String[] AcceptsLeft =
    {
        "Straight Track Sideways",
        "Curved Track 90",
        "Curved Track 180",
        "Splitter var 1",
        "Splitter var 2",
        "Splitter var 3",
        "Splitter var 6",
        "Splitter var 7",
        "Splitter var 8",
        "Blockade Left",
        "Blockade Right",
        "Tunnel Right"
    };
    
    private String[] AcceptsRight =
    {
        "Straight Track Sideways",
        "Curved Track",
        "Curved Track 270",
        "Splitter var 1",
        "Splitter var 3",
        "Splitter var 4",
        "Splitter var 5",
        "Splitter var 6",
        "Splitter var 8",
        "Blockade Left",
        "Blockade Right",
        "Tunnel Left"
    };

    private void Update()
    {
        if (!Start)
        RealUpdate();
    }

    void RealUpdate()
    {
        if (Input.GetKeyDown("space"))
            Start = true;
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos =  new Vector3Int( Mathf.FloorToInt(pos.x/ Grid.cellSize.x), Mathf.FloorToInt(pos.y /Grid.cellSize.y), 0);

            TileBase tile = Interactables.GetTile(gridPos);


            if (tile != null)
            {
                String CurrentTile = Tracks.GetTile(gridPos).name;

                bool Bottom = (Tracks.GetTile(new Vector3Int(gridPos.x, gridPos.y + 1, gridPos.z)) != null
                    ? CheckAbove(Tracks.GetTile(new Vector3Int(gridPos.x, gridPos.y + 1, gridPos.z)).name)
                    : false);
                
                bool Top = (Tracks.GetTile(new Vector3Int(gridPos.x, gridPos.y - 1, gridPos.z)) != null ?
                    CheckBelow(Tracks.GetTile(new Vector3Int(gridPos.x, gridPos.y - 1, gridPos.z)).name)
                    : false);

                bool Left = (Tracks.GetTile(new Vector3Int(gridPos.x + 1, gridPos.y, gridPos.z)) != null
                    ? CheckRight(Tracks.GetTile(new Vector3Int(gridPos.x + 1, gridPos.y, gridPos.z)).name)
                    : false);
                
                bool Right = (Tracks.GetTile(new Vector3Int(gridPos.x - 1, gridPos.y, gridPos.z)) != null
                    ? CheckLeft(Tracks.GetTile(new Vector3Int(gridPos.x - 1, gridPos.y, gridPos.z)).name)
                    : false);
                

                switch (tile.name)
                {
                    case "Bottom Connector":
                        if (Bottom && !CurrentTile.Equals("Straight Track"))
                            Tracks.SetTile(gridPos, Straight);
                        else if (Left && !CurrentTile.Equals("Curved Track 270"))
                            Tracks.SetTile(gridPos, Curved270);
                        else if (Right && !CurrentTile.Equals("Curved Track 180"))
                            Tracks.SetTile(gridPos, Curved180);
                        break;

                    case "Top Connector":
                        if (Top && !CurrentTile.Equals("Straight Track"))
                            Tracks.SetTile(gridPos, Straight);
                        else if (Left && !CurrentTile.Equals("Curved Track"))
                            Tracks.SetTile(gridPos, Curved);
                        else if (Right && !CurrentTile.Equals("Curved Track 90"))
                            Tracks.SetTile(gridPos, Curved90);
                        break;

                    case "Left Connector":
                        if (Left && !CurrentTile.Equals("Straight Track Sideways"))
                            Tracks.SetTile(gridPos, StraightSide);
                        else if (Bottom && !CurrentTile.Equals("Curved Track 90"))
                            Tracks.SetTile(gridPos, Curved90);
                        else if (Top && !CurrentTile.Equals("Curved Track 180"))
                            Tracks.SetTile(gridPos, Curved180);
                        break;

                    case "Right Connector":
                        if (Right && !CurrentTile.Equals("Straight Track Sideways"))
                            Tracks.SetTile(gridPos, StraightSide);
                        else if (Bottom && !CurrentTile.Equals("Curved Track"))
                            Tracks.SetTile(gridPos, Curved);
                        else if (Top && !CurrentTile.Equals("Curved Track 270"))
                            Tracks.SetTile(gridPos, Curved270);
                        break;
                }
            }
        }
    }

    private bool CheckBelow(String name)
    {
        foreach (var var in AcceptsTop)
        {
            if (var == name)
                return true;
        }

        return false;
    }
    
    private bool CheckAbove(String name)
    {
        foreach (var var in AcceptsBottom)
        {
            if (var == name)
                return true;
        }

        return false;
    }
    
    private bool CheckLeft(String name)
    {
        foreach (var var in AcceptsRight)
        {
            if (var == name)
                return true;
        }

        return false;
    }
    
    private bool CheckRight(String name)
    {
        foreach (var var in AcceptsLeft)
        {
            if (var == name)
                return true;
        }

        return false;
    }
    
}
