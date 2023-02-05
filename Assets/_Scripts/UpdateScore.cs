using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI textMeshProUI;
    // Update is called once per frame
    void Update()
    {
        textMeshProUI.text = gameManager.GetHighscore().ToString();
    }
}
