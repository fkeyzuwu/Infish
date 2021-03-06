using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayLevel : MonoBehaviour
{
    private SaveManager saveManager;
    private LevelManager levelManager;
    [SerializeField] private TextMeshProUGUI buttonText;
    private int highestLevel;

    void Start()
    {
        levelManager = LevelManager.Instance;
        saveManager = SaveManager.Instance;

        highestLevel = saveManager.activeSave.highestLevel;
        string path = SceneUtility.GetScenePathByBuildIndex(highestLevel);
        string levelName = System.IO.Path.GetFileNameWithoutExtension(path);
        buttonText.text = levelName;
    }

    public void LoadLevel()
    {
        if (saveManager.activeSave.unlockedPets.Count > 3 && SceneManager.GetActiveScene().buildIndex != 1)
        {
            levelManager.ChangeLevel("Pet Selection Menu");
        }
        else
        {
            levelManager.ChangeLevel(saveManager.activeSave.highestLevel);
        }
    }
}
