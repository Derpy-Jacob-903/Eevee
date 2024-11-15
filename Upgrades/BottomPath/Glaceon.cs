﻿using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace Eevee.Upgrades.MiddlePath
{
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
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("IceMonkey-003").GetAttackModel().weapons[0].projectile.Duplicate();
            towerModel.GetWeapon().rate *= 0.8f;
            attackModel.weapons[0].projectile.SetHitCamo(true);
            //attackModel.weapons[0].projectile.RemoveFilter(attackModel.weapons[0].projectile.filters[1]);
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
                foreach (SkinnedMeshRenderer s in node.GetComponentsInChildren<SkinnedMeshRenderer>())
                {
                    s.SetOutlineColor(new Color(48.2f, 84.7f, 1f));
                }
            }
        }
    }
}
