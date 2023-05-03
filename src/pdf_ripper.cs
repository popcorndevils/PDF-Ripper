using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Godot;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using SysDraw = System.Drawing;

public partial class pdf_ripper : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		using (PdfDocument doc = PdfDocument.Open("test1.pdf"))
		{
			var _testtex = this.GetNode<TextureRect>("MainWindow/TextureRect");
			var _page = doc.GetPage(1);
			
			var _images = _page.GetImages();

			foreach(IPdfImage i in _images)
			{
				// GD.Print(i.ToString());
				Image _img = new Image();
				GD.Print(i.BitsPerComponent);			
				_img.LoadJpgFromBuffer(i.RawBytes.ToArray());

				var _tex = ImageTexture.CreateFromImage(_img);

				_testtex.Texture = _tex;
			}

			// IReadOnlyList<Letter> letters = _page.Letters;
			// string _text = string.Join(string.Empty, letters.Select(x => x.Value));
			// GD.Print(_text);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
