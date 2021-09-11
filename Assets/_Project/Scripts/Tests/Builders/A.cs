namespace Project.Tests.Builders
{
    public static class A
    {
        public static CharacterBuilder Character => new CharacterBuilder();
        public static PlayerBuilder Player => new PlayerBuilder();
        public static CollectibleBuilder Collectible => new CollectibleBuilder();
    }
}