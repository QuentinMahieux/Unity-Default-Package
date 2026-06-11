using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject menu;
    void Start()
    {
        if (menu)
        {
            menu.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menu)
        {
            Resume();
        }
    }

    //Reprendre/Mettre en pause la partie
    public void Resume()
    {
        menu.SetActive(!menu.activeSelf);
    }
    

    //Quitter la partie
    public void Leave()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    //Lancer la partie
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    
    //Lancer une nouvelle partie
    public void NewGame()
    {
        
    }

    //Quitter le jeu
    public void Quit()
    {
        Application.Quit();
    }
}
