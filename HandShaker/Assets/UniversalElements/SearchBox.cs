using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HandShaker.Assets.UniversalElements
{
	internal class SearchBox : TextBox
	{
		
		private Label LblPlaceholder => (Label)Template.FindName("lblPlaceholder", this);

		private Button BtnIconSearch => (Button)Template.FindName("btnIconSearch", this);

		private TextBox TxtSearch => (TextBox)Template.FindName("txtSearch", this);

		Border BorderSearchPanel => (Border)Template.FindName("borderSearchPanel", this);

		public SearchBox()
		{
			Style = (Style)FindResource("SearchPanelStyle");

			LblPlaceholder.MouseDown += FocusSearch;
			LblPlaceholder.Content = Tag;

			BtnIconSearch.MouseDown += FocusSearch;

			BorderSearchPanel.MouseDown += FocusSearch;

			TxtSearch.MouseDown += FocusSearch;
			TxtSearch.TextChanged += TxtSearch_TextChanged;
		}

		private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
		{
			
			if (string.IsNullOrEmpty(TxtSearch.Text))
			{
				LblPlaceholder.Visibility = Visibility.Visible;
				
			}
			else
			{
				LblPlaceholder.Visibility = Visibility.Hidden;
			}
		}

		private void FocusSearch(object sender, MouseButtonEventArgs e)
		{
			TxtSearch.Focus();
		}
	}
}
