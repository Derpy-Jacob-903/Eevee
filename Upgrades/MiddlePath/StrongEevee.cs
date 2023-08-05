using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace Eevee.Upgrades.MiddlePath
{
    public class StrongEevee : ModUpgrade <Eevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 500;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-100").GetUpgrade(TOP, 1).icon;
        public override string Description => "Plus two damage";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            if (Main.AltStrongEevee)
            {
                projectileModel.GetDamageModel().damage += 1;
                projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_", "Ceramic,Fortified", 1, 1, false, false));
            }
            else 
            {
                projectileModel.GetDamageModel().damage += 2;
            }
        }
    }
}
