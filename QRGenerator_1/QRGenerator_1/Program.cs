using System;
using System.Drawing;
using System.Drawing.Imaging;

public class QRCodeGenerator
{
    private const int ModuleSize = 5; // Size of each module/pixel of the QR code
    private const int QuietZoneSize = 4; // Size of the quiet zone around the QR code

    public static void Main()
    {
        Console.Write("Data You Want To Encode: ");
        string data = Console.ReadLine();

        while (data == null)
        {
            if (data == null)
            {
                Console.WriteLine("Please Enter Data To Encode");
            }
            Console.Write("Data You Want To Encode: ");
            data = Console.ReadLine();

        }

        Console.Write("Name of the QR-Code: ");
        string Name_Of_Code = Console.ReadLine();

        Bitmap qrCode = GenerateQRCode(data);
        qrCode.Save($"{Name_Of_Code}.png", ImageFormat.Png);
        Console.WriteLine("QR code generated successfully!");
    }

    private static Bitmap GenerateQRCode(string data)
    {
        int dimension = (data.Length * 8) + 8; // Calculate the QR code size based on data length
        Bitmap qrCode = new(dimension, dimension);

        // Set all pixels to white
        for (int x = 0; x < dimension; x++)
        {
            for (int y = 0; y < dimension; y++)
            {
                qrCode.SetPixel(x, y, System.Drawing.Color.White);
            }
        }

        // Encode the data in the QR code (It's Jank, but makes something, even if it isn't the right thing)
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
                        int pixelX = currentPosition + (i * ModuleSize) + x;
                        int pixelY = currentPosition + y;

                        if (pixelX < dimension && pixelY < dimension)
                        {
                            qrCode.SetPixel(pixelX, pixelY, moduleColor);
                        }
                    }
                }
            }


            currentPosition += 8 * ModuleSize;
        }

        return qrCode;
    }
}
