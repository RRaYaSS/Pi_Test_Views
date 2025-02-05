using System.Security.Cryptography;
using System.Text;

namespace Pi_Projeto_Integrador.Utils
{
    //classe util, adicionar funções que podem ajudar no sistema, como máscaras, retornos de formatação de string, cáculos ou o que vocês quiserem aqui


    public class Util
    {

        public string Md5Encode(string text)
        {
            MD5 md5 = MD5.Create();
            byte[] textBytes = Encoding.ASCII.GetBytes(text);
            byte[] hash = md5.ComputeHash(textBytes);
            StringBuilder md5Gerado = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
                md5Gerado.Append(hash[i].ToString("X2"));

            return md5Gerado.ToString();
        }

    }
}
