namespace ClothFashionApp.Controls;

public partial class FakeSegmentedControl : ContentView
{
    public FakeSegmentedControl()
    {
        InitializeComponent();

        var segmentedItems = SegmentedControlHolder.Children;

        foreach (var child in segmentedItems)
        {
            if (child is FakeSegmentedItem segmentedItem)
                UpdateSegmentedItem(segmentedItem);
        }
    }

    public static new readonly BindableProperty BackgroundColorProperty =    
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(FakeSegmentedControl), null,
            propertyChanged: OnSegmentedControlPropertyChanged);

    public new Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set { SetValue(BackgroundColorProperty, value); }
    }

    public static readonly BindableProperty BackgroundColorSelectedProperty =
        BindableProperty.Create(nameof(BackgroundColorSelected), typeof(Color), typeof(FakeSegmentedControl), null,
            propertyChanged: OnSegmentedControlPropertyChanged);

    public Color BackgroundColorSelected
    {
        get => (Color)GetValue(BackgroundColorSelectedProperty);
        set { SetValue(BackgroundColorSelectedProperty, value); }
    }

    public static new readonly BindableProperty HeightProperty =
        BindableProperty.Create(nameof(Height), typeof(double), typeof(FakeSegmentedControl), 48.0d);

    public new double Height
    {
        get => (double)GetValue(HeightProperty);
        set { SetValue(HeightProperty, value); }
    }

    static void OnSegmentedControlPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as FakeSegmentedControl)?.UpdateSegmentedItems();
    }

    void UpdateSegmentedItems()
    {
        var segmentedItems = SegmentedControlHolder.Children;

        foreach (var child in segmentedItems)
        {
            if (child is FakeSegmentedItem segmentedItem)
                UpdateSegmentedItem(segmentedItem);
        }
    }

    void UpdateSegmentedItem(FakeSegmentedItem segmentedItem)
    {
        if (segmentedItem.BackgroundColor is null)
            segmentedItem.BackgroundColor = BackgroundColor;

        if (segmentedItem.BackgroundColorSelected is null)
            segmentedItem.BackgroundColorSelected = BackgroundColorSelected;

        segmentedItem.UpdateCurrent();
    }
}