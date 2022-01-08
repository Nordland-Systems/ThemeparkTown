using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace SPGames.Game.ThemeparkTown
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button hostButton;
        [SerializeField] private Button connectButton;
        [SerializeField] private TMP_Text playersInGameText;
        
        private void Awake()
        {
            Cursor.visible = true;
        }

        private void Update()
        {
            playersInGameText.text = "Players in game: " + PlayersManager.Instance.PlayersInGame;
        }

        private void Start()
        {
            hostButton.onClick.AddListener(() =>
            {
                if (NetworkManager.Singleton.StartHost())
                {
                    Debug.Log("Host started...");
                }
                else
                {
                    Debug.Log("Host could not be started...");
                }
            });
            
            connectButton.onClick.AddListener(() =>
            {
                if (NetworkManager.Singleton.StartClient())
                {
                    Debug.Log("Client started...");
                }
                else
                {
                    Debug.Log("Client could not be started...");
                }
            });
        }
    }
}