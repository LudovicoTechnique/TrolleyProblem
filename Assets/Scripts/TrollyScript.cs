using System;
using System.Runtime.CompilerServices;
using MISC;
using UnityEngine;
using UnityEngine.Tilemaps;
using Color = System.Drawing.Color;

public class TrollyScript : MonoBehaviour
{

    public enum facing
    {
        up,
        down,
        left,
        right
    }

    public Tilemap Grid;
    public Tilemap Tracks;
    public Tilemap Items;
    public GameObject Camera;
    public GameObject GameManager;

    public Sprite Bloody;

    public Sprite Bloodier;

    public Sprite B1,
        B2,
        B3,
        B4,
        B5,
        B6,
        B7,
        B8,
        B9,
        B10;
    
    public Sprite BB1,
        BB2,
        BB3,
        BB4,
        BB5,
        BB6,
        BB7,
        BB8,
        BB9,
        BB10;
    
    public Sprite BlueBloody;

    public Sprite BlueBloodier;
    
    public facing direction;

    private Vector3 targetPoint;

    private bool turnTrack;

    private Vector3Int oldGridPos;

    private bool justEnetered;

    public int Colortype;


    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        direction = facing.down;
        targetPoint = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Colortype == 0)
        {
            if (GameManager.GetComponent<LevelManager>().WhiteKills >= 24)
            {
                if (GetComponent<SpriteRenderer>().sprite != B10)
                    GetComponent<SpriteRenderer>().sprite = B10;
            }
            else if (GameManager.GetComponent<LevelManager>().WhiteKills >= 21)
            {
                if (GetComponent<SpriteRenderer>().sprite != B9)
                    GetComponent<SpriteRenderer>().sprite = B9;
            }
            else if (GameManager.GetComponent<LevelManager>().WhiteKills >= 19)
            {
                if (GetComponent<SpriteRenderer>().sprite != B8)
                    GetComponent<SpriteRenderer>().sprite = B8;
            }
            else if (GameManager.GetComponent<LevelManager>().WhiteKills >= 17)
            {
                if (GetComponent<SpriteRenderer>().sprite != B7)
                    GetComponent<SpriteRenderer>().sprite = B7;
            }
            else if (GameManager.GetComponent<LevelManager>().WhiteKills >= 15)
            {
                if (GetComponent<SpriteRenderer>().sprite != B6)
                    GetComponent<SpriteRenderer>().sprite = B6;
            }
            else if (GameManager.GetComponent<LevelManager>().WhiteKills >= 13)
            {
                if (GetComponent<SpriteRenderer>().sprite != B5)
                    GetComponent<SpriteRenderer>().sprite = B5;
            }
            else if (GameManager.GetComponent<LevelManager>().WhiteKills >= 11)
            {
                if (GetComponent<SpriteRenderer>().sprite != B4)
                    GetComponent<SpriteRenderer>().sprite = B4;
            }
            else if (GameManager.GetComponent<LevelManager>().WhiteKills >= 9)
            {
                if (GetComponent<SpriteRenderer>().sprite != B3)
                    GetComponent<SpriteRenderer>().sprite = B3;
            }
            else if (GameManager.GetComponent<LevelManager>().WhiteKills >= 7)
            {
                if (GetComponent<SpriteRenderer>().sprite != B2)
                    GetComponent<SpriteRenderer>().sprite = B2;
            }
            else if (GameManager.GetComponent<LevelManager>().WhiteKills >= 5)
            {
                if (GetComponent<SpriteRenderer>().sprite != B1)
                    GetComponent<SpriteRenderer>().sprite = B1;
            }   
            else if (GameManager.GetComponent<LevelManager>().WhiteKills >= 3)
            {
                if (GetComponent<SpriteRenderer>().sprite != Bloodier)
                    GetComponent<SpriteRenderer>().sprite = Bloodier;
            }
            else if (GameManager.GetComponent<LevelManager>().WhiteKills != 0 &&
                     GetComponent<SpriteRenderer>().sprite != Bloody)
                GetComponent<SpriteRenderer>().sprite = Bloody;
        }
        else if (Colortype == 1)
        {
            if (GameManager.GetComponent<LevelManager>().BlueKills >= 24)
            {
                if (GetComponent<SpriteRenderer>().sprite != BB10)
                    GetComponent<SpriteRenderer>().sprite = BB10;
            }
            else if (GameManager.GetComponent<LevelManager>().BlueKills >= 21)
            {
                if (GetComponent<SpriteRenderer>().sprite != BB9)
                    GetComponent<SpriteRenderer>().sprite = BB9;
            }
            else if (GameManager.GetComponent<LevelManager>().BlueKills >= 19)
            {
                if (GetComponent<SpriteRenderer>().sprite != BB8)
                    GetComponent<SpriteRenderer>().sprite = BB8;
            }
            else if (GameManager.GetComponent<LevelManager>().BlueKills >= 17)
            {
                if (GetComponent<SpriteRenderer>().sprite != BB7)
                    GetComponent<SpriteRenderer>().sprite = BB7;
            }
            else if (GameManager.GetComponent<LevelManager>().BlueKills >= 15)
            {
                if (GetComponent<SpriteRenderer>().sprite != BB6)
                    GetComponent<SpriteRenderer>().sprite = BB6;
            }
            else if (GameManager.GetComponent<LevelManager>().BlueKills >= 13)
            {
                if (GetComponent<SpriteRenderer>().sprite != BB5)
                    GetComponent<SpriteRenderer>().sprite = BB5;
            }
            else if (GameManager.GetComponent<LevelManager>().BlueKills >= 11)
            {
                if (GetComponent<SpriteRenderer>().sprite != BB4)
                    GetComponent<SpriteRenderer>().sprite = BB4;
            }
            else if (GameManager.GetComponent<LevelManager>().BlueKills >= 9)
            {
                if (GetComponent<SpriteRenderer>().sprite != BB3)
                    GetComponent<SpriteRenderer>().sprite = BB3;
            }
            else if (GameManager.GetComponent<LevelManager>().BlueKills >= 7)
            {
                if (GetComponent<SpriteRenderer>().sprite != BB2)
                    GetComponent<SpriteRenderer>().sprite = BB2;
            }
            else if (GameManager.GetComponent<LevelManager>().BlueKills >= 5)
            {
                if (GetComponent<SpriteRenderer>().sprite != BB1)
                    GetComponent<SpriteRenderer>().sprite = BB1;
            }   
            else if (GameManager.GetComponent<LevelManager>().BlueKills >= 3)
            {
                if (GetComponent<SpriteRenderer>().sprite != BlueBloodier)
                    GetComponent<SpriteRenderer>().sprite = BlueBloodier;
            }
            else if (GameManager.GetComponent<LevelManager>().BlueKills != 0 &&
                     GetComponent<SpriteRenderer>().sprite != BlueBloody)
                GetComponent<SpriteRenderer>().sprite = BlueBloody;
        }
        
        
        if (Camera.GetComponent<InteractScript>().Start)
            RealUpdate();
    }

    void RealUpdate()
    {

        Vector3Int gridPos =  new Vector3Int( Mathf.FloorToInt(transform.position.x / Grid.cellSize.x), Mathf.FloorToInt(transform.position.y /Grid.cellSize.y), 0);

        if (oldGridPos != gridPos)
        {
            justEnetered = true;
            turnTrack = false;
        }
        else
            justEnetered = false;
        
        oldGridPos = gridPos;
        //Debug.Log(gridPos);
        
        TileBase currentTrack = Tracks.GetTile(gridPos);
        TileBase currentTrackAdditions = Items.GetTile(gridPos);
 
        moveOnTrack(currentTrack.name, gridPos);
        if(currentTrackAdditions != null)
            GameManager.GetComponent<ItemScript>().applyItems(currentTrackAdditions.name, gridPos, Colortype);

    }



    private void moveOnTrack(String name, Vector3Int gridPos)
    {
        switch(name)
        {
            case "Straight Track":
                StraightTrack(gridPos);
                break;
            
            case "Tunnel Up":
                transform.Translate(new Vector3(0,-16,0) * Time.deltaTime);
                transform.position =
                    new Vector3( 
                        gridPos.x * 10 + 5,
                        transform.position.y,
                        transform.position.z
                    );
                transform.eulerAngles = 
                    new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    180
                );
                break;
            
            case "Tunnel Down":
                transform.Translate(new Vector3(0,-16,0) * Time.deltaTime);
                transform.position =
                    new Vector3( 
                        gridPos.x * 10 + 5,
                        transform.position.y,
                        transform.position.z
                    );
                transform.eulerAngles = 
                    new Vector3(
                        transform.eulerAngles.x,
                        transform.eulerAngles.y,
                        0
                    );
                break;
            
            case "Straight Track Sideways":
                SideTrack(gridPos);
                break;
            
            case "Tunnel Left":
                transform.Translate(new Vector3(0,-16,0)* Time.deltaTime);
                transform.position =
                    new Vector3(
                        transform.position.x,
                        gridPos.y * 10 + 5,
                        transform.position.z
                    );
                transform.eulerAngles = 
                    new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    270
                );
                break;
            
            case "Tunnel Right":
                transform.Translate(new Vector3(0,-16,0)* Time.deltaTime);
                transform.position =
                    new Vector3(
                        transform.position.x,
                        gridPos.y * 10 + 5,
                        transform.position.z
                    );
                transform.eulerAngles = 
                    new Vector3(
                        transform.eulerAngles.x,
                        transform.eulerAngles.y,
                        90
                    );
                break;
            
            case "Curved Track":
                if (justEnetered)
                {
                    if (direction == facing.down || direction == facing.left)
                    {
                        if (direction == facing.down)
                            direction = facing.right;
                        else
                            direction = facing.up;
                    }
                    else
                        GameManager.GetComponent<LevelManager>().softRestart();
                }

                targetPoint = new Vector3((gridPos.x + 1) * 10, (gridPos.y + 1) * 10, 0);
                transform.RotateAround(targetPoint, new Vector3(0,0,1), 90*Time.deltaTime * (direction == facing.right ? 1 : -1));
                break;
            
            case "Curved Track 90":
                if (justEnetered)
                {
                    if (direction == facing.down || direction == facing.right)
                    {
                        if (direction == facing.down)
                            direction = facing.left;
                        else
                            direction = facing.up;
                    }
                    else
                        GameManager.GetComponent<LevelManager>().softRestart();
                }

                targetPoint = new Vector3(gridPos.x * 10, (gridPos.y + 1) * 10, 0);
                transform.RotateAround(targetPoint, new Vector3(0,0,1), 90*Time.deltaTime * (direction == facing.up ? 1 : -1));
                break;
            
            case "Curved Track 180":
                if (justEnetered)
                {
                    if (direction == facing.up || direction == facing.right)
                    {
                        if (direction == facing.up)
                            direction = facing.left;
                        else
                            direction = facing.down;
                    }
                    else
                        GameManager.GetComponent<LevelManager>().softRestart();
                }

                targetPoint = new Vector3(gridPos.x * 10, gridPos.y * 10, 0);
                transform.RotateAround(targetPoint, new Vector3(0,0,1), 90*Time.deltaTime * (direction == facing.left ? 1 : -1));
                break;
            
            case "Curved Track 270":
                if (justEnetered)
                {
                    if (direction == facing.up|| direction == facing.left)
                    {
                        if (direction == facing.up)
                            direction = facing.right;
                        else
                            direction = facing.down;
                    }
                    else
                        GameManager.GetComponent<LevelManager>().softRestart();
                }

                targetPoint = new Vector3((gridPos.x + 1) * 10, gridPos.y * 10, 0);
                transform.RotateAround(targetPoint, new Vector3(0,0,1), 90*Time.deltaTime * (direction == facing.down ? 1 : -1));
                break;
            
            case "Splitter var 1":
                
                if(direction == facing.up && justEnetered)
                    GameManager.GetComponent<LevelManager>().softRestart();
                
                if (direction == facing.down)
                    turnTrack = true;
                
                if (turnTrack)
                {
                    direction = facing.right;
                         
                    targetPoint = new Vector3((gridPos.x + 1) * 10, (gridPos.y + 1) * 10, 0);
                    transform.RotateAround(targetPoint, new Vector3(0,0,1), 90*Time.deltaTime);
                }
                else
                SideTrack(gridPos);
                break;
                
            case "Splitter var 2":
                
                if(direction == facing.left && justEnetered)
                    GameManager.GetComponent<LevelManager>().softRestart();
                
                if (direction == facing.right)
                    turnTrack = true;
                
                if (turnTrack)
                {
                    direction = facing.up;
                         
                    targetPoint = new Vector3(gridPos.x * 10, (gridPos.y + 1) * 10, 0);
                    transform.RotateAround(targetPoint, new Vector3(0,0,1), 90*Time.deltaTime);
                }
                else
                    StraightTrack(gridPos);
                break;
                
            case "Splitter var 3":       
                
                if(direction == facing.down && justEnetered)
                    GameManager.GetComponent<LevelManager>().softRestart();
                
                if (direction == facing.up)
                    turnTrack = true;
                
                if (turnTrack)
                {
                    direction = facing.left;
                         
                    targetPoint = new Vector3(gridPos.x * 10, gridPos.y * 10, 0);
                    transform.RotateAround(targetPoint, new Vector3(0,0,1), 90*Time.deltaTime);
                }
                else
                    SideTrack(gridPos);
                break;
                
            case "Splitter var 4":
                
                if(direction == facing.right && justEnetered)
                    GameManager.GetComponent<LevelManager>().softRestart();
                
                if (direction == facing.left)
                    turnTrack = true;
                
                if (turnTrack)
                {
                    direction = facing.down;
                         
                    targetPoint = new Vector3((gridPos.x + 1) * 10, gridPos.y * 10, 0);
                    transform.RotateAround(targetPoint, new Vector3(0,0,1), 90*Time.deltaTime);
                }
                else
                    StraightTrack(gridPos);

                break;
                
            case "Splitter var 5":
                
                if(direction == facing.right && justEnetered)
                    GameManager.GetComponent<LevelManager>().softRestart();
                
                if (direction == facing.left)
                    turnTrack = true;
                
                if (turnTrack)
                {
                    direction = facing.up;
                         
                    targetPoint = new Vector3((gridPos.x + 1) * 10, (gridPos.y + 1) * 10, 0);
                    transform.RotateAround(targetPoint, new Vector3(0,0,1), -90*Time.deltaTime);
                }
                else
                    StraightTrack(gridPos);
                break;
                
            case "Splitter var 6":
                
                if(direction == facing.up && justEnetered)
                    GameManager.GetComponent<LevelManager>().softRestart();
                
                if (direction == facing.down)
                    turnTrack = true;
                
                if (turnTrack)
                {
                    direction = facing.left;
                         
                    targetPoint = new Vector3(gridPos.x * 10, (gridPos.y + 1) * 10, 0);
                    transform.RotateAround(targetPoint, new Vector3(0,0,1), -90*Time.deltaTime);
                }
                else
                SideTrack(gridPos);
                break;
                
            case "Splitter var 7":
                
                if(direction == facing.left && justEnetered)
                    GameManager.GetComponent<LevelManager>().softRestart();
                
                if (direction == facing.right)
                    turnTrack = true;
                
                if (turnTrack)
                {
                    direction = facing.down;
                         
                    targetPoint = new Vector3(gridPos.x * 10, gridPos.y * 10, 0);
                    transform.RotateAround(targetPoint, new Vector3(0,0,1), -90*Time.deltaTime);
                }
                else
                    StraightTrack(gridPos);
                break;
                
            case "Splitter var 8":
                
                if(direction == facing.down && justEnetered)
                    GameManager.GetComponent<LevelManager>().softRestart();
                
                if (direction == facing.up)
                    turnTrack = true;
                
                if (turnTrack)
                {
                    direction = facing.right;
                         
                    targetPoint = new Vector3((gridPos.x + 1) * 10, gridPos.y * 10, 0);
                    transform.RotateAround(targetPoint, new Vector3(0,0,1), -90*Time.deltaTime);
                }
                else
                    SideTrack(gridPos);
                break;
            
            case "Blockade":
                GameManager.GetComponent<LevelManager>().softRestart();
                break;
            
            case "Blockade Left":
                GameManager.GetComponent<LevelManager>().softRestart();
                break;
            
            case "Blockade Right":
                GameManager.GetComponent<LevelManager>().softRestart();
                break;
            
            case "End Flag":
                if(Colortype == 0)
                    GameManager.GetComponent<LevelManager>().endFlagReached(0);
                else
                    GameManager.GetComponent<LevelManager>().softRestart();
                break;
            
            case "Blue End Flag":
                if(Colortype == 1)
                    GameManager.GetComponent<LevelManager>().endFlagReached(1);
                else
                    GameManager.GetComponent<LevelManager>().softRestart();
                break;
        }
    }


    private void StraightTrack(Vector3Int gridPos)
    {
        transform.Translate(new Vector3(0,-16,0) * Time.deltaTime);
        transform.position =
            new Vector3( 
                gridPos.x * 10 + 5,
                transform.position.y,
                transform.position.z
            );
        transform.eulerAngles = direction == facing.up
            ? new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                180
            )
            : new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                0
            );
    }

    private void SideTrack(Vector3Int gridPos)
    {
        transform.Translate(new Vector3(0,-16,0)* Time.deltaTime);
        transform.position =
            new Vector3(
                transform.position.x,
                gridPos.y * 10 + 5,
                transform.position.z
            );
        transform.eulerAngles = direction == facing.left
            ? new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                270
            )
            : new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                90
            );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.GetComponent<LevelManager>().softRestart();
    }
}
