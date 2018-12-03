
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI Counter;
    
    public void Update()
    {
        Counter.text = GetComponent<LevelManager>().Kills + "/" +
                        GetComponent<LevelManager>().Goal[GetComponent<LevelManager>().LevelIndex];
    }
}
