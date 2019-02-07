using System;
using System.Collections.Generic;

using Enemy = SoulsFormats.MSB3.Part.Enemy;
using EnemyRandomCommand = StraySouls.CommandInput.EnemyRandomCommand;

namespace StraySouls
{
    public static class EnemyRandomArgs
    {
        public abstract class RandomListBase : ICommandArg<EnemyRandomCommand>
        {
            protected abstract char _argChar { get; }

            protected abstract IEnumerable<string> _skipIDs { get; }

            public bool TryEnable(char charArg)
            {
                return charArg == _argChar;
            }

            /// <param name="enabled">If this argument is enabled or not</param>
            public void GetCommandArg(EnemyRandomCommand command, bool enabled)
            {
                if (Program.VOLATILE_ENABLED)
                {
                    if (enabled)
                        command.Randomizer.AddAdditionIDs(_skipIDs);
                }
                else
                {
                    command.Randomizer.AddSkipIDs(_skipIDs, enabled);
                }
            }
        }

        public class RandomMainBoss : RandomListBase
        {
            private static readonly string[] ID_MAIN_BOSS = new string[]
            {
            "c5110_0000", //Ludex Gundyr
            "c2240_0000", //Vordt of the Boreal Valley
          //"c1320_0000", //Crystal Sage
            "c1320_", //Crystal Sage (Clones)
            "c5220_0000", //Deacons of the Deep ()
            "c5221_", //Deacons of the Deep (Stout)
            "c5222_", //Deacons of the Deep (Tall)
            "c5223_", //Deacons of the Deep (Short)
            "c5225_", //Deacons of the Deep (Blue)
            "c3040_", //Abyss Wathcers
          //"c3040_0000", //Abyss Wathcers (Both P1 and P2)
          //"c3040_0001", //Abyss Wathcers (P1, normal)
          //"c3040_0002", //Abyss Wathcers (P1, red eyes)
            "c5160_0000", //High Lord Wolnir
            "c5140_", //Pontiff Sulyvahn
          //"c5140_0000", //Pontiff Sulyvahn
          //"c5140_0001", //Pontiff Sulyvahn (Phantom)
            "c5150_0001", //Aldrich, Devourer of Gods
            "c5260_0000", //Yhorm the Giant
            "c5270_0001", //Dancer of the Boreal Valley
            "c3160_0000", //Dragonslayer Armour
            "c5250_0001", //Lorian, Elder Prince (P1)
            "c5250_0000", //Lorian, Elder Prince (P2)
            "c5280_0000", //Soul of Cinder
            "c6020_0002", //Sister Friede (Meet)
            "c6010_0001", //Father Ariandel (Meet)
            "c6020_0001", //Sister Friede (P1)
            "c6010_0000", //Sister Friede and Father Ariandel (P2)
            "c6020_0000", //Blackflame Friede (P3)
            "c5020_0001", //Demon from Below
            "c5020_0002", //Demon in Pain
            "c6280_0000", //Judicator Argo
            "c0000_0010", //Halflight, Spear of the Church
            "c6200_0000", //Slave Knight Gael (P1)
            "c6300_0003", //Slave Knight Gael (P2)
            };

            protected override char _argChar => 'm';

            protected override IEnumerable<string> _skipIDs => ID_MAIN_BOSS;
        }

        public class RandomOptionalBoss : RandomListBase
        {
            private static readonly string[] ID_OPTIONAL_BOSS = new string[]
            {
            "c5180_0000", //Curse-rotted Greatwood*
            "c3050_0000", //Old Demon King
            "c2090_0000", //Oceiros, the Consumed King
            "c5110_0001", //Champion Gundyr*
            "c3141_0000", //Ancient Wyvern
            "c5030_0000", //The Nameless King (P1)
            "c5010_0000", //The Nameless King (P2)
            "c0000_0009", //Champion's Gravetender
            "c6030_0001", //Gravetender Greatwolf (First)
            "c6030_0001", //Gravetender Greatwolf (Second)
            "c6030_0004", //Gravetender Greatwolf (Boss)
            "c6210_0000", //Darkeater Midir (Firtst, hides behind a tower)
          //"c6210_0000", //Darkeater Midir (Second, breathes fire toward the bridge)
          //"c6210_0000", //Darkeater Midir (Third, located on a cliff)
            "c6211_0000", //Darkeater Midir (Boss)

            //Mini Boss (Key event)
            "c3060_0001" //Fire Demon
            };

