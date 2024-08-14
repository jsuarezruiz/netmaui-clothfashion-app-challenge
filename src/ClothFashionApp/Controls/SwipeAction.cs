using Microsoft.Maui.Layouts;
using System.Windows.Input;

namespace ClothFashionApp.Controls
{
    public class SwipeAction : AbsoluteLayout, IDisposable
    {
        const uint AnimLength = 50;

        readonly PanGestureRecognizer _gesture;
        readonly View _gestureListener;

        public SwipeAction()
        {
            SizeChanged += OnSizeChanged;

            _gesture = new PanGestureRecognizer();
            _gesture.PanUpdated += OnPanGestureUpdated;

            _gestureListener = new ContentView
            {
                BackgroundColor = Colors.Black,
                Opacity = 0.01
            };
            _gestureListener.GestureRecognizers.Add(_gesture);
        }

        public void Dispose()
        {
            SizeChanged -= OnSizeChanged;

            if (_gesture is not null)
                _gesture.PanUpdated -= OnPanGestureUpdated;

            if (_gestureListener is not null)
                _gestureListener.GestureRecognizers.Remove(_gesture);
        }

        public static readonly BindableProperty ThumbProperty = BindableProperty.Create(
           nameof(Thumb),
           typeof(View),
           typeof(SwipeAction),
           defaultValue: default(View));

        public View Thumb
        {
            get => (View)GetValue(ThumbProperty);
            set => SetValue(ThumbProperty, value);
        }

        public static readonly BindableProperty TrackProperty = BindableProperty.Create(
                nameof(Track),
                typeof(View),
                typeof(SwipeAction),
                defaultValue: default(View));

        public View Track
        {
            get => (View)GetValue(TrackProperty);
            set => SetValue(TrackProperty, value);
        }

        public static readonly BindableProperty SwipeActionCommandProperty = BindableProperty.Create(
           nameof(SwipeActionCommand),
           typeof(ICommand),
           typeof(SwipeAction),
           defaultValue: default(ICommand));

        public ICommand SwipeActionCommand
        {
            get => (ICommand)GetValue(SwipeActionCommandProperty);
            set => SetValue(SwipeActionCommandProperty, value);
        }

        public event EventHandler SwipeActionCompleted;

        void OnSizeChanged(object sender, EventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;

            if (Thumb is null || Track is null)
                return;

            Children.Clear();

            this.SetLayoutFlags(Track, AbsoluteLayoutFlags.SizeProportional);
            this.SetLayoutBounds(Track, new Rect(0, 0, 1, 1));
            Children.Add(Track);

            this.SetLayoutFlags(Thumb, AbsoluteLayoutFlags.None);
            this.SetLayoutBounds(Thumb, new Rect(0, 0, Width / 3, Height));
            Children.Add(Thumb);

            this.SetLayoutFlags(_gestureListener, AbsoluteLayoutFlags.SizeProportional);
            this.SetLayoutBounds(_gestureListener, new Rect(0, 0, 1, 1));
            Children.Add(_gestureListener);
        }

        async void OnPanGestureUpdated(object? sender, PanUpdatedEventArgs e)
        {
            if (Thumb is null || Track is null)
                return;

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    await Track.FadeTo(0.5, AnimLength);
                    break;

                case GestureStatus.Running:

                    var x = Math.Max(0, e.TotalX);

                    if (x > (Width - Thumb.Width))
                        x = (Width - Thumb.Width);

                    Thumb.TranslationX = x;
                    break;

                case GestureStatus.Completed:
                    var posX = Thumb.TranslationX;
                    await Track.FadeTo(1, AnimLength);
                    await Thumb.TranslateTo(0, 0, AnimLength * 2, Easing.CubicIn);

                    if (posX >= (Width - Thumb.Width))
                    {
                        SwipeActionCommand?.Execute(null);
                        SwipeActionCompleted?.Invoke(this, EventArgs.Empty);
                    }
                    break;
            }
        }
    }
}