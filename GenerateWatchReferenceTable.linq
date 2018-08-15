void Main()
{
	var table = information.Split('\n')
		.Select(line => line.Split('	').Select(cell => cell.Trim()).ToList())
		.ToList();

	var stringBuilder = new StringBuilder();

	var headers = table.First().ToList();
	foreach (var header in headers)
	{
		stringBuilder.Append('|');
		stringBuilder.Append(header);
	}
	stringBuilder.Append('|');
	stringBuilder.Append('\n');

	for (int i = 0; i < headers.Count; i++)
	{
		stringBuilder.Append("|---");
	}
	stringBuilder.Append('|');
	stringBuilder.Append('\n');

	foreach (var row in table.Skip(1).ToList())
	{
		foreach (var cell in row)
		{
			stringBuilder.Append('|');
			stringBuilder.Append(cell);
		}

		stringBuilder.Append('|');
		stringBuilder.Append('\n');
	}

	stringBuilder.ToString().Dump();
}

string information = @"Device	Resolution (px)	Icon Resolution	Colors	Available Button Functions	Screen Type	Touch Screen
Approach®S60	240 x 240	40 x 33	64	enter, back, menu	round	Yes
Edge® 520	200 x 265	35 x 35	65536	up, down, enter, back, start, lap	rectangle	No
Edge® 820, edge Explore 820	200 x 265	35 x 35	65536	start, lap	rectangle	Yes
Edge® 1000, Edge Explore 1000	240 x 400	36 x 36	65536	start, lap	rectangle	Yes
epix®	205 x 148	40 x 40	64	up, down, enter, back, menu	rectangle	Yes
fēnix® 3, fēnix® 3 HR, D2® Bravo, D2® Bravo Titanium, tactix® Bravo, quatix® 3	218 x 218	40 x 40	16	up, down, enter, back, menu	round	No
fēnix® 5S	218 x 218	36 x 36	64	up, down, enter, back, menu	round	No
fēnix® 5, fēnix® 5X, Forerunner® 935, quatix&reg 5	240 x 240	40 x 40	64	up, down, enter, back, menu	round	No
fēnix® Chronos	218 x 218	36 x 36	64	up, down, enter, back, menu	round	No
Forerunner® 230, 235, 735XT	215 x 180	40 x 40	16	up, down, enter, back, menu	semi-round	No
Forerunner® 630	215 x 180	40 x 40	16	lap, enter, back, menu	semi-round	Yes
Forerunner® 920XT	205 x 148	65 x 65	16	up, down, enter, back, menu	rectangle	No
Oregon® 7xx	240 x 400	36 x 36	65536	none	rectangle	Yes
Rino® 7xx	240 x 400	36 x 36	65536	none	rectangle	Yes
vívoactive®	205 x 148	61 x 43	64	enter, back, menu	rectangle	Yes
vívoactive HR®	148 x 205	40 x 33	64	enter, back, menu	tall	Yes";
