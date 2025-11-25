using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Codeworkhub.Helpers
{
    public static class EasterEggHelper
    {
        private static readonly string FilePath = "wwwroot/data/easter_eggs.txt";

        public static (bool found, string message) ProcessEasterEgg(string inputCode)
        {
            if (!File.Exists(FilePath))
                return (false, "Easter egg system not initialized 💀");

            var lines = File.ReadAllLines(FilePath).ToList();
            var updated = false;

            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split('|').Select(p => p.Trim()).ToArray();
                if (parts.Length != 3) continue;

                string key = parts[0];
                string voucher = parts[1];
                string status = parts[2];

                if (key.Equals(inputCode, StringComparison.OrdinalIgnoreCase))
                {
                    if (status == "used")
                        return (true, "⚠️ This voucher has already been redeemed by someone else.");

                    // Mark redeemed
                    lines[i] = $"{key}|{voucher}|used";
                    File.WriteAllLines(FilePath, lines);
                    updated = true;

                    return (true, $"🎉 Congratulations! You discovered a hidden Easter Egg!\n" +
                                  $"📱 Airtime Voucher Code: **{voucher}**\n" +
                                  $"💡 Works on **all networks in South Africa**.\n" +
                                  $"⏳ Redeem via Airtime recharge menu.");
                }
            }

            return (false, "❌ Invalid code. Keep exploring for hidden Easter Eggs 👀");
        }
    }
}
