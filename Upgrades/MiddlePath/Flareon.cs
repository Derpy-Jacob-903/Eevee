using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using BTD_Mod_Helper.Api.Display;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace Eevee.Upgrades.MiddlePath
{
    public class Flareon : ModUpgrade<Eevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 2500;
        public override string Portrait => "FlareonPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("WizardMonkey-010").GetUpgrade(MIDDLE, 1).icon;
        public override string Description => "Evolving Eevee to Flareon and increases the attack speed and pierce";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel(); 
            var projectileModel = attackModel.GetDescendant<ProjectileModel>();
            projectileModel.pierce += 2;
            //attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 15").GetAttackModel().weapons[0].projectile.Duplicate();
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();
            towerModel.GetWeapon().rate *= 0.5f;
            attackModel.weapons[0].projectile.SetHitCamo(true);
            towerModel.ApplyDisplay<FlareonDisplay>();
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
                foreach (SkinnedMeshRenderer s in node.GetComponentsInChildren<SkinnedMeshRenderer>())
                {
                    s.SetOutlineColor(new Color(42.4f, 21.2f, 0.4f));
                }
            }
        }
    }
}
