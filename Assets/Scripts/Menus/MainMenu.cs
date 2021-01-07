using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Texture2D cursor;

    void Start()
    {
        Cursor.SetCursor(cursor, new Vector2(4, 4), CursorMode.Auto);
    }

    public void Play(string difficulty)
    {
        var diff = 0.75f;
        switch (difficulty)
        {
            case "easy":
                diff = 0.75f;
                break;
            case "medium":
                diff = 0.85f;
                break;
            case "hard":
                diff = 1f;
                break;
        }

        PlayerPrefs.SetFloat("Difficulty", diff);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
