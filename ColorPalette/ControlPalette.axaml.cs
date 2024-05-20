using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections.Generic;

namespace ColorPalette;

public partial class ControlPalette : UserControl
{
    private List<Ellipse> colorCells = [];
    private Ellipse lastCell;
    public ControlPalette()
    {
        InitializeComponent();

        for (int i = 0; i < 10; i++)
        {
            Ellipse cell = new()
            {
                Name = i.ToString(),
                Width = 20,
                Height = 20,
                Margin = new Thickness(5),
                Fill = Brushes.Transparent,
                Stroke = Brushes.Gray,
                StrokeThickness = 1
            };

            cell.PointerPressed += RectanglePointerPressed;
            CustomColors.Children.Add(cell);
            colorCells.Add(cell);
        }

        lastCell = colorCells[0];
        lastCell.Stroke = Brushes.White;
    }

    private void RectanglePointerPressed(object sender, PointerPressedEventArgs e)
    {
        lastCell.Stroke = Brushes.Gray;
        lastCell = (Ellipse)sender;
        lastCell.Stroke = Brushes.White;

        if (lastCell.Fill != Brushes.Transparent)
            aboba.Color = ((SolidColorBrush)lastCell.Fill).Color;
    }

    public void HandleEvent(object sender, RoutedEventArgs e)
    {
        lastCell.Fill = new SolidColorBrush(aboba.Color);
        lastCell.Stroke = Brushes.Gray;
        int nextLabel = int.Parse(lastCell.Name) + 1;
        if (nextLabel > 9)
            nextLabel = 0;
        lastCell = colorCells[nextLabel];
        lastCell.Stroke = Brushes.White;
    }
}