using System.Collections.Generic;
using SoulsFormats;

namespace StraySouls.Wrapper
{
    public class EnemyWrapper : ISFWrapper
    {
        public string Name
        {
            get
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        return _ds3Enemy.Name;
                    case Game.Sekiro:
                        return _sekiroEnemy.Name;
                    default:
                        return string.Empty;
                }
            }
            set
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        _ds3Enemy.Name = value;
                        break;
                    case Game.Sekiro:
                        _sekiroEnemy.Name = value;
                        break;
                }
            }
        }

        public string ModelName
        {
            get
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        return _ds3Enemy.ModelName;
                    case Game.Sekiro:
                        return _sekiroEnemy.ModelName;
                    default:
                        return string.Empty;
                }
            }
            set
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        _ds3Enemy.ModelName = value;
                        break;
                    case Game.Sekiro:
                        _sekiroEnemy.ModelName = value;
                        break;
                }
            }
        }

        public int NPCParamID
        {
            get
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        return _ds3Enemy.NPCParamID;
                    case Game.Sekiro:
                        return _sekiroEnemy.NPCParamID;
                    default:
                        return -1;
                }
            }
            set
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        _ds3Enemy.NPCParamID = value;
                        break;
                    case Game.Sekiro:
                        _sekiroEnemy.NPCParamID = value;
                        break;
                }
            }
        }

        public int ThinkParamID
        {
            get
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        return _ds3Enemy.ThinkParamID;
                    case Game.Sekiro:
                        return _sekiroEnemy.ThinkParamID;
                    default:
                        return -1;
                }
            }
            set
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        _ds3Enemy.ThinkParamID = value;
                        break;
                    case Game.Sekiro:
                        _sekiroEnemy.ThinkParamID = value;
                        break;
                }
            }
        }

        /// <summary>
        /// DS3 only
        /// </summary>
        public int EventEntityID
        {
            get
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        return _ds3Enemy.EventEntityID;
                    default:
                        return -1;
                }
            }
            set
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        _ds3Enemy.EventEntityID = value;
                        break;
                }
            }
        }

        public int CharaInitID
        {
            get
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        return _ds3Enemy.CharaInitID;
                    case Game.Sekiro:
                        return _sekiroEnemy.CharaInitID;
                    default:
                        return -1;
                }
            }
            set
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        _ds3Enemy.CharaInitID = value;
                        break;
                    case Game.Sekiro:
                        _sekiroEnemy.CharaInitID = value;
                        break;
                }
            }
        }

        /// <summary>
        /// DS3 only
        /// </summary>
        public int TalkID
        {
            get
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        return _ds3Enemy.TalkID;
                    default:
                        return -1;
                }
            }
            set
            {
                switch (TargetGame.Game)
                {
                    case Game.DS3:
                        _ds3Enemy.TalkID = value;
                        break;
                }
            }
        }

        /// <summary>
        /// Sekiro only
        /// </summary>
        public int EventFlagID
        {
            get
            {
                switch (TargetGame.Game)
                {
                    case Game.Sekiro:
                        return _sekiroEnemy.EventFlagID;
                    default:
                        return -1;
                }
            }
            set
            {
                switch (TargetGame.Game)
                {
                    case Game.Sekiro:
                        _sekiroEnemy.EventFlagID = value;
                        break;
                }
            }
        }

        /// <summary>
        /// Sekiro only
        /// </summary>
        public int EntityID
        {
            get
            {
                switch (TargetGame.Game)
                {
                    case Game.Sekiro:
                        return _sekiroEnemy.EntityID;
                    default:
                        return -1;
                }
            }
            set
            {
                switch (TargetGame.Game)
                {
                    case Game.Sekiro:
                        _sekiroEnemy.EntityID = value;
                        break;
                }
            }
        }

        private MSB3.Part.Enemy _ds3Enemy = null;

        private MSBS.Part.Enemy _sekiroEnemy = null;

        public EnemyWrapper(EnemyWrapper clone)
        {
            if (clone._ds3Enemy != null)
                _ds3Enemy = new MSB3.Part.Enemy(clone._ds3Enemy);
            else if (clone._sekiroEnemy != null)
                _sekiroEnemy = new MSBS.Part.Enemy(clone._sekiroEnemy);
        }

        public EnemyWrapper(MSB3.Part.Enemy enemy)
        {
            _ds3Enemy = enemy;
        }

        public EnemyWrapper(MSBS.Part.Enemy enemy)
        {
            _sekiroEnemy = enemy;
        }

        public static IEnumerable<EnemyWrapper> Read(List<MSB3.Part.Enemy> ds3Enemies)
        {
            for (int i = 0; i < ds3Enemies.Count; i++)
                yield return new EnemyWrapper(ds3Enemies[i]);
        }

        public static IEnumerable<EnemyWrapper> Read(List<MSBS.Part.Enemy> sekiroEnemy)
        {
            for (int i = 0; i < sekiroEnemy.Count; i++)
                yield return new EnemyWrapper(sekiroEnemy[i]);
        }

        public static void Overwrite(List<EnemyWrapper> wrappers, List<MSB3.Part.Enemy> ds3Enemies)
        {
            if (ds3Enemies.Count > wrappers.Count)
                ds3Enemies.RemoveRange(wrappers.Count, ds3Enemies.Count - wrappers.Count);

            int i = 0;
            for (; i < ds3Enemies.Count; i++)
                ds3Enemies[i] = wrappers[i]._ds3Enemy;
            for (; i < wrappers.Count; i++)
                ds3Enemies.Add(wrappers[i]._ds3Enemy);
        }

        public static void Overwrite(List<EnemyWrapper> wrappers, List<MSBS.Part.Enemy> sekiroEnemies)
        {
            if (sekiroEnemies.Count > wrappers.Count)
                sekiroEnemies.RemoveRange(wrappers.Count, sekiroEnemies.Count - wrappers.Count);

            int i = 0;
            for (; i < sekiroEnemies.Count; i++)
                sekiroEnemies[i] = wrappers[i]._sekiroEnemy;
            for (; i < wrappers.Count; i++)
                sekiroEnemies.Add(wrappers[i]._sekiroEnemy);
        }
    }
}
