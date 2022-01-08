using SPGames.Core;
using Unity.Netcode;

namespace SPGames.Game.ThemeparkTown
{
    public class PlayersName : NetworkBehaviour
    {
        private NetworkVariable<NetworkString> playersName = new NetworkVariable<NetworkString>();

        private bool overlaySet = false;

        public override void OnNetworkSpawn()
        {
            if (IsServer)
            {
                playersName.Value = "Player" + OwnerClientId;
            }
        }
    }
}