            protected override char _argChar => 'o';

            protected override IEnumerable<string> _skipIDs => ID_OPTIONAL_BOSS;
        }

        public class RandomAggressiveNPC : RandomListBase
        {
            private static readonly string[] ID_AGGRESSIVE_NPC = new string[]
            {
          //"c", //Alva, Seeker of the Spurned
          //"c", //Black Hand Kamui
          //"c0000_0015", //Brigand
          //"c", //Court Sorcerer
          //"c", //Creighton the Wanderer
          //"c0000_0015", //Daughter of Crystal Kriemhild
          //"c", //Desert Pyromancer Zoey
          //"c", //Dragonblood Knight
          //"c", //Drang Knight
          //"c0000_0016", //Fallen Knight
          //"c", //Havel the Rock
          //"c0000_0015", //Isabella the Mad
          //"c", //Knight Slayer Tsorig
          //"c", //Livid Pyromancer Dunnel
          //"c", //Longfinger Kirk
          //"c", //Moaning Knight
          //"c", //Rapier Champion
          //"c", //Silver Knight Ledo
            "c0000_0011", //Sir Vilhelm (Meet)
            "c0000_0012", //Sir Vilhelm (Combat)

            //Other enemies
            "c1380_0009", //Man Serpent Summoner(Drakeblood Knights)
            "c1380_0001", //Man Serpent Summoner(Rapier Champion)
          //"c6250_0002", //Angle 1
          //"c6250_0000", //Angle 2
          //"c6250_0001", //Angle 3
            "c1290_0000", //Gertrude's Knights 1
            "c1290_0001", //Gertrude's Knights 2
            "c1290_0002", //Gertrude's Knights 3
            "c3141_0000", //Pus of Man (Twin wyvern, white)
            "c3141_0001", //Pus of Man (Twin wyvern, brown)
            "c3080_0004", //Pilgrim Butterfly 1
            "c3080_0000", //Pilgrim Butterfly 2
            "c2140_0001", //Basilisk 1 ()
            "c2140_0002", //Basilisk 2
            "c2140_0003", //Basilisk 3
            "c2140_0004", //Basilisk 4
            "c2140_0005", //Basilisk 5
            };

            protected override char _argChar => 'a';

            protected override IEnumerable<string> _skipIDs => ID_AGGRESSIVE_NPC;
        }

