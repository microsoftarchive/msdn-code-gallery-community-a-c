using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckBoxSample.Controls
{ /// <summary>
  /// Custom checkbox control
  /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class CheckBox : ContentView
    {
        public CheckBox()
        {
            InitializeComponent();
            controlLabel.BindingContext = this;
            checkedBackground.BindingContext = this;
            checkedImage.BindingContext = this;
            borderImage.BindingContext = this;
            mainContainer.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(tapped)
            });
        }

        public static readonly BindableProperty BorderImageSourceProperty = BindableProperty.Create(nameof(BorderImageSource), typeof(string), typeof(CheckBox), "", BindingMode.OneWay);
        public static readonly BindableProperty CheckedBackgroundImageSourceProperty = BindableProperty.Create(nameof(CheckedBackgroundImageSource), typeof(string), typeof(CheckBox), "", BindingMode.OneWay);
        public static readonly BindableProperty CheckmarkImageSourceProperty = BindableProperty.Create(nameof(CheckmarkImageSource), typeof(string), typeof(CheckBox), "", BindingMode.OneWay);
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(CheckBox), false, BindingMode.TwoWay, propertyChanged: checkedPropertyChanged);
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(CheckBox), "", BindingMode.OneWay);
        public static readonly BindableProperty CheckedChangedCommandProperty = BindableProperty.Create(nameof(CheckedChangedCommand), typeof(Command), typeof(CheckBox), null, BindingMode.OneWay);
        public static readonly BindableProperty LabelStyleProperty = BindableProperty.Create(nameof(LabelStyle), typeof(Style), typeof(CheckBox), null, BindingMode.OneWay);

        public string BorderImageSource
        {
            get { return (string)GetValue(BorderImageSourceProperty); }
            set { SetValue(BorderImageSourceProperty, value); }
        }

        public string CheckedBackgroundImageSource
        {
            get { return (string)GetValue(CheckedBackgroundImageSourceProperty); }
            set { SetValue(CheckedBackgroundImageSourceProperty, value); }
        }

        public string CheckmarkImageSource
        {
            get { return (string)GetValue(CheckmarkImageSourceProperty); }
            set { SetValue(CheckmarkImageSourceProperty, value); }
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public Command CheckedChangedCommand
        {
            get { return (Command)GetValue(CheckedChangedCommandProperty); }
            set { SetValue(CheckedChangedCommandProperty, value); }
        }

        public Style LabelStyle
        {
            get { return (Style)GetValue(LabelStyleProperty); }
            set { SetValue(LabelStyleProperty, value); }
        }

        public Label ControlLabel
        {
            get { return controlLabel; }
        }

        static void checkedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CheckBox)bindable).ApplyCheckedState();

        }

        /// <summary>
        /// Handle chackox tapped action
        /// </summary>
        void tapped()
        {
            IsChecked = !IsChecked;
            ApplyCheckedState();
        }

        /// <summary>
        /// Reflect the checked event change on the UI
        /// with a small animation
        /// </summary>
        /// <param name="isChecked"></param>
        /// 
        void ApplyCheckedState()
        {
            Animation storyboard = new Animation();
            Animation fadeAnim = null;
            Animation checkBounceAnim = null;
            Animation checkFadeAnim = null;
            double fadeStartVal = 0;
            double fadeEndVal = 1;
            double scaleStartVal = 0;
            double scaleEndVal = 1;
            Easing checkEasing = Easing.CubicIn;

            if (IsChecked)
            {
                checkedImage.Scale = 0;
                fadeStartVal = 0;
                fadeEndVal = 1;
                scaleStartVal = 0;
                scaleEndVal = 1;
                checkEasing = Easing.CubicIn;
            }
            else
            {
                fadeStartVal = 1;
                fadeEndVal = 0;
                scaleStartVal = 1;
                scaleEndVal = 0;
                checkEasing = Easing.CubicOut;
            }
            fadeAnim = new Animation(
                    callback: d => checkedBackground.Opacity = d,
                    start: fadeStartVal,
                    end: fadeEndVal,
                    easing: Easing.CubicOut
                    );
            checkFadeAnim = new Animation(
                callback: d => checkedImage.Opacity = d,
                start: fadeStartVal,
                end: fadeEndVal,
                easing: checkEasing
                );
            checkBounceAnim = new Animation(
                callback: d => checkedImage.Scale = d,
                start: scaleStartVal,
                end: scaleEndVal,
                easing: checkEasing
                );

            storyboard.Add(0, 0.6, fadeAnim);
            storyboard.Add(0, 0.6, checkFadeAnim);
            storyboard.Add(0.4, 1, checkBounceAnim);
            storyboard.Commit(this, "checkAnimation", length: 600);

            if (CheckedChangedCommand != null && CheckedChangedCommand.CanExecute(this))
                CheckedChangedCommand.Execute(this);
        }
    }
}