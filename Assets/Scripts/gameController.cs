using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(gameUI))]
public class gameController : MonoBehaviour
{
    public static gameController Instance { get; private set; }

    [SerializeField]
    private int knifeCount;

    [Header("knife Spawning")]
    [SerializeField]
    private Vector2 knifeSpawnPos;
    [SerializeField]
    private GameObject knifeObject;

    public gameUI gameUI { get; private set; }

    private void Awake()
    {
        Instance = this;
        gameUI = GetComponent<gameUI>();
    }

    private void Start()
    {
        gameUI.SetIntialDisplayedKnideCount(knifeCount);
        SpawnKnife();
    }


    public void OnSuccessfulKnifeHit()
    {
        if (knifeCount>0)
        {
            SpawnKnife();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }

    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPos, Quaternion.identity);

    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCoroutine", win);
    }

    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            RestartGame();
        }
        else
        {
            gameUI.ShowRestartButton();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
