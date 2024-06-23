using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Unity;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace Eevee.Upgrades.TopPath
{
    public class MorePiercedPins : ModUpgrade<Eevee>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 400;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("DartMonkey-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Two more Pierce";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            projectileModel.pierce += 2;
            if (towerModel.GetUpgradeLevel(1) >= 3) //Is Jolteon?
            {
                projectileModel.pierce += 2;
            }
            if (towerModel.GetUpgradeLevel(2) >= 3) //Is Jolteon?
            {
                projectileModel.GetDescendant<CreateProjectileOnContactModel>().projectile.pierce += 10;
            }
        }
    }
}
