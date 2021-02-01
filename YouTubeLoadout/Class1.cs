using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace YouTubeLoadout
{
    public class Class1 : BaseScript
    {

        public Class1()
        {
            Tick += OnTick;
            EventHandlers["playerSpawned"] += new Action<Vector3>(playerSpawned);
        }

        private async Task OnTick()
        {
            await Task.Delay(100);
        }

        private void playerSpawned([FromSource] Vector3 spawn)
        {
            Game.PlayerPed.Weapons.RemoveAll();
            Game.PlayerPed.Weapons.Give(WeaponHash.StunGun, 100, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.Pistol, 100, false, true);
            TriggerEvent("chat:addMessage", new
            {
            color = new[] {255,0,0},
            multiline = true,
            args = new[] {"[LOADOUT]", "^3You have received the loadout!"}
            });
        }
    }
}