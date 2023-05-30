using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private GameObject player;

    private Health pHealth;
    // Start is called before the first frame update
    void Start()
    {
        pHealth = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pHealth.health <= 0)
        {
            gameOver();
        }
    }

    private void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