        public class RandomFriendlyNPC : RandomListBase
        {
            private static readonly string[] ID_FRIENDLY_NPC = new string[]
            {
            //(Some of them might be aggressive at some cases)
            "c1400_0000", //Fire Keeper
            "c0000_0026", //Anri of Astora (Road of Sacrifice)
            "c0000_0007", //Anri of Astora (Firelink Shrine, after defeating Deacons of Deep)
            "c0000_0020", //Anri of Astora (Catacombs of Carthus, First)
            "c0000_0021", //Anri of Astora (Catacombs of Carthus, Second)
            "c3190_0000", //Blacksmith Andre
            "c2170_0000", //Company Captain Yorshka
            "c0000_0013", //Cornyx of the Great Swanp (Undead Settlement)
            "c0000_0018", //Cornyx of the Great Swanp (Firelink Shrine)
            "c3250_0000", //Emma, High Priestess of Lothric Castle
            "c0000_0014", //Eygon of Carim
            "c0000_0004", //Eygon of Carim (Irina death?)
          //"Can't find", //Filianore
          //"c", //Forlorn Corvian Settler (Slab holder)
            "c0000_0020", //Greirat of the Undead Settlement (High Wall of Lothric)
          //"c0000_0020", //Greirat of the Undead Settlement (Firelink Shrine)
            "c0000_0033", //Hawkwood the Deserter
            "c0000_0022", //Hawkwood the Deserter (Farron Keep)
            "c0000_0023", //Horace the Hushed (Road of Sacrifice)
            "c0000_0010", //Horace the Hushed (Firelink Shrine, after defeating Deacons of Deep)
            "c0000_0025", //Horace the Hushed (Smouldering Lake)
            "c0000_0002", //Holy Knight Hodrick
            "c0000_0033", //Holy Knight Hodrick (Road of Sacrifice)
            "c0000_0021", //Irina of Carim
            "c0000_0011", //Karla (Irithyll Dungeon)
            "c0000_0022", //Karla (Firelink Shrine)
            "c0000_0007", //Lion Knight Albert
          //"c", //Londor Pale Shade
            "c1450_0000", //Ludleth of Courland
          //"c", //Old Woman of Londor
            "c0000_0017", //Orbeck of Vinheim (Road of Sacrifice)
            "c0000_0024", //Orbeck of Vinheim (Firelink Shrine)
          //"c", //Ringfinger Leonhard
            "c5210_0000", //Rosaria, Mother of Rebirth
            "c0000_0005", //Shira, Knight of Filianore
            "c3200_", //Shrine Handmaid
          //"c3200_0000", //Shrine Handmaid
          //"c3200_0000", //Shrine Handmaid (Past)
            "c0000_0007", //Siegward of Catarina (Meets at elevator)
            "c0000_0015", //Siegward of Catarina (Helps defeating the fire demon)
            "c0000_0016", //Siegward of Catarina (Yhorm)
            "c0000_0006", //Sirris of the Sunless Realms (Firelink Shrine, first)
            "c0000_0019", //Sirris of the Sunless Realms (Cathedral of Deep)
            "c0000_0021", //Slave Knight Gael (Cathedral of Deep)
            "c0000_0012", //Sword Master
            "c0000_0008", //Sword Master (Phantom, Vordt)
            "c0000_0013", //Sword Master (Phantom, Gundyr)
            "c6121_0000", //The Painter
          //"c0000_0013", //Unbreakable Patches
            "c0000_0032", //Unbreakable Patches
          //"c", //Yellowfinger Heysel
            "c2160_0000", //Yoel of Londor
            "c0000_0025", //Yuria of Londor
            };

            protected override char _argChar => 'f';

            protected override IEnumerable<string> _skipIDs => ID_FRIENDLY_NPC;
        }

        public class MultiplyEnemies : ICommandArg<EnemyRandomCommand>
        {
            public const int MULTIPLY_MINIMUM = 2;
            public const int MULTIPLY_MAXIMUM = 9;

            private int _multiplyTimes = MULTIPLY_MINIMUM;

            public bool TryEnable(char argChar)
            {
                return int.TryParse(argChar.ToString(), out _multiplyTimes)
                    && _multiplyTimes >= MULTIPLY_MINIMUM && _multiplyTimes <= MULTIPLY_MAXIMUM;
            }

            public void GetCommandArg(EnemyRandomCommand command, bool enabled)
            {
                if (!enabled)
                    return;

                command.Randomizer.OnRandomizeEnd += Multiply;
            }

            private void Multiply(Enemy[] availableEnemies, EnemyRandomProperties[] matchingProperties, List<Enemy> msbEntries)
            {
                Random random = new Random();
                for (int i = _multiplyTimes; i > 1; i--)
                    for (int j = 0; j < availableEnemies.Length; j++)
                    {
                        Enemy origin = availableEnemies[i];
                        Enemy clone = new Enemy(origin) { Name = $"{origin.Name}_c{i}" };
                        matchingProperties[random.Next(0, availableEnemies.Length)].ApplyToEntry(clone);
                        msbEntries.Add(clone);
                    }
            }
        }

        public class UnlimitedMode : ICommandArg<EnemyRandomCommand>
        {
            public void GetCommandArg(EnemyRandomCommand command, bool enabled)
            {
                command.Randomizer.BeforeApply += IndividualRandom;
            }

            private void IndividualRandom(Enemy[] availableEntries, EnemyRandomProperties[] matchingProperties, List<Enemy> msbEnemies)
            {
                Enemy[] temp = new Enemy[matchingProperties.Length];
                matchingProperties.CopyTo(temp, 0);
                Random random = new Random();

                for (int i = 0; i < temp.Length; i++)
                    availableEntries[i] = temp[random.Next(0, temp.Length)];
            }

            public bool TryEnable(char argChar) => argChar == 'u';
        }
    }
}
