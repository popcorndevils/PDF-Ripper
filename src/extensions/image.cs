using Godot;
using System.IO;
using SysDraw = System.Drawing;

public static class GenTesting
{
	public static ImageTexture GenerateSimple(int[,] mapping)
	{
		if(mapping is not null)
		{
			var _img = new SysDraw.Bitmap(mapping.GetLength(1), mapping.GetLength(0));

			for(int x = 0; x < _img.Width; x++)
			{
				for(int y = 0; y < _img.Height; y++)
				{
					SysDraw.Color c;
					if(mapping[y,x] == 0)
					{
						c = SysDraw.Color.FromArgb(0, SysDraw.Color.White);
					}
					else
					{
						c = SysDraw.Color.Brown;
					}
					_img.SetPixel(x, y, c);
				}
			}
			return ImageTexture.CreateFromImage(_img.ToImage());
		} else
		{
			return GenTesting.BlankSample();
		}
	}
	
	public static ImageTexture BlankSample()
	{
		var _img = new SysDraw.Bitmap(1, 1);
		_img.SetPixel(0, 0, SysDraw.Color.FromArgb(0));
		return ImageTexture.CreateFromImage(_img.ToImage());
	}
}

public static class GodotImage
{
    public static Image ToImage(this SysDraw.Bitmap img)
    {
        var _output = new Image();
        using (MemoryStream ms = new MemoryStream()) {
            img.Save(ms, SysDraw.Imaging.ImageFormat.Png);
            ms.Position = 0;
            _output.LoadPngFromBuffer(ms.ToArray());
        }
        return _output;
    }
}