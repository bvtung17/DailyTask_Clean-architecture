// <copyright file="CreatePasswordMD5.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Application.Common
{
    /// <summary>
    /// Create password MD5.
    /// </summary>
    public static class CreatePasswordMD5
    {
        private static string key = "MATMAOTP";

        /// <summary>
        /// The GenerateHash.
        /// </summary>
        /// <param name="value">vale.</param>
        /// <returns>string value.</returns>
        public static string GenerateHash(string value)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(key + value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
