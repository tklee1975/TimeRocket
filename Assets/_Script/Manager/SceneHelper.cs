using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kencoder
{
	public class SceneHelper {
        public static void GotoMainScene() {
            SceneManager.LoadScene("GameScene");
        }

        public static void GotoCollectionScene() {
            SceneManager.LoadScene("CollectionScene");
        }
    }
}