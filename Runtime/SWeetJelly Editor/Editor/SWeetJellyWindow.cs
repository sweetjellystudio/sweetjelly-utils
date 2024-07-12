using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace SWeetJelly
{
    public abstract class SWeetJellyWindow : EditorWindow
    {
        private static SWeetJellyWindow sweetJellyEditor;

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

            InitStyles();
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
