using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;

namespace Eevee.Upgrades.MiddlePath
{
    public class InflamedFlareon : ModUpgrade<Eevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 2500;
        public override string Portrait => "FlareonPortrait2";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("WizardMonkey-030").GetUpgrade(MIDDLE, 3).icon;
        public override string Description => "More damage and pierce, plus projectiles move faster and last longer.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectileModel = attackModel.GetDescendant<ProjectileModel>();
            //projectileModel.pierce += 5;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 20").GetAttackModel().weapons[0].projectile.Duplicate();
            attackModel.weapons[0].projectile.GetDescendant<DamageOverTimeModel>().damage = 2;
            attackModel.weapons[0].projectile.GetDescendant<DamageOverTimeModel>().immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
            attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
            attackModel.weapons[0].projectile.SetHitCamo(true);
            projectileModel.GetDamageModel().damage += 4;
        }
    }
}
