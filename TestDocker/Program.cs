// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine($"Run on {Environment.OSVersion}!");

// Instantiate Renderer
var Renderer = new IronPdf.ChromePdfRenderer();

// Create a PDF from a HTML string using C#
var pdf = Renderer.RenderHtmlAsPdf("<h1>Hello World</h1>").BinaryData;
Console.WriteLine("Hello, World!");
// Export to a file or Stream
