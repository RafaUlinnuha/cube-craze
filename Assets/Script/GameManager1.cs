using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public GameObject panelPause;

    // Start is called before the first frame update
    void Start()
    {
        panelPause.SetActive(false);
    }

    public void PauseControl()
    {
        if (Time.timeScale == 1) {
            panelPause.SetActive(true);
            Time.timeScale = 0;
            }
        
        else{
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MenuUtama(string menu)
    {
        Application.LoadLevel(menu);
        Time.timeScale = 1;
    }
    
}
