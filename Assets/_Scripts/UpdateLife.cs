using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateLife : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI textMeshProUI;
    // Update is called once per frame
    void Update() {
        textMeshProUI.text = gameManager.life.ToString();
    }
}
