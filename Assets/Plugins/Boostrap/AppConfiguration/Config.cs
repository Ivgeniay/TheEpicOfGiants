using UnityEngine;

namespace MainCore.Maintenance.Boostraper.AppConfiguration
{
    public class Config : ScriptableObject
    {
        [SerializeField] protected string version = "0.1"; 

        public virtual string Version { get => version; } 
    }
}
