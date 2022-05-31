using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Saveobjects so;
    [SerializeField] private TextMeshProUGUI text;
    private int lvlCount;
    private void Awake()
    {
        Init();
    }
    private void Start()
    {
        checkLvl();
    }
    private void LoadSaves()
    {
        so = SaveManager.Load();
        lvlCount = so.Level;
        Debug.Log(lvlCount);
    }
    
    private void checkLvl()
    {
        int level = lvlCount % 3;
        if(level.ToString() != SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene(level.ToString());
        }
        text.text = lvlCount.ToString();
    }
    public void nextLevel()
    {
        lvlCount++;
        so.Level = lvlCount;
        SaveManager.Save(so);
        int level = lvlCount % 3;
        SceneManager.LoadScene(level.ToString());
    }
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Init()
    {
        instance = this;
        LoadSaves();
    }
}
