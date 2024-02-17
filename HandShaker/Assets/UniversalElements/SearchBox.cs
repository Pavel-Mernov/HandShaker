using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HandShaker.Assets.UniversalElements
{
	internal class SearchBox : Control
	{
		public SearchBox()
		{
			Style = (Style)FindResource("SearchBoxStyle");
		}
	}
}
