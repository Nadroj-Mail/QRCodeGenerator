# QRCodeGenerator

It's supost to create a qr code by creating a png file in the bin folder of the project but, it doesn't because of the line:

"qrCode.SetPixel(currentPosition + (i * ModuleSize) + x, currentPosition + y, moduleColor);"

responding with: 
System.ArgumentOutOfRangeException: 'Parameter must be positive and < Width. Arg_ParamName_Name'

![Screenshot 2023-06-07 175348](https://github.com/Death-Coffin/QRCodeGenerator/assets/129228615/214ce100-4320-4ec3-85b6-0e1bb5d1f789)

And tbf, theres probabley more things but that might be stopping them from showing
