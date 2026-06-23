using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int collectedItem = 0;
    public int targetItem = 7;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem()
    {
        collectedItem++;

        Debug.Log("Item: " + collectedItem + "/" + targetItem);

        if (collectedItem >= targetItem)
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex + 1
        );
    }
}