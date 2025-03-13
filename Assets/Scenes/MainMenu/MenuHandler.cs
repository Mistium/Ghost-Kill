using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Use TextMeshPro namespace

public class MenuHandler : MonoBehaviour {
    void Start() {
        Transform newGameButton = transform.Find("Panel/New Game");

        if (newGameButton != null) {
            TextMeshProUGUI buttonText = newGameButton.GetComponentInChildren<TextMeshProUGUI>();

            if (buttonText != null) {
                // buttonText.text = "Continue";
            } else {
                Debug.LogError("No TextMeshProUGUI component found in button children");
            }
        } else {
            Debug.LogError("Could not find New Game button");
        }
    }

    void Update() {

    }
}