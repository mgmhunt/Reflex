using System;
using System.Collections.Generic;
using System.Linq;
using Reflex.Core;
using Reflex.Logging;
using UnityEngine;
using UnityEngine.Assertions;

namespace Reflex.Configuration
{
    internal sealed class ReflexSettings : ScriptableObject
    {
        private static ReflexSettings _instance;
        
        public static ReflexSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.LoadAll<ReflexSettings>("ReflexSettings").FirstOrDefault();
                }
                
                Assert.IsNotNull(_instance, "ReflexSettings not found in Resources folder.\n" +
                                            "Please create ReflexSettings using right mouse button over Resources folder, Create > Reflex > Settings.");
                return _instance;
            }
        }
        
        [field: SerializeField] public LogLevel LogLevel { get; private set; }
        [field: SerializeField] public List<ProjectScope> ProjectScopes { get; private set; }

        private void OnValidate()
        {
            _instance = this;
            ReflexLogger.UpdateLogLevel(LogLevel);
        }
    }
}
