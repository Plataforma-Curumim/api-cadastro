using System.Security.Cryptography;
using System.Text;

namespace api_cadastro.Adapters.Outbound.DB.Postgres.Connection
{
    public class CriptoArandu
    {

        public string chave = "Ar@ndu2023"; // mudar

        public string decryptDES(string sDados, string sChave)
        {

            var DESProvider = DES.Create();

            DESProvider.Mode = CipherMode.ECB;
            DESProvider.Key = Encoding.UTF8.GetBytes(sChave);
            DESProvider.Padding = PaddingMode.PKCS7;

            ICryptoTransform DESEncrypt = DESProvider.CreateDecryptor();
            byte[] Buffer = Convert.FromBase64String(sDados);

            return Encoding.UTF8.GetString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
    }
}
