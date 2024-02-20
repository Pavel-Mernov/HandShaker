using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows;
using System.Xml.Linq;
using System.Windows.Markup;
using static HandShaker.Assets.ColorResources.Colors;
using System.Windows.Shapes;

namespace HandShaker.Assets.ThemeResources
{
	public static class Templates
	{
		public static ControlTemplate IconButtonTemplate
		{
			get
			{
				ControlTemplate template = new ControlTemplate(typeof(Button));

				var borderFactory = new FrameworkElementFactory(typeof(Border));
				borderFactory.SetValue(Border.BackgroundProperty, Transparent);

				var pathFactory = new FrameworkElementFactory(typeof(Path));
				pathFactory.SetValue(FrameworkElement.NameProperty, "Path");
				pathFactory.SetValue(FrameworkElement.HorizontalAlignmentProperty,
					HorizontalAlignment.Center);
				pathFactory.SetValue(FrameworkElement.VerticalAlignmentProperty, 
					VerticalAlignment.Center);

				borderFactory.AppendChild(pathFactory);

				template.VisualTree = borderFactory;
				return template;
			}
		}
		public static ControlTemplate SearchBoxTemplate
		{
			get
			{
				var xamlString =
				"			<Button " +
				"				Content = \"{StaticResource search}\"" +
				"				/>" +
				"			<Label " +
				"				Name = \"LblPlaceholder\" " +
				"				VerticalAlignment = \"Center\" " +
				"				FontSize = \"30\" " +
				"				FontWeight = \"SemiBold\" " +
				"				Foreground = \"{StaticResource DarkGray}\" " +
				"				Content = \"{TemplateBinding Tag}\" /> ";

				var borderFactory = new FrameworkElementFactory(typeof(Border))
				{
					Name = "SearchBorder"
				};
				borderFactory.SetValue(FrameworkElement.NameProperty, "SearchBorder");
				borderFactory.SetValue(Border.BorderBrushProperty, BorderGray);
				borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(3));
				borderFactory.SetValue(Control.BackgroundProperty, LightGrayFilling);
				borderFactory.SetValue(Control.ForegroundProperty, DarkGray);

				var panelFactory = new FrameworkElementFactory(typeof(StackPanel));
				panelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
				panelFactory.SetValue(FrameworkElement.VerticalAlignmentProperty,
					VerticalAlignment.Center);
				panelFactory.SetValue(FrameworkElement.HorizontalAlignmentProperty,
					HorizontalAlignment.Left);

				var buttonFactory = new FrameworkElementFactory(typeof(Button))
				{
					Name = "BtnSearchIcon"
				};
				buttonFactory.SetValue(FrameworkElement.NameProperty, "BtnSearchIcon");
				buttonFactory.SetValue(FrameworkElement.MarginProperty, new Thickness(0));
				buttonFactory.SetValue(Button.WidthProperty, 40.0);
				buttonFactory.SetValue(Button.HeightProperty, 40.0);
				buttonFactory.SetValue(Control.BackgroundProperty, Transparent);
				buttonFactory.SetValue(Control.BorderThicknessProperty, new Thickness(0));

				var textBoxFactory = new FrameworkElementFactory(typeof(TextBox))
				{
					Name = "TxtSearch"
				};
				textBoxFactory.SetValue(FrameworkElement.NameProperty, "TxtSearch");
				textBoxFactory.SetValue(TextBox.FontSizeProperty, 30.0);
				textBoxFactory.SetValue(Control.FontWeightProperty, FontWeights.SemiBold);
				textBoxFactory.SetValue(Control.ForegroundProperty, Black);
				textBoxFactory.SetValue(TextBox.TextProperty, string.Empty);
				textBoxFactory.SetValue(Control.BackgroundProperty, Transparent);
				textBoxFactory.SetValue(Control.BorderThicknessProperty, new Thickness(0));

				panelFactory.AppendChild(buttonFactory);
				panelFactory.AppendChild(textBoxFactory);


				borderFactory.AppendChild(panelFactory);

				var template = new ControlTemplate(typeof(ContentControl))
				{
					VisualTree = borderFactory,
				};


				return template;
			}
		}
	}
}
