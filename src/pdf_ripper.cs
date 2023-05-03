using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

public partial class pdf_ripper : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		using (PdfDocument doc = PdfDocument.Open("test.pdf"))
		{
			foreach(Page p in doc.GetPages())
			{
				IReadOnlyList<Letter> letters = p.Letters;
				string example = string.Join(string.Empty, letters.Select(x => x.Value));
				GD.Print(example);
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
