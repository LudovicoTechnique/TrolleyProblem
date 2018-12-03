using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemScript : MonoBehaviour
{
    public Tilemap Items;
    
    public TileBase DeadUp;
    public TileBase DeadDown;
    public TileBase DeadLeft;
    public TileBase DeadRight;
    
    public TileBase BlueDeadUp;
    public TileBase BlueDeadDown;
    public TileBase BlueDeadLeft;
    public TileBase BlueDeadRight;
    
    public TileBase LiveUp;
    public TileBase LiveDown;
    public TileBase LiveLeft;
    public TileBase LiveRight;
    
    public TileBase BlueLiveUp;
    public TileBase BlueLiveDown;
    public TileBase BlueLiveLeft;
    public TileBase BlueLiveRight;
    
    public ArrayList Bodies = new ArrayList();
    
    
    public void applyItems(String name, Vector3Int gridPos, int color)
    {
        switch (name)
        {
            case "Person Up":
                if (color == 0)
                {
                    GetComponent<LevelManager>().WhiteKills++;
                    Items.SetTile(gridPos, DeadUp);
                    Bodies.Add(gridPos);
                }
                else
                    GetComponent<LevelManager>().softRestart();

                break;

            case "Person Down":
                if (color == 0)
                {
                    GetComponent<LevelManager>().WhiteKills++;
                    Items.SetTile(gridPos, DeadDown);
                    Bodies.Add(gridPos);
                }
                else
                    GetComponent<LevelManager>().softRestart();
                break;

            case "Person Left":
                if(color == 0){
                GetComponent<LevelManager>().WhiteKills++;
                Items.SetTile(gridPos, DeadLeft);
                Bodies.Add(gridPos);
                }
                else
                    GetComponent<LevelManager>().softRestart();
                break;

            case "Person Right":
                if(color == 0){
                GetComponent<LevelManager>().WhiteKills++;
                Items.SetTile(gridPos, DeadRight);
                Bodies.Add(gridPos);
                }
                else
                    GetComponent<LevelManager>().softRestart();
                break;
            
            case "Blue Person Up":
                if (color == 1)
                {
                    GetComponent<LevelManager>().BlueKills++;
                    Items.SetTile(gridPos, BlueDeadUp);
                    Bodies.Add(gridPos);
                }
                else
                    GetComponent<LevelManager>().softRestart();

                break;

            case "Blue Person Down":
                if (color == 1)
                {
                    GetComponent<LevelManager>().BlueKills++;
                    Items.SetTile(gridPos, BlueDeadDown);
                    Bodies.Add(gridPos);
                }
                else
                    GetComponent<LevelManager>().softRestart();
                break;

            case "Blue Person Left":
                if(color == 1){
                    GetComponent<LevelManager>().BlueKills++;
                    Items.SetTile(gridPos, BlueDeadLeft);
                    Bodies.Add(gridPos);
                }
                else
                    GetComponent<LevelManager>().softRestart();
                break;

            case "Blue Person Right":
                if(color == 1){
                    GetComponent<LevelManager>().BlueKills++;
                    Items.SetTile(gridPos, BlueDeadRight);
                    Bodies.Add(gridPos);
                }
                else
                    GetComponent<LevelManager>().softRestart();
                break;
        }
    }
}
