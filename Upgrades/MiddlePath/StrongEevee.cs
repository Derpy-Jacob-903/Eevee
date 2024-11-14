using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace Eevee.Upgrades.MiddlePath
{
    public class StrongEevee : ModUpgrade <Eevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 500;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-100").GetUpgrade(TOP, 1).icon;
        public override string Description
        {
            get
            {
                if (!Main.StrongEeveeRework) return "Plus two damage";
                else return "Plus one damage, plus one more damage to Ceramic, Fortified, and MOAB-Class Bloons.";
            }
        }

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            if (Main.StrongEeveeRework)
            {
                projectileModel.GetDamageModel().damage += 1;
                projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1, 1, false, false));
                projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1, 1, false, false));
                projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 1, false, false));
            }
            else 
            {
                projectileModel.GetDamageModel().damage += 2;
            }
        }
    }
}
