namespace ClothFashionApp.Controls;

public partial class FakeSegmentedItem : ContentView
{
    public FakeSegmentedItem()
    {
        InitializeComponent();
    }

    public static new readonly BindableProperty BackgroundColorProperty =
      BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(FakeSegmentedItem), null,
          propertyChanged: OnSegmentedItemPropertyChanged);

    public new Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set { SetValue(BackgroundColorProperty, value); }
    }

    public static readonly BindableProperty BackgroundColorSelectedProperty =
        BindableProperty.Create(nameof(BackgroundColorSelected), typeof(Color), typeof(FakeSegmentedItem), null);

    public Color BackgroundColorSelected
    {
        get => (Color)GetValue(BackgroundColorSelectedProperty);
        set { SetValue(BackgroundColorSelectedProperty, value); }
    }
    
    public static readonly BindableProperty IconProperty =
      BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(FakeSegmentedItem), null,
          propertyChanged: OnSegmentedItemPropertyChanged);

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set { SetValue(IconProperty, value); }
    }

    public static readonly BindableProperty IconSelectedProperty =
      BindableProperty.Create(nameof(IconSelected), typeof(ImageSource), typeof(FakeSegmentedItem), null,
          propertyChanged: OnSegmentedItemPropertyChanged);

    public ImageSource IconSelected
    {
        get => (ImageSource)GetValue(IconSelectedProperty);
        set { SetValue(IconSelectedProperty, value); }
    }

    public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(FakeSegmentedItem), false,
            propertyChanged: OnIsSelectedChanged);

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set { SetValue(IsSelectedProperty, value); }
    }

    static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as FakeSegmentedItem)?.UpdateCurrent();
    }

    static void OnSegmentedItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as FakeSegmentedItem)?.UpdateCurrent();
    }

    internal static readonly BindablePropertyKey CurrentBackgroundColorPropertyKey =
          BindableProperty.CreateReadOnly(nameof(CurrentBackgroundColor), typeof(Color), typeof(FakeSegmentedItem), null);

    public static readonly BindableProperty CurrentBackgroundColorProperty = CurrentBackgroundColorPropertyKey.BindableProperty;

    public Color CurrentBackgroundColor
    {
        get
        {
            return (Color)GetValue(CurrentBackgroundColorProperty);
        }
        private set
        {
            SetValue(CurrentBackgroundColorPropertyKey, value);
        }
    }

    internal static readonly BindablePropertyKey CurrentIconPropertyKey = 
        BindableProperty.CreateReadOnly(nameof(CurrentIcon), typeof(ImageSource), typeof(FakeSegmentedItem), null);

    public static readonly BindableProperty CurrentIconProperty = CurrentIconPropertyKey.BindableProperty;

    public ImageSource CurrentIcon
    {
        get
        {
            return (ImageSource)GetValue(CurrentIconProperty);
        }
        private set
        {
            SetValue(CurrentIconPropertyKey, value);
        }
    }

    internal void UpdateCurrent()
    {
        CurrentBackgroundColor = !IsSelected || BackgroundColorSelected is null ? BackgroundColor : BackgroundColorSelected;
        CurrentIcon = !IsSelected || IconSelected is null ? Icon : IconSelected;
    }
}