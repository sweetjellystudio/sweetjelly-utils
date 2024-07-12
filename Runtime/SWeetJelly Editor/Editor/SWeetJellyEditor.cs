using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace SWeetJelly
{
    public abstract class SWeetJellyEditor : Editor
    {
        private static SWeetJellyEditor sweetJellyEditor;

        private bool isStyleInited;
        protected bool IsStyleInited
        {
            get { return isStyleInited; }
        }

        protected virtual void OnEnable()
        {
            sweetJellyEditor = this;

            EditorApplication.playModeStateChanged += LogPlayModeState;
            EditorSceneManager.activeSceneChangedInEditMode += ActiveSceneChanged;
        }

        protected void InitStyles()
        {
            if (isStyleInited)
                return;

            Styles();

            isStyleInited = true;
        }

        protected void ForceInitStyles()
        {
            isStyleInited = false;
        }

        protected virtual void Styles()
        {

        }

        private void ActiveSceneChanged(Scene scene1, Scene scene2)
        {
            ForceInitStyles();
        }

        private static void LogPlayModeState(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredEditMode)
            {
                if (sweetJellyEditor != null)
                {
                    sweetJellyEditor.ForceInitStyles();
                }
            }
        }
    }
}
