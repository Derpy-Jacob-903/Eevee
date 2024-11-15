﻿using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;

namespace Eevee.Upgrades.TopPath
{
    public class Jolteon : ModUpgrade <Eevee>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 2800;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Evolving Eevee to Jolteon and increases the attack speed and range";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate *= 0.66f;
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;

            var myPierce = attackModel.weapons[0].projectile.pierce;
            var myMaxPierce = attackModel.weapons[0].projectile.maxPierce;

            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons[1].projectile.Duplicate();
            attackModel.weapons[0].projectile.SetHitCamo(true);

            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

            towerModel.ApplyDisplay<JolteonDisplay>();

            if (Main.JolteonRework)
            {
                var lightning = attackModel.weapons[0].projectile.GetBehavior<LightningModel>();
                attackModel.weapons[0].projectile.maxPierce = myMaxPierce;
                attackModel.weapons[0].projectile.pierce = myPierce + 12;
                lightning.splits = 1;
            }
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
                foreach (SkinnedMeshRenderer s in node.GetComponentsInChildren<SkinnedMeshRenderer>())
                {
                    s.SetOutlineColor(new Color(26.7f, 14.1f, 8.6f));
                }
            }
        }
    }
}
