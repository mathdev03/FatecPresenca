using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
 * Fingers Numbers
 * 
 * RIGHT
 * 1 = Thumb
 * 2 = Index
 * 3 = Middle
 * 4 = Ring
 * 5 = Little
 * 
 * LEFT
 * 6 = Thumb
 * 7 = Index
 * 8 = Middle
 * 9 = Ring
 * 10 = Little
 */

namespace FatecPresenca.Presenca
{
    internal class NIFQ2
    {

        private const string dllName = @"..\..\..\..\Presenca\Digital\NFIQ2\bin\Nfiq2Api.dll";

        public static void nfiq2Init(IntPtr hash)
        {
            try
            {
                IntPtr init = InitNfiq2(ref hash);

                if (init != IntPtr.Zero) Console.WriteLine("NFIQ2 Ligado!");

            }
            catch (Exception e) { 
                Console.WriteLine($"Erro ao iniciar o NFIQ2 - Erro: {e.Message}");
            }
        }

        public static int ComputeScoreNfiq2(byte[] buffer, int largura, int altura, int resolution, int fpos)
        {
            int result = 0;

            try
            {
                result = ComputeNfiq2Score(fpos, buffer, buffer.Length, largura, altura, resolution);
            }
            catch (Exception e) {
                Console.WriteLine($"Falha ao calcular NFIQ2 {e.Message}");
            }

            return result;
        }

        //Inicializar o NFIQ2
        [DllImport(dllName, EntryPoint = "InitNfiq2", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr InitNfiq2(ref IntPtr pCStrHash);

        // Pegar o score da qualidade do dedo!
        [DllImport(dllName, EntryPoint = "ComputeNfiq2Score", CallingConvention = CallingConvention.StdCall)]
        private static extern int ComputeNfiq2Score(int fpos, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pixels,
            int size, int width, int height, int ppi);


        // Pegar a versão do NFIQ2
        [DllImport(dllName, EntryPoint = "GetNfiq2Version", CallingConvention = CallingConvention.StdCall)]
        public static extern void GetNfiq2Version(out int major, out int minor, out int patch, out IntPtr pOCV_Version_CStr);
    }
}
