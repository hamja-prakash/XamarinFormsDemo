using Acr.UserDialogs;
using System;
using Xamarin.Forms;

namespace XamarinNativeDemo.Model
{
    public class Common
    {
        public static MasterDetailPage MasterPage;

        public static int ProductId = 0;

        public static void AlertMessage(string msg)
        {
            UserDialogs.Instance.Toast(new ToastConfig(msg)
            {
                Position = ToastPosition.Top,
                BackgroundColor = Color.Black,
                MessageTextColor = Color.White,
                Duration = TimeSpan.FromSeconds(2)
            });
        }

        public static void ErrorMessage(string msg)
        {
            UserDialogs.Instance.Toast(new ToastConfig(msg)
            {
                Position = ToastPosition.Top,
                BackgroundColor = Color.Red,
                MessageTextColor = Color.White,
                Duration = TimeSpan.FromSeconds(2)
            });
        }

        public static void SuccessMessage(string msg)
        {
            UserDialogs.Instance.Toast(new ToastConfig(msg)
            {
                Position = ToastPosition.Top,
                BackgroundColor = Color.Green,
                MessageTextColor = Color.White,
                Duration = TimeSpan.FromSeconds(2)
            });
        }

        public static byte[] ConvertStreamToByteArray(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }
            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}
