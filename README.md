# An Image To Ascii Converter

Blazor.ImageToAscii is a Blazor WebAssembly app that transforms an image to an ASCII map, using darkerst to lighter character sets. You can find  working sample of the app at https://i2t.azurewebsites.net/

The actual engine is a .NET Standard library ([Image2Text.Core](https://github.com/georgekosmidis/Blazor.ImageToAscii/tree/master/src/Image2Text.Core)) that uses ImageSharp to read the image and transform each byte to a character.

The library offers more capabilities than what the sample contains (e.g. change the size of the image, use different character sets etc.), so this is actually work in progress!

The following gif is an output sample of the library:
![Transformation Sample](https://raw.githubusercontent.com/georgekosmidis/ImageToText/master/readme/readme.gif)
