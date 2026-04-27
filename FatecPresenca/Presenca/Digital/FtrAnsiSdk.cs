using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenca
{
    public class FtrAnsiSdk
    {
        private const string dllName = @"..\..\..\..\Presenca\Digital\ftrAnsiSdk.dll";

        // ==================== TIPOS DE IMPRESSÃO ====================

        public const byte IMPRESSION_TYPE_LIVE_SCAN_PLAIN = 0x00;
        public const byte IMPRESSION_TYPE_NONLIVE_SCAN_PLAIN = 0x02;

        // ==================== CÓDIGOS DE POSIÇÃO DE DEDOS ====================

        public const byte FINGER_POSITION_UNKNOWN = 0x00; // Posição de dedo desconhecida/indefinida.
        public const byte FINGER_POSITION_RIGHT_THUMB = 0x01; // Polegar direito.
        public const byte FINGER_POSITION_RIGHT_INDEX = 0x02; // Dedo indicador direito.
        public const byte FINGER_POSITION_RIGHT_MIDDLE = 0x03; // Dedo médio direito.
        public const byte FINGER_POSITION_RIGHT_RING = 0x04; // Dedo anelar direito.
        public const byte FINGER_POSITION_RIGHT_LITTLE = 0x05; // Dedo mínimo (pequeno) direito.
        public const byte FINGER_POSITION_LEFT_THUMB = 0x06; // Polegar esquerdo
        public const byte FINGER_POSITION_LEFT_INDEX = 0x07; // Dedo indicador esquerdo
        public const byte FINGER_POSITION_LEFT_MIDDLE = 0x08; // Dedo médio esquerdo.
        public const byte FINGER_POSITION_LEFT_RING = 0x09; // Dedo anelar esquerdo.
        public const byte FINGER_POSITION_LEFT_LITTLE = 0x0A; // Dedo minímo esquerdo.

        // ==================== VALORES DE QUALIDADE DO DEDO ====================

        public const int QUALITY_POOR = 20; // Qualidade pobre da impressão digital (NFIQ valor 5).
        public const int QUALITY_FAIR = 40; // Qualidade razoável da impressão digital (NFIQ valor 4).
        public const int QUALITY_GOOD = 60; // Qualidade boa da impressão digital (NFIQ valor 3).
        public const int QUALITY_VERY_GOOD = 80; // Qualidade muito boa da impressão digital (NFIQ valor 2).
        public const int QUALITY_EXCELLENT = 100; // Qualidade excelente da impressão digital (NFIQ valor 1).

        // ==================== CÓDIGOS DE ERRO ====================

        private const uint ERROR_BASE = 0x30000000; // Valor base para todos os códigos de erro do SDK ANSI.
        public const uint ERROR_NO_ERROR = 0; // Nenhum erro ocorreu.
        public const uint ERROR_IMAGE_SIZE_NOT_SUPPORTED = ERROR_BASE | 1; // Erro: Tamanho de imagem não suportado.
        public const uint ERROR_EXTRACTION_UNSPECIFIED = ERROR_BASE | 2; // Erro: Extração não especificada.
        public const uint ERROR_EXTRACTION_BAD_IMPRESSION = ERROR_BASE | 3; // Erro: Extração falhou - impressão ruim.
        public const uint ERROR_MATCH_NULL = ERROR_BASE | 4; // Erro: Template de correspondência é nulo.
        public const uint ERROR_MATCH_PARSE_PROBE = ERROR_BASE | 5; // Erro: Falha ao analisar template probe.
        public const uint ERROR_MATCH_PARSE_GALLERY = ERROR_BASE | 6; // Erro: Falha ao analisar template gallery.
        public const uint ERROR_MORE_DATA = ERROR_BASE | 7; // Erro: Mais dados necessários.

        // ==================== SCORES DE CORRESPONDÊNCIA ====================

        public const int MATCH_SCORE_LOW = 37; // Score de correspondência baixo (FAR = 1%).
        public const int MATCH_SCORE_LOW_MEDIUM = 65; // Score de correspondência baixo-médio (FAR = 0.1%).
        public const int MATCH_SCORE_MEDIUM = 93; // Score de correspondência médio (FAR = 0.01%).
        public const int MATCH_SCORE_HIGH_MEDIUM = 121; // Score de correspondência alto-médio (FAR = 0.001%).
        public const int MATCH_SCORE_HIGH = 146; // Score de correspondência alto (FAR = 0.0001%).
        public const int MATCH_SCORE_VERY_HIGH = 189; // Score de correspondência muito alto (FAR = 0).


        public const float SCORE_LOW = 20;
        public const float SCORE_LOW_MEDIUM = 34;
        public const float SCORE_MEDIUM = 49;
        public const float SCORE_HIGH_MEDIUM = 64;
        public const float SCORE_HIGH = 77;
        public const float SCORE_VERY_HIGH = 100;


        // ==================== MÉTODOS INTEROP COM P/INVOKE ====================

        // Captura uma imagem de impressão digital do dispositivo Futronic.
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ftrAnsiSdkCaptureImage(IntPtr ftrHandle, IntPtr pBuffer);

        // Obtém o tamanho máximo do template que será gerado pelo SDK,
        // utilizado para alocar buffer suficiente antes de chamar CreateTemplate.
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern int ftrAnsiSdkGetMaxTemplateSize();


        // Cria um template de impressão digital ANSI a partir da imagem atualmente armazenada no scanner.
        // O template é uma representação comprimida das características únicas da impressão digital.
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ftrAnsiSdkCreateTemplate(IntPtr ftrHandle, byte byFingerPosition,
        IntPtr pOutImageBuffer, IntPtr pOutTemplate, ref int pnOutTemplateSize);

        // Cria um template de impressão digital ANSI a partir de um buffer de imagem fornecido.
        // Diferente de CreateTemplate que usa a imagem do scanner, este método processa uma imagem já em memória.
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ftrAnsiSdkCreateTemplateFromBuffer(IntPtr ftrHandle, byte byFingerPosition,
        IntPtr pImageBuffer, int nWidth, int nHeight, IntPtr pOutTemplate, ref int pnOutTemplateSize);

        // Verifica/autentica um template de impressão digital armazenado comparando-o com a impressão atual do scanner.
        // Útil para verificação de identidade um-para-um (1:1).
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ftrAnsiSdkVerifyTemplate(IntPtr ftrHandle, byte byFingerPosition,
        IntPtr pInTemplate, IntPtr pOutImageBuffer, ref float pfOutResult);


        // Compara dois templates de impressão digital e retorna um score de correspondência.
        // Útil para busca em banco de dados um-para-muitos (1:N).
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ftrAnsiSdkMatchTemplates(IntPtr pProbeTemplate, IntPtr pGalleyTemplate, ref float pfOutResult);

        // Converte um template ANSI em um template ISO.
        // Permite interoperabilidade entre diferentes padrões de templates de impressão digital.
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ftrAnsiSdkConvertAnsiTemplateToIso(IntPtr pTemplateANSI, IntPtr pTemplateIso, ref int pnInOutTemplateSize);
    }
}
