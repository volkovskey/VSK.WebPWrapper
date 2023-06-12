# VSK.WebPWrapper

I stopped working on this project, I recommend using this one - [WebPWrapper by vladikko](https://github.com/vladikko/WebPWrapper)

[![NuGet Download](https://img.shields.io/nuget/dt/VSK.WebPWrapper.svg)](#) [![Github license](https://img.shields.io/github/license/volkovskey/VSK.WebPWrapper.svg)](#)

WebP wrapper for .Net Standart 2.1

For more information about WebP, visit the official website: [https://developers.google.com/speed/webp/](https://developers.google.com/speed/webp/)

## Quick start

### Installation kit
```shell
dotnet add package VSK.WebPWrapper
```

### Code example
```csharp 
using VSK.WebPWrapper;
using VSK.WebPWrapper.Encoder;

WebPExecuteDownloader.Download();

var builder = new WebPEncoderBuilder();

var encoder = builder
	.Resize(100, 0) // Resize image to 100px (length)
	.AlphaConfig(x => x // set alpha config
		.TransparentProcess(
			TransparentProcesses.Blend, // Change transparent color to blend with yellow color
			Color.Yellow
		)
	)
	.CompressionConfig(x => x // set compression config
		.Lossless(y => y.Quality(75)) // set lossless config
	) 
	.Build(); // build encoder

using (var outputFile = File.Open("output.webp", FileMode.Create))
using (var inputFile = File.Open("input.png", FileMode.Open)) {
	encoder.Encode(inputFile, outputFile); // encode image
}
```
