using UnityEngine;

public class CloseGame : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
