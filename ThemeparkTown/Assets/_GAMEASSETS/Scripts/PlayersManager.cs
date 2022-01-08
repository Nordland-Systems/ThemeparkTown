using System;
using SPGames.Core;
using Unity.Netcode;
using UnityEngine;

namespace SPGames.Game.ThemeparkTown
{
    public class PlayersManager : Singleton<PlayersManager>
    {
        private NetworkVariable<int> playersInGame = new NetworkVariable<int>();

        public int PlayersInGame
        {
            get => playersInGame.Value;
            set => playersInGame.Value = value;
        }

        private void Start()
        {
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnect;
        }
        
        private void OnClientConnected(ulong obj)
        {
            if (IsServer)
            {
                Debug.Log($"{obj} just connected");
                playersInGame.Value++;
            }
        }

        private void OnClientDisconnect(ulong obj)
        {
            if (IsServer)
            {
                Debug.Log($"{obj} just disconnected");
                playersInGame.Value--;
            }
        }

        
    }
}