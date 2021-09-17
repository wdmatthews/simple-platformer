namespace Project.Tests.Builders
{
    public static class A
    {
        public static CharacterBuilder Character => new CharacterBuilder();
        public static PlayerBuilder Player => new PlayerBuilder();
        public static CollectibleBuilder Collectible => new CollectibleBuilder();
        public static DoorBuilder Door => new DoorBuilder();
        public static SpikeBuilder Spike => new SpikeBuilder();
        public static LiquidBuilder Liquid => new LiquidBuilder();
        public static SawBuilder Saw => new SawBuilder();
        public static ButtonBuilder Button => new ButtonBuilder();
        public static ToggleBlockBuilder ToggleBlock => new ToggleBlockBuilder();
        public static ToggleBlockGroupBuilder ToggleBlockGroup => new ToggleBlockGroupBuilder();
        public static PortalBuilder Portal => new PortalBuilder();
        public static HealthTrackerBuilder HealthTracker => new HealthTrackerBuilder();
        public static HealthTrackerHeartBuilder HealthTrackerHeart => new HealthTrackerHeartBuilder();
        public static CollectibleTrackerBuilder CollectibleTracker => new CollectibleTrackerBuilder();
        public static SaveManagerSOBuilder SaveManagerSO => new SaveManagerSOBuilder();
    }
}
