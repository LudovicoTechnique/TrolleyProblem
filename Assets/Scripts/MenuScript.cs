using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("space"))
            SceneManager.LoadScene("Tutorial");
    }
}
