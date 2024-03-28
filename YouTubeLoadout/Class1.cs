using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

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

            // Give Stun Gun
            Game.PlayerPed.Weapons.Give(WeaponHash.StunGun, 100, false, true);

            // Give Pistol with Flashlight attachment
            var pistol = Game.PlayerPed.Weapons.Give(WeaponHash.Pistol, 100, false, true);
            API.GiveWeaponComponentToWeaponObject(pistol.GetHashCode(), (uint)WeaponComponentHash.FlashlightLight);
            
            // Give Carbine Rifle with Light attachment
            var carbineRifle = Game.PlayerPed.Weapons.Give(WeaponHash.CarbineRifle, 100, false, true);
            API.GiveWeaponComponentToWeaponObject(pistol.GetHashCode(), (uint)WeaponComponentHash.AtArFlsh);

            
            // Give Nightstick
            Game.PlayerPed.Weapons.Give(WeaponHash.Nightstick, 1, false, true);

            //Give Flashlight
            Game.PlayerPed.Weapons.Give(WeaponHash.Flashlight, 1, false, true);
            
            // Give Flare
            Game.PlayerPed.Weapons.Give(WeaponHash.Flare, 10, false, true);

            // Give Gas Can
            Game.PlayerPed.Weapons.Give(WeaponHash.PetrolCan, 1, false, true);

            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                multiline = true,
                args = new[] { "[LOADOUT]", "^3You have received the loadout with default gear!" }
            });
        }
    }
}