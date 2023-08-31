using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace Eevee.Upgrades.MiddlePath
{
    public class HardenedPins : ModUpgrade<Eevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 250;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("DartlingGunner-002").GetUpgrade(MIDDLE, 1).icon;
        public override string Description => "Hardened pins can pop Frozen Bloons and do extra damage to Ceramic and Fortified Bloons.";
        public override int Priority => -1;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            //towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_", "Ceramic,Fortified", 1, 1, false, false));
        }
    }
    public class StrongEevee : ModUpgrade<Eevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 500;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-100").GetUpgrade(TOP, 1).icon;
        public override string Description => "Superhot pins do extra damage and can also pop Lead Bloons.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {

            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            //if (Main.AltStrongEevee)
            //{
            projectileModel.GetDamageModel().damage += 1;
            //}
            //else 
            //{
            //projectileModel.GetDamageModel().damage += 2;
            //}
        }
    }
    //
    public class Flareon : ModUpgrade<Eevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 2500;
        public override string Portrait => "FlareonPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("WizardMonkey-010").GetUpgrade(MIDDLE, 1).icon;
        public override string Description => "Replaces pins with small flames that light Bloons ablaze. Increased popping power and attack range.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel(); 
            var projectileModel = attackModel.GetDescendant<ProjectileModel>();
            //projectileModel.pierce += 2;
            towerModel.range += 10;
            //var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate(); //+5 pierce (1 to 6)
            projectileModel.pierce -= 3; //+2 pierce (1 to 3)
            //towerModel.GetWeapon().rate *= 0.5f;
            //attackModel.weapons[0].projectile.SetHitCamo(true);
            towerModel.ApplyDisplay<FlareonDisplay>();
        }
    }
    public class InflamedFlareon : ModUpgrade<Eevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 2500;
        public override string Portrait => "FlareonPortrait2";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("WizardMonkey-030").GetUpgrade(MIDDLE, 3).icon;
        public override string Description => "More damage and pierce";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectileModel = attackModel.GetDescendant<ProjectileModel>();
            //projectileModel.GetDamageModel().damage += 8;
            //projectileModel.pierce += 5;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 15").GetAttackModel().weapons[0].projectile.Duplicate();
            //attackModel.weapons[0].projectile.SetHitCamo(true);
        }
    }

    public class MasterOfFire : ModUpgrade<Eevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 42000;
        public override string Portrait => "FlareonPortrait3";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter-500").GetUpgrade(TOP, 5).icon;
        public override string Description => "Increased range, pierce, damage and attack speed";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectileModel = attackModel.GetDescendant<ProjectileModel>();
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 20").GetAttackModel().weapons[0].projectile.Duplicate();
            towerModel.range += 20;
            attackModel.range += 20;
            //projectileModel.pierce += 6;
            //projectileModel.GetDamageModel().damage += 40;
            towerModel.GetWeapon().rate *= 0.1f;
        }
    }
    public class FlareonDisplay:ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            if (Main.Use2DDisplay)
            {
                Set2DTexture(node, "Flamara");
                node.transform.GetChild(0).transform.localScale = 0.2f * Vector3.one;
            }
            else
            {
                NodeLoader.NodeLoader.LoadNode(node, "Flareon", mod);
            }
        }
    }
}
