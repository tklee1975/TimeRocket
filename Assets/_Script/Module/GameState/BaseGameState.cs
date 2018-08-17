using UnityEngine;
using System.Collections;

namespace Kencoder
{

    public abstract class BaseGameState : MonoBehaviour
    {
        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnUpdate();

        public override string ToString()
        {
            return this.GetType().ToString();
        }

        public virtual System.Type GetGameState()
        {

            return this.GetType();
        }
    }
}