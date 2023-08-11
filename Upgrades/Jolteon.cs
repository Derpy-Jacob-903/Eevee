using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;

namespace Eevee.Upgrades.TopPath
{
    public class SharpPins : ModUpgrade<Eevee>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 250;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("DartMonkey-100").GetUpgrade(TOP, 1).icon;
        public override string Description => "Can pop 1 extra Bloon per pin.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            projectileModel.pierce += 1;
        }
    }
    public class RazorSharpPins : ModUpgrade<Eevee>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 400;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("DartMonkey-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Can pop 2 more Bloons per pin.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            projectileModel.pierce += 2;
        }
    }
    public class Jolteon : ModUpgrade <Eevee>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 6000;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Replaces pins with powerful lasers that can pop 13 bloons each and also pops frozen bloons. Increased attack range.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            //towerModel.GetWeapon().rate *= 0.66f;
            towerModel.range += 18;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 18;
            attackModel.AddWeapon(Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons[1].Duplicate());
            //attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons[1].projectile.Duplicate();
            //attackModel.weapons[0].projectile.SetHitCamo(true);
            towerModel.ApplyDisplay<JolteonDisplay>();
        }
    }

    public class ElectroBall : ModUpgrade<Eevee>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 10000;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-400").GetUpgrade(TOP, 4).icon;
        public override string Description => "Jolteon hurls an electric orb at the target. ";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectileModel = attackModel.GetDescendant<ProjectileModel>();
            //attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
            attackModel.AddWeapon(Game.instance.model.GetTowerFromId("Druid-400").GetAttackModel().weapons[2].Duplicate());
        }
    }

    public class MasterOfElectricity : ModUpgrade<Eevee>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 35000;
        public override string Portrait => "BlitzaPortrait2";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("EngineerMonkey-050").GetUpgrade(MIDDLE, 5).icon;
        public override string Description => "More damage, pierce and range";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            var attackModel = towerModel.GetAttackModel();
            towerModel.range += 20;
            attackModel.range += 20;
            attackModel.weapons[0].projectile.GetDamageModel().damage += 4;
            attackModel.weapons[1].projectile.GetDamageModel().damage += 4;
            attackModel.weapons[2].projectile.GetDamageModel().damage += 4;
            projectileModel.pierce += 8;
        }
    }
    public class JolteonDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            if (Main.Use2DDisplay)
            {
                Set2DTexture(node, "Blitza");
                node.transform.GetChild(0).transform.localScale = 0.2f * Vector3.one;
            }
            else
            {
                NodeLoader.NodeLoader.LoadNode(node, "Jolteon", mod);
            }
        }
    }
}
