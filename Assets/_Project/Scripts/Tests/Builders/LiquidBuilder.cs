using UnityEngine;
using Project.Environment;

namespace Project.Tests.Builders
{
    public class LiquidBuilder
    {
        public Liquid Build()
        {
            GameObject gameObject = new GameObject();
            Liquid liquid = gameObject.AddComponent<Liquid>();
            return liquid;
        }

        public static implicit operator Liquid(LiquidBuilder builder) => builder.Build();
    }
}
