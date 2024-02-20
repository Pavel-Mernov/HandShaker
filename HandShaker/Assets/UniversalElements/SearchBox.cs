using static HandShaker.Assets.ColorResources.Colors;
using static HandShaker.Assets.ThemeResources.Templates;
using HandShaker.Assets.ThemeResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;

namespace HandShaker.Assets.UniversalElements
{
	/*
	[TemplatePart(Name = "SearchBorder", Type = typeof(Border))]
	[TemplatePart(Name = "BtnSearchIcon", Type = typeof(Button))]
	[TemplatePart(Name = "LblPlaceholder", Type = typeof(Label))]
	[TemplatePart(Name = "TxtSearch", Type = typeof(TextBox))]
	[TemplatePart(Name = "ContentPanel", Type = typeof(StackPanel))]
	*/
	internal class SearchBox : ContentControl
	{
		private Border SearchBorder => (Border)Template.FindName("SearchBorder", this);

		private Label LblPlaceholder => (Label)Template.FindName("LblPlaceholder", this);

		private Button BtnSearchIcon => (Button)Template.FindName("BtnSearchIcon", this);

		private TextBox TxtSearch => (TextBox)Template.FindName("TxtSearch", this);
		
		public SearchBox()
		{
			Template = Templates.SearchBoxTemplate;

			Height = 60;


			MouseEnter += SearchBox_MouseEnter;
			MouseLeave += SearchBox_MouseLeave;

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

		public override void OnApplyTemplate()
		{
			BtnSearchIcon.Template = IconButtonTemplate;
			
			BtnSearchIcon.Visibility = Visibility.Visible;
			BtnSearchIcon.Content = FindResource("search");

			TxtSearch.TextChanged += TxtSearch_TextChanged;

			SearchBorder.MouseDown += (sender, e) => Focus();
		}

		private void SearchBox_MouseLeave(object sender, MouseEventArgs e)
		{
			// Leaving the mouse from this object (animation)
			// Returning to the original state
			SearchBorder.BorderBrush = BorderGray;
			SearchBorder.Background = LightGrayFilling;

			// Changing placeholder Color
			LblPlaceholder.Foreground = DarkGray;

			// Changing the color of the search Icon
			BtnSearchIcon.Foreground = DarkGray;
		}

		private void SearchBox_MouseEnter(object sender, MouseEventArgs e)
		{
			// Entering the mouse to the SearchBox object
			SearchBorder.BorderBrush = Black;
			SearchBorder.Background = White;

			// Changing the placeholder label color
			LblPlaceholder.Foreground = Black;

			// Changing the color of the search Icon
			BtnSearchIcon.Foreground = Black;
		}


		public new void Focus()
		{
			TxtSearch.Focus();
		}
	}
}
