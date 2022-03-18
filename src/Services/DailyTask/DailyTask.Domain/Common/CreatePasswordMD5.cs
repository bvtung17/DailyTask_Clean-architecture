namespace DailyTask.Domain.Common
{
    public class CreatePasswordMD5
    {
        private static string key = "MATMAOTP";
        public static string GenerateHash(string value)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(key + value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
