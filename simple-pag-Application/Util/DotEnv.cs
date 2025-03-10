namespace simple_pag.Util
{
    public static class DotEnv
    {
        public static void Load(string filepath)
        {
            if (!File.Exists(filepath))
            {
                return;
            }

            foreach (var line in File.ReadAllLines(filepath))
            {
                var parts = line.Split('=', 2);

                if (parts.Length != 2)
                {
                    continue;
                }
                if (Environment.GetEnvironmentVariable(parts[0]) == null)
                {
                    Environment.SetEnvironmentVariable(parts[0], parts[1]);
                }
            }
        }
    }
}
