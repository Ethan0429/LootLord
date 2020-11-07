using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using HarmonyLib;

namespace LootLord
{
    [HarmonyPatch(typeof(PartyScreenLogic), "ExecuteTroop")]
    public class PartyScreenLogic_LootLord
    {
        public static void Postfix(PartyScreenLogic.PartyCommand command)
        {
            CharacterObject character = command.Character;
            Hero hero = character.HeroObject;
            PartyBase mainParty = PartyBase.MainParty;

            for (int i = 0; i < 12; ++i)
            {
                if (hero.BattleEquipment[i].IsEmpty) { continue; }
                if (hero.BattleEquipment[i].Item.ItemCategory.IsAnimal) { continue; }
                mainParty.ItemRoster.AddToCounts(hero.BattleEquipment[i].Item, 1, true);
                InformationManager.DisplayMessage(new InformationMessage(string.Concat(new object[]
                {
                    hero.BattleEquipment[i].Item.ToString(),
                    " Added"
                })));
            }
        }
    }
}