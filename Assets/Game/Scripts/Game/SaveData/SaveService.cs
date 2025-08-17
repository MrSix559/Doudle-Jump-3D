namespace SaveData
{
    public static class SaveService
    {
        public static int LoadFps() =>
            EncryptedPlayerPrefs.GetEncryptedInt("Fps", 60);

        public static bool LoadFpsShow() =>
            EncryptedPlayerPrefs.GetEncryptedInt("FpsShow", 0) == 1;

        public static bool LoadMusic() =>
            EncryptedPlayerPrefs.GetEncryptedInt("Music", 1) == 1;

        public static bool LoadSound() =>
            EncryptedPlayerPrefs.GetEncryptedInt("Sound", 1) == 1;
    }
}