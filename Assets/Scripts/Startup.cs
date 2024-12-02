using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    [Header("Manager Settings")]
    [Tooltip("The win message.")]
    public GameObject winMessagePrefab;

    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] Spawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
        List<GameObject> SpawnsList = new List<GameObject>(Spawns);
        System.Random rand = new System.Random(Guid.NewGuid().GetHashCode());

        int index = rand.Next(SpawnsList.Count);
        GameObject p1spawn = SpawnsList[index];
        SpawnsList.RemoveAt(index);

        index = rand.Next(SpawnsList.Count);
        GameObject p2spawn = SpawnsList[index];
        SpawnsList.RemoveAt(index);

        players[0].transform.position = p1spawn.transform.position;
        players[1].transform.position = p2spawn.transform.position;

        Debug.Log(p1spawn);
        Debug.Log(p2spawn.transform.position);
    }

    public void Reset(string msg)
    {
        ShowWinMessage(msg);
        StartCoroutine(DelayAndReset());
    }

    private IEnumerator DelayAndReset()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowWinMessage(string msg)
    {
        // Use FindFirstObjectByType instead of FindObjectOfType
        Canvas canvas = UnityEngine.Object.FindFirstObjectByType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas not found. Please add a Canvas to the scene.");
            return;
        }

        // Instantiate the Text object on the Canvas
        GameObject messageObj = Instantiate(winMessagePrefab, canvas.transform);

        // Set text content
        TextMeshProUGUI tmpText = messageObj.GetComponent<TextMeshProUGUI>();
        tmpText.text = msg;

        // Center the message
        RectTransform rectTransform = messageObj.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero; // Center in the Canvas

        Debug.Log(messageObj);
    }
}
