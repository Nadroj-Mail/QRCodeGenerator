using System;
using System.Drawing;
using System.Drawing.Imaging;

public class QRCodeGenerator
{
    private const int ModuleSize = 5; // Size of each module/pixel of the QR code
    private const int QuietZoneSize = 4; // Size of the quiet zone around the QR code

    public static void Main()
    {
        string data = "Rick Roll"; // The data to be encoded in the QR code
        Bitmap qrCode = GenerateQRCode(data);

        qrCode.Save("qrcode.png", ImageFormat.Png);
        Console.WriteLine("Done.");
    }

    private static Bitmap GenerateQRCode(string data)
    {
        int dimension = (data.Length * 8) + 8; // Calculate the QR code size based on data length
        Bitmap qrCode = new(dimension, dimension);

        // Set all modules/pixels to white
        for (int x = 0; x < dimension; x++)
        {
            for (int y = 0; y < dimension; y++)
            {
                qrCode.SetPixel(x, y, System.Drawing.Color.White);
            }
        }

        // Encode the data in the QR code
        int currentPosition = QuietZoneSize;
        foreach (char character in data)
        {
            int asciiValue = Convert.ToInt32(character);

            for (int i = 0; i < 8; i++)
            {
                bool bit = ((asciiValue >> (7 - i)) & 1) == 1;
                System.Drawing.Color moduleColor = bit ? System.Drawing.Color.Black : System.Drawing.Color.White;

                for (int x = 0; x < ModuleSize; x++)
                {
                    for (int y = 0; y < ModuleSize; y++)
                    {
                        qrCode.SetPixel(currentPosition + (i * ModuleSize) + x, currentPosition + y, moduleColor);
                    }
                }
            }

            currentPosition += 8 * ModuleSize;
        }

        return qrCode;
    }
}
