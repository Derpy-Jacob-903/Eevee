using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;

namespace Eevee.Upgrades.MiddlePath
{
    public class MasterOfFire : ModUpgrade<Eevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 42000;
        public override string Portrait => "FlareonPortrait3";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter-500").GetUpgrade(TOP, 5).icon;
        public override string Description => "Increased range, pierce, damage and attack speed.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectileModel = attackModel.GetDescendant<ProjectileModel>();
            towerModel.range += 20;
            attackModel.range += 20;
            projectileModel.pierce += 6;
            projectileModel.GetDamageModel().damage += 64;
            attackModel.weapons[0].projectile.GetDescendant<DamageOverTimeModel>().damage = 13;
            attackModel.weapons[0].projectile.GetDescendant<DamageOverTimeModel>().immuneBloonProperties = Il2Cpp.BloonProperties.None;
            attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
            towerModel.GetWeapon().rate *= 0.2f;
        }
    }
}
