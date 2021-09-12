using Project.Environment;

namespace Project.Tests.Environment
{
    public class TestSpike : Spike
    {
        public HazardSO Data { get => _data; set => _data = value; }
    }
}
