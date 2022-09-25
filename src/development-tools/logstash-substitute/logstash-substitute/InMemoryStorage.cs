namespace logstash_substitute
{
    public static class InMemoryStorage
    {
        private static readonly List<string> receivedInfo;

        static InMemoryStorage()
        {
            receivedInfo = new List<string>();
        }

        public static void AddInfo(string info)
        {
            receivedInfo.Add($"{info} Received at: {DateTime.UtcNow}");
        }

        public static IEnumerable<string> GetInfo()
        {
            return receivedInfo.AsReadOnly().Reverse();
        }
    }
}
