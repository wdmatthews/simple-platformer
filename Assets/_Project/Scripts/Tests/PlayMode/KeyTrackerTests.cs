using NUnit.Framework;
using UnityEngine;
using Project.Tests.Builders;
using Project.Tests.UI;

namespace Project.Tests.PlayMode
{
    public class KeyTrackerTests
    {
        [Test]
        public void SetSprite_SetsSpriteFromSpriteRenderer()
        {
            TestKeyTracker tracker = A.KeyTracker;
            SpriteRenderer renderer = new GameObject().AddComponent<SpriteRenderer>();
            renderer.sprite = Sprite.Create(new Texture2D(1, 1), new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
            tracker.SetSprite(renderer);
            Assert.AreEqual(renderer.sprite, tracker.Image.sprite);
            Assert.AreNotEqual(null, tracker.Image.sprite);
        }
    }
}
