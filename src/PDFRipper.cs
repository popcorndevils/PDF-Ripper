using System.Linq;
using Godot;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

public partial class PDFRipper : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		var _grid = this.GetNode<GridContainer>("MainWindow/Grid");

		using (PdfDocument doc = PdfDocument.Open("test3.pdf"))
		{
			
			var _page = doc.GetPage(5);

			foreach(IPdfImage i in _page.GetImages())
			{
				byte[] _dataPng;
				var _texRect = new TextureRect();
				Image _img = new Image();

				if(i.TryGetPng(out _dataPng))
				{
					_img.LoadPngFromBuffer(_dataPng);
				} else
				{
					_img.LoadJpgFromBuffer(i.RawBytes.ToArray());
				}
				if(!_img.IsEmpty())
				{
					_texRect.Texture = ImageTexture.CreateFromImage(_img);
					_grid.AddChild(_texRect);
				}
				{
					GD.Print(i);
				}

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
