using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using ThreeBytes.Core.Security.Encryption.Abstract;

namespace ThreeBytes.Core.Security.Encryption.Concrete
{
    public class PasswordEncoder : IPasswordEncoder
    {
        private MachineKeySection machineKey;

        public PasswordEncoder()
        {
            Configuration cfg = WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            machineKey = (MachineKeySection)cfg.GetSection("system.web/machineKey");
        }

        public string EncodePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            HMACSHA1 hash = new HMACSHA1();
            hash.Key = HexToByte(machineKey.ValidationKey);
            return Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
        }

        private byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
    }
}
