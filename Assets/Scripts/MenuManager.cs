#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Space]

    [SerializeField]
    private Text bestScore;
    [SerializeField] 
    private InputField input;
    
    [Space]

    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button quitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerData bestPlayer = GameManager.gameManager.bestPlayer;
        if (0 != bestPlayer.score)
        {
            bestScore.text = "Best Score: " + bestPlayer.playerName + " : " + bestPlayer.score;
            input.text = bestPlayer.playerName;
        }

        startButton.onClick.AddListener(startGame);
        quitButton.onClick.AddListener(quitGame);
    }

    public void startGame()
    {
        GameManager.gameManager.currentPlayer.playerName = input.text;
        GameManager.gameManager.currentPlayer.score = 0;

        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        GameManager.gameManager.SavePlayer();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif    
    }
}
