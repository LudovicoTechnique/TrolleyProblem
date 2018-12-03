using MISC;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject Camera;

    public Object Trolly;
    public GameObject TrollyClone;

    public GameObject BlueTrolly;

    public Sprite TrollySprite;
    
    public Sprite BlueTrollySprite;

    public Tilemap Grid;
    public Tilemap Tracks;
    public Tilemap Items;

    
    private string[] Level = {
        "Tutorial",
        "Level 1",
        "Level 2",
        "Level 3",
        "Level 4",
        "Level 6",
        "Level 5",
        "Final Level",
        "Yay"

    };

    public int[] Goal;

    public Vector3[] Spawn;
    
    public Vector3[] BlueSpawn;


    public int LevelIndex;

    public int Kills;

    public int BlueKills;

    public int WhiteKills;

    private bool Flag;

    private bool BlueFlag;


    void Start()
    {
        
     Goal = new int[]
    {
        1,
        3,
        2,
        3,
        3,
        5,
        3,
        56
    };

    Spawn = new []
        {
            new Vector3(5, 25, 0),
            new Vector3(-15, 25, 0),
            new Vector3(-15, 25, 0),
            new Vector3(-15, 25, 0),
            new Vector3(-15, 25, 0),
            new Vector3(-45, -15, 0),
            new Vector3(-15, 25, 0),
            new Vector3(-45, 25, 0), 

        };
        
    BlueSpawn = new []
    {
        new Vector3(5, 25, 0),
        new Vector3(-15, 25, 0),
        new Vector3(-15, 25, 0),
        new Vector3(-15, 25, 0),
        new Vector3(5, 25, 0),
        new Vector3(45, 25, 0), 
        new Vector3(-35, 25, 0), 
        new Vector3(45, -25, 0), 

        

    };

        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            
            TrollyClone = Instantiate(Trolly, Spawn[LevelIndex], Quaternion.identity) as GameObject;

            TrollyClone.GetComponent<TrollyScript>().GameManager = gameObject;
            TrollyClone.GetComponent<TrollyScript>().Camera = Camera;
            TrollyClone.GetComponent<TrollyScript>().Grid = Grid;
            TrollyClone.GetComponent<TrollyScript>().Tracks = Tracks;
            TrollyClone.GetComponent<TrollyScript>().Items = Items;
            TrollyClone.GetComponent<TrollyScript>().Colortype = 0;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Yay")
        {
            if (Input.GetKeyDown("r"))
                softRestart();

            if (Input.GetKeyDown("y"))
                goToNextLever();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    void OnLoadLevel(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name != "Yay")
        {
            string Fuck = BackgroundScript.Instance.name;
            Fuck = Instance.name;
            Fuck = CameraScript.Instance.name;

            Grid = GameObject.Find("Grid").GetComponent<Tilemap>();
            Tracks = GameObject.Find("Tracks").GetComponent<Tilemap>();
            Tracks = GameObject.Find("Tracks").GetComponent<Tilemap>();
            Tracks = GameObject.Find("Tracks").GetComponent<Tilemap>();
            Tracks = GameObject.Find("Tracks").GetComponent<Tilemap>();
            Tracks = GameObject.Find("Tracks").GetComponent<Tilemap>();
            Tracks = GameObject.Find("Tracks").GetComponent<Tilemap>();
            Tracks = GameObject.Find("Tracks").GetComponent<Tilemap>();
            Tracks = GameObject.Find("Tracks").GetComponent<Tilemap>();
            Items = GameObject.Find("OnTrackItems").GetComponent<Tilemap>();

            if (SceneManager.GetActiveScene().name == "Level 4" && BlueTrolly == null)
                BlueTrolly = Instantiate(Trolly, BlueSpawn[LevelIndex], Quaternion.identity) as GameObject;


            if (BlueTrolly != null)
            {
                BlueTrolly.transform.position = BlueSpawn[LevelIndex];

                if (SceneManager.GetActiveScene().name == "Final Level")
                {
                    BlueTrolly.transform.eulerAngles =
                        new Vector3(
                            transform.eulerAngles.x,
                            transform.eulerAngles.y,
                            90
                        );


                    BlueTrolly.GetComponent<TrollyScript>().direction = TrollyScript.facing.left;

                }
                else
                {

                    BlueTrolly.transform.eulerAngles =
                        new Vector3(
                            transform.eulerAngles.x,
                            transform.eulerAngles.y,
                            0
                        );


                    BlueTrolly.GetComponent<TrollyScript>().direction = TrollyScript.facing.down;
                }


                BlueTrolly.GetComponent<SpriteRenderer>().sprite = BlueTrollySprite;

                BlueTrolly.GetComponent<TrollyScript>().GameManager = gameObject;
                BlueTrolly.GetComponent<TrollyScript>().Camera = Camera;
                BlueTrolly.GetComponent<TrollyScript>().Grid = Grid;
                BlueTrolly.GetComponent<TrollyScript>().Tracks = Tracks;
                BlueTrolly.GetComponent<TrollyScript>().Items = Items;
                BlueTrolly.GetComponent<TrollyScript>().Colortype = 1;
            }


            //TrollyClone = Instantiate(Trolly, Spawn[LevelIndex], Quaternion.identity) as GameObject;
            TrollyClone.transform.position = Spawn[LevelIndex];

            if (SceneManager.GetActiveScene().name == "Final Level")
            {
                TrollyClone.transform.eulerAngles =
                    new Vector3(
                        transform.eulerAngles.x,
                        transform.eulerAngles.y,
                        270
                    );

                TrollyClone.GetComponent<TrollyScript>().direction = TrollyScript.facing.right;

            }
            else
            {

                TrollyClone.transform.eulerAngles =
                    new Vector3(
                        transform.eulerAngles.x,
                        transform.eulerAngles.y,
                        0
                    );

                TrollyClone.GetComponent<TrollyScript>().direction = TrollyScript.facing.down;
            }



            TrollyClone.GetComponent<SpriteRenderer>().sprite = TrollySprite;

            TrollyClone.GetComponent<TrollyScript>().GameManager = gameObject;
            TrollyClone.GetComponent<TrollyScript>().Camera = Camera;
            TrollyClone.GetComponent<TrollyScript>().Grid = Grid;
            TrollyClone.GetComponent<TrollyScript>().Tracks = Tracks;
            TrollyClone.GetComponent<TrollyScript>().Items = Items;
            TrollyClone.GetComponent<TrollyScript>().Colortype = 0;

            //Fuck = TrollyScript.Instance.name;

            GetComponent<ItemScript>().Items = Items;

            Camera.GetComponent<InteractScript>().Grid = Grid;
            Camera.GetComponent<InteractScript>().Tracks = Tracks;
            Camera.GetComponent<InteractScript>().Interactables =
                GameObject.Find("Interactables").GetComponent<Tilemap>();
        }
        else
        {
            Destroy(BlueTrolly);
            Destroy(TrollyClone);
        }
    }
    

    public void endFlagReached(int color)
    {
        Kills = BlueKills + WhiteKills;
        
        if (color == 0)
            Flag = true;
        else
           BlueFlag = true;
        
        if (BlueTrolly != null)
        {
            if (Kills == Goal[LevelIndex] && BlueFlag && Flag)
                goToNextLever();
            else if (BlueFlag && Flag)
                softRestart();

        }
        else
        {
            if(Kills == Goal[LevelIndex])
                goToNextLever();
            else
                softRestart();
        }


    }

    public void softRestart()
    {
        Debug.Log("yeah");
        
        TrollyClone.transform.position = Spawn[LevelIndex];
        
        TrollyClone.transform.eulerAngles = 
            new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                0
            );

        TrollyClone.GetComponent<TrollyScript>().direction = TrollyScript.facing.down;
        if (BlueTrolly != null)
        {
            BlueTrolly.transform.position = BlueSpawn[LevelIndex];

            BlueTrolly.transform.eulerAngles =
                new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    0
                );

            BlueTrolly.GetComponent<TrollyScript>().direction = TrollyScript.facing.down;
                    
            BlueTrolly.GetComponent<SpriteRenderer>().sprite = BlueTrollySprite;
        }

        foreach(Vector3Int pos in GetComponent<ItemScript>().Bodies)
        {
            switch (GetComponent<ItemScript>().Items.GetTile(pos).name)
            {
                case "Dead Person Up":
                    GetComponent<ItemScript>().Items.SetTile(pos, GetComponent<ItemScript>().LiveUp);
                    break;
                    
                case "Dead Person Down":
                    GetComponent<ItemScript>().Items.SetTile(pos, GetComponent<ItemScript>().LiveDown);
                    break;
                    
                case "Dead Person Left":
                    GetComponent<ItemScript>().Items.SetTile(pos, GetComponent<ItemScript>().LiveLeft);
                    break;
                    
                case "Dead Person Right":
                    GetComponent<ItemScript>().Items.SetTile(pos, GetComponent<ItemScript>().LiveRight);
                    break;
                
                case "Dead Blue Up":
                    GetComponent<ItemScript>().Items.SetTile(pos, GetComponent<ItemScript>().BlueLiveUp);
                    break;
                    
                case "Dead Blue Down":
                    GetComponent<ItemScript>().Items.SetTile(pos, GetComponent<ItemScript>().BlueLiveDown);
                    break;
                    
                case "Dead Blue Left":
                    GetComponent<ItemScript>().Items.SetTile(pos, GetComponent<ItemScript>().BlueLiveLeft);
                    break;
                    
                case "Dead Blue Right":
                    GetComponent<ItemScript>().Items.SetTile(pos, GetComponent<ItemScript>().BlueLiveRight);
                    break;
                
            }
        }
        
        Camera.GetComponent<InteractScript>().Start = false;

        Kills = 0;
        WhiteKills = 0;
        BlueKills = 0;

        Flag = false;

        BlueFlag = false;

        TrollyClone.GetComponent<SpriteRenderer>().sprite = TrollySprite;


    }
    

    public void hardRestart()
    {
        Kills = 0;
        WhiteKills = 0;
        BlueKills = 0;
        Flag = false;
        BlueFlag = false;
        GetComponent<ItemScript>().Bodies.Clear();
        //Destroy(TrollyClone);
        Camera.GetComponent<InteractScript>().Start = false;
        SceneManager.LoadScene(Level[LevelIndex]);
        SceneManager.sceneLoaded += OnLoadLevel;
    }
    
    private void goToNextLever()
    {
        LevelIndex++;
        hardRestart();
    }
    
}
    