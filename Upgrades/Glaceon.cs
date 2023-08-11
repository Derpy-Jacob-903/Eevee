using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;

namespace Eevee.Upgrades.MiddlePath
{
    public class FasterEevee : ModUpgrade<Eevee>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 320;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("DartMonkey-010").GetUpgrade(MIDDLE, 1).icon;
        public override string Description => "Faster attack speed";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate *= 0.66f;
        }
    }
    public class MoreFasterEevee : ModUpgrade<Eevee>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 500;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("DartMonkey-020").GetUpgrade(MIDDLE, 2).icon;
        public override string Description => "Even more faster";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate *= 0.7f;
        }
    }
    public class Glaceon : ModUpgrade<Eevee>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 2500;
        public override string Portrait => "GlaceonPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("IceMonkey-004").GetUpgrade(BOTTOM, 3).icon;
        public override string Description => "Evolving Eevee to Glaceon and faster attack speed";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            attackModel.AddWeapon(Game.instance.model.GetTowerFromId("IceMonkey-003").GetAttackModel().weapons[0].Duplicate()); 
            //attackModel.weapons[0].projectile.display.GUID = "95b1830a03efa16429dd80f4ddb7ba9c";
            attackModel.weapons[0].projectile.display.guidRef = "95b1830a03efa16429dd80f4ddb7ba9c";
            //towerModel.GetWeapon().rate *= 0.8f;
            attackModel.weapons[0].projectile.SetHitCamo(true);
            towerModel.ApplyDisplay<GlaceonDisplay>();
        }
    }
    public class GlaceonDisplay:ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            if (Main.Use2DDisplay)
            {
                Set2DTexture(node, "Glatiola");
                node.transform.GetChild(0).transform.localScale = 0.2f * Vector3.one;
            }
            else
            {
                NodeLoader.NodeLoader.LoadNode(node, "Glaceon", mod);
            }
        }
    }
}
