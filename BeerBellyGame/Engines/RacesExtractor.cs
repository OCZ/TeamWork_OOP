namespace BeerBellyGame.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using Attributes;
    using GameObjects.Interfaces;

    public class RacesExtractor
    {
        private static volatile RacesExtractor _instance;
        private static object _syncRoot = new Object();
        private IList<IRace> _playerRaces;
        private IList<IRace> _friendRaces;
        private IList<IRace> _enemyRaces;
        
        private RacesExtractor()
        {
           this.GetRaces();
        }
        

        public static RacesExtractor Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new RacesExtractor();
                        }
                    }
                }
                
                return _instance;
            }
        }


        public IList<IRace> PlayerRaces
        {
            get { return this._playerRaces; } 
        }

        public IList<IRace> FriendRaces
        {
            get { return this._friendRaces; }
        }

        public IList<IRace> EnemyRaces
        {
            get { return this._enemyRaces; }
        }

       

       
        private void GetRaces()
        {
            var classes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(EnemyRaceAttribute) ||
                                                        a.AttributeType == typeof(FriendRaceAttribute)||
                                                        a.AttributeType == typeof(PlayerRaceAttribute)))
                .ToList();
            if (classes.Count == 0)
            {
                throw new Exception("No attributes are appliyed");
            }
            this._enemyRaces =
                classes.Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof (EnemyRaceAttribute)))
                    .Select(raceClass => Activator.CreateInstance(raceClass) as IRace)
                    .ToList();
            if (_enemyRaces.Count == 0)
            {
                throw new Exception("No EnemyAttributes is appliyed");
            }
             this._friendRaces =
                classes.Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof (FriendRaceAttribute)))
                    .Select(raceClass => Activator.CreateInstance(raceClass) as IRace)
                    .ToList();
             if (_friendRaces.Count == 0)
             {
                 throw new Exception("No FriendAttributes is appliyed");
             }
            this._playerRaces = classes.Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof (PlayerRaceAttribute)))
                    .Select(raceClass => Activator.CreateInstance(raceClass) as IRace)
                    .ToList();
            if (_playerRaces.Count == 0)
            {
                throw new Exception("No FriendAttributes is appliyed");
            }
            
        }

        
    }
}
