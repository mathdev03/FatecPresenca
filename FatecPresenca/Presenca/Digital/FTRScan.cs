using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FatecPresenca.Presenca.ftScanAPI;
using static FatecPresenca.Presenca.FtrAnsiSdk;
using static FatecPresenca.Presenca.NIFQ2;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Imaging;

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
    internal class FTRScan
    {
        private IntPtr handle, buffer, template;
        private int templateSize, qualityResult;

        public FTRScan()
        {
            templateSize = takeTemplateSize();
        }

        public bool OpenDevice()
        {
            try
            {
                handle = ftrScanOpenDevice();
                if (handle == IntPtr.Zero) throw new Exception("Dispositivo não ligado!");

                Console.WriteLine("Dispositivo inciado!");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message , "Erro ao ligar");
                return false;
            }

            return true;
        }
        public void CloseDevice()
        {
            try
            {
                if (handle == IntPtr.Zero) throw new Exception("Erro ao desligar dispositivo");
                ftrScanCloseDevice(handle);

                Console.WriteLine("Dispositivo desligado!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void ConfigScan()
        {
            // LFD - Live Detection Finger, para obter o dedo real tirando a réplica
            uint flags = FTR_OPTIONS_DETECT_FAKE_FINGER | FTR_OPTIONS_CHECK_FAKE_REPLICA | FTR_OPTIONS_INVERT_IMAGE;

            uint mask = flags;

            try
            {
                bool sucessoSetado = ftrScanSetOptions(handle, mask, flags) != 0;

                if (!sucessoSetado) throw new Exception("Falha ao setar as configurações!");

                bool OptionsNow = ftrScanGetOptions(handle, out uint flagsRecente) != 0;

                if (OptionsNow) Console.WriteLine($"Opções adicionados: 0x{flagsRecente:x}");

                // Atualizar as config para ativar o LFD.

                if (!(sucessoSetado && (flagsRecente & flags) == flags)) throw new Exception("Falha ao atualizar!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao tentar adicionar opções: {e.Message}");
            }
        }


        // Referências
        private ImageSize takeSizeImage(ImageSize img)
        {
            bool imageSize = ftrScanGetImageSize(handle, out img) != 0;
            if (!imageSize) {                 
                Console.WriteLine("FALHA AO PEGAR O TAMANHO DA IMAGEM!");
                return img;
            }

            return img;
        }

        private int takeTemplateSize()
        {
            int size = ftrAnsiSdkGetMaxTemplateSize();
            if (size <= 0) {
                Console.WriteLine("FALHA AO PEGAR O TAMANHO DO TEMPLATE!");
                return size;
            }

            return size;
        }

        private void takeImage(ref FrameParameters frame)
        {
            bool capturarFrame = ftrScanGetFrame(handle, buffer, out frame) != 0;
            if (!capturarFrame)
            {
                Console.WriteLine("Frame não capturado! Tente denovo....");
                return;
            }

            bool capturafoto = ftrScanGetImage2(handle, 1, buffer) != 0;
            if (!capturafoto)
            {
                Console.WriteLine("Falha ao pegar imagem!");
                return;
            }
        }

        private void fingerPresentFrame()
        {
            FrameParameters frame = new FrameParameters();
            bool fingerDetect = false;

            while (true)
            {
                Thread.Sleep(1000);

                // Presença de dedo
                bool capturarDedo = ftrScanIsFingerPresent(handle, out frame) != 0;

                if (capturarDedo)
                {
                    // Colocando o finger
                    if (!fingerDetect)
                    {
                        Console.WriteLine("Dedo detectado! Agora é ajustar....");
                        fingerDetect = true;
                    }

                    takeImage(ref frame);
                    if (frame.Dose > 0) return;
                }
                else
                {
                    if (fingerDetect)
                    {
                        Console.WriteLine("Dedo retirado coloque no lugar!");
                        fingerDetect = false;
                    }
                }
            }
        }

        private async Task fingerPresentFrameAsync(CancellationTokenSource cancelation = default)
        {
            FrameParameters frame = new FrameParameters();
            bool fingerDetect = false;

            while (true)
            {
                await Task.Delay(1000);
                cancelation.Token.ThrowIfCancellationRequested();

                // Presença de dedo
                bool capturarDedo = ftrScanIsFingerPresent(handle, out frame) != 0;

                if (capturarDedo)
                {
                    // Colocando o finger
                    if (!fingerDetect)
                    {
                        Console.WriteLine("Dedo detectado! Agora é ajustar....");
                        fingerDetect = true;
                    }

                    takeImage(ref frame);
                    if (frame.Dose > 0) return;
                }
                else
                {
                    if (fingerDetect)
                    {
                        Console.WriteLine("Dedo retirado coloque no lugar!");
                        fingerDetect = false;
                    }
                }
            }
        }

        private void quality(byte[] b, ImageSize img, int chosedFinger)
        {
            Marshal.Copy(buffer, b, 0, b.Length);

            int width = img.Width;
            int height = img.Height;
            int resolution = 500;

            IntPtr hash = IntPtr.Zero;
            nfiq2Init(hash);

            int computeQuality = ComputeScoreNfiq2(b, width, height, resolution, chosedFinger);
            qualityResult = computeQuality;
        }

        private static Bitmap ByteArrayToBitmap(byte[] b, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format8bppIndexed);

            // Define a paleta de cores em tons de cinza
            ColorPalette palette = bmp.Palette;
            for (int i = 0; i < 256; i++)
                palette.Entries[i] = Color.FromArgb(i, i, i);
            bmp.Palette = palette;

            // Copia os dados do buffer para o bitmap
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            System.Runtime.InteropServices.Marshal.Copy(b, 0, bmpData.Scan0, b.Length);
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        private static byte fingerChoose(int number)
        {
            return number switch
            {
                1 => FINGER_POSITION_RIGHT_THUMB,
                2 => FINGER_POSITION_RIGHT_INDEX,
                3 => FINGER_POSITION_RIGHT_MIDDLE,
                4 => FINGER_POSITION_RIGHT_RING,
                5 => FINGER_POSITION_RIGHT_LITTLE,
                6 => FINGER_POSITION_LEFT_THUMB,
                7 => FINGER_POSITION_LEFT_INDEX,
                8 => FINGER_POSITION_LEFT_MIDDLE,
                9 => FINGER_POSITION_LEFT_RING,
                10 => FINGER_POSITION_LEFT_LITTLE,
                _ => 0
            };
        }

        // Gerenciar biometria
        public void RegisterBiometric(int chosedFinger)
        {
            if(handle == IntPtr.Zero) return;

            ImageSize img = new ImageSize();
            img = takeSizeImage(img);

            byte[] bufferB = new byte[img.ImageS];
            byte[] templateB = new byte[templateSize];

            GCHandle allocB = GCHandle.Alloc(bufferB, GCHandleType.Pinned);
            GCHandle allocT = GCHandle.Alloc(templateB, GCHandleType.Pinned);

            try
            {
                buffer = allocB.AddrOfPinnedObject();
                template = allocT.AddrOfPinnedObject();

                bool fingerPresent = false;
                byte finger = fingerChoose(chosedFinger);
                if (finger == 0) throw new Exception("Dedo não escolhido corretamente");
                    
                fingerPresentFrame();
                quality(bufferB, img, chosedFinger);
                    
                bool takeTemplate = ftrAnsiSdkCreateTemplateFromBuffer(handle, finger, buffer, img.Width, img.Height, template, ref templateSize);
                if (!takeTemplate) throw new Exception("Dados/Função de criação de template não feita!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao gravar template: {ex.Message}");
            }
            finally
            {
                allocB.Free();
                allocT.Free();
            }
        }
        
        public float VerifyBiometric(byte[] templateExtern, int chosedFinger)
        {
            if (handle == IntPtr.Zero) return 0;

            float retorno = 0;

            ImageSize img = new ImageSize();
            img = takeSizeImage(img);

            byte[] bufferB = new byte[img.ImageS];

            GCHandle allocT = GCHandle.Alloc(templateExtern, GCHandleType.Pinned);
            GCHandle allocB = GCHandle.Alloc(bufferB, GCHandleType.Pinned);

            byte finger = fingerChoose(chosedFinger);

            try
            {
                template = allocT.AddrOfPinnedObject();
                buffer = allocB.AddrOfPinnedObject();

                Marshal.Copy(templateExtern, 0, template, templateExtern.Length);

                float result = 0;

                while (true)
                {
                    Thread.Sleep(2000);
                    bool verified = ftrAnsiSdkVerifyTemplate(handle, finger, template, buffer, ref result);
                    if (verified) break;
                } 

                retorno = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao verificar template: {ex.Message}");
                retorno = 0;
            }
            finally { 
                allocT.Free();
                allocB.Free();
            }

            return retorno;
        }

        public async Task<bool> takeBiometricIdentify(CancellationTokenSource cancelation = default)
        {
            if (handle == IntPtr.Zero) return false;

            bool cancel = false;

            ImageSize img = new ImageSize();
            img = takeSizeImage(img);

            byte[] bufferB = new byte[img.ImageS];
            byte[] templateB = new byte[templateSize];

            GCHandle allocB = GCHandle.Alloc(bufferB, GCHandleType.Pinned);
            GCHandle allocT = GCHandle.Alloc(templateB, GCHandleType.Pinned);

            try
            {
                buffer = allocB.AddrOfPinnedObject();
                template = allocT.AddrOfPinnedObject();

                await fingerPresentFrameAsync(cancelation);

                byte finger = FINGER_POSITION_UNKNOWN;

                bool takeTemplate = ftrAnsiSdkCreateTemplateFromBuffer(handle, finger, buffer, img.Width, img.Height, template, ref templateSize);
                if (!takeTemplate) throw new Exception("Dados/Função de criação de template não feita!");
            }
            catch (OperationCanceledException)
            {
                cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao gravar template: {ex.Message}");
                return false;
            }
            finally
            {
                allocB.Free();
                allocT.Free();
            }

            if (cancel)
                cancelation.Token.ThrowIfCancellationRequested();

            return true;
        }

        public float IdentifyBiometric(byte[] templateGalleryB)
        {
            byte[] templateProbleB = new byte[templateSize];
            Marshal.Copy(template, templateProbleB, 0, templateSize);

            GCHandle allocG = GCHandle.Alloc(templateGalleryB, GCHandleType.Pinned);
            GCHandle allocP = GCHandle.Alloc(templateProbleB, GCHandleType.Pinned);

            float result = 0;

            try
            {
                IntPtr templateGallery = allocG.AddrOfPinnedObject();
                template = allocP.AddrOfPinnedObject();

                bool match = ftrAnsiSdkMatchTemplates(template, templateGallery, ref result);
                if (!match) throw new Exception("Falha ao identificar o template");

            }
            catch (Exception ex) {
                Console.WriteLine($"Falha ao identificar: {ex.Message}");
                result = 0;
            }
            finally{
                allocG.Free();
                allocP.Free();
            }

            return result;
        }

        public byte[] getTemplate()
        {
            if (handle == IntPtr.Zero) return [];

            byte[] saveTemplate = new byte[templateSize];
            Marshal.Copy(template, saveTemplate, 0, templateSize);

            return saveTemplate;
        }

        public Bitmap getImage()
        {
            if (handle == IntPtr.Zero) return null;

            // take buffer
            ImageSize img = new ImageSize();
            img = takeSizeImage(img);

            byte[] bufferB = new byte[img.ImageS];
            Marshal.Copy(buffer, bufferB, 0, img.ImageS);

            return ByteArrayToBitmap(bufferB, img.Width, img.Height);
        }

        public int getQuality()
        {
            if (handle == IntPtr.Zero) return 0;
            return qualityResult;
        }
    }
}
