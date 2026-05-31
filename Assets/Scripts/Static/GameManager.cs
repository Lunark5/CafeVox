using UnityEngine;

public class GameManager
{
    private static GameManager _instance;

    private bool _gamePaused;

    public bool GamePaused
    {
        get => _gamePaused;
        set
        {
            _gamePaused = value;

            Time.timeScale = GamePaused ? 0f : 1f;
        }
    }

    public static GameManager Instance => _instance ??= new GameManager();

    public static float SoundVolume
    {
        get => PlayerPrefs.GetFloat("SoundVolume", 0.5f);
        set
        {
            PlayerPrefs.SetFloat("SoundVolume", value);
            PlayerPrefs.Save();
        }
    }

    public static float MouseSensitivity
    {
        get => PlayerPrefs.GetFloat("MouseSensitivity", 0.5f);
        set
        {
            PlayerPrefs.SetFloat("MouseSensitivity", value);
            PlayerPrefs.Save();
        }
    }

    public static float FOV
    {
        get => PlayerPrefs.GetFloat("FOV", 0.5f);
        set
        {
            PlayerPrefs.SetFloat("FOV", value);
            PlayerPrefs.Save();
        }
    }

    private static bool GetBool(string key) => PlayerPrefs.GetInt(key, 0) == 1;

    private static void SaveBool(string prefName, bool newValue)
    {
        PlayerPrefs.SetInt(prefName, !newValue ? 0 : 1);
        PlayerPrefs.Save();
    }
}