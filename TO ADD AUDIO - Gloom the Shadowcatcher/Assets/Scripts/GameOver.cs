using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    int savedShadows;

    [SerializeField] TextMeshProUGUI savedShadowsUI;
    [SerializeField] TextMeshProUGUI remainingShadowsUI;

    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        savedShadows = levelManager.savedShadows;
        SetUI();
    }

    public void SetUI()
    {
        savedShadowsUI.text = savedShadows.ToString();
        int remaining = 5 - savedShadows;
        remainingShadowsUI.text = remaining.ToString();
    }
}
