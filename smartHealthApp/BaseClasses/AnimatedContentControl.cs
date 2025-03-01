﻿using smartHealthApp.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace smartHealthApp.BaseClasses
{
    public class ChangedEventArgs<T> : EventArgs
    {
        public readonly T LastValue;
        public readonly T NewValue;
        public ChangedEventArgs(T lastValue, T newValue)
        {
            this.LastValue = lastValue;
            this.NewValue = newValue;
        }
    }
    public delegate void ContentAnimatedEvent(object sender);

    [TemplatePart(Name = "PART_PaintArea", Type = typeof(Shape)), TemplatePart(Name = "PART_MainContent", Type = typeof(ContentPresenter))]
    public class AnimatedContentControl : ContentControl
    {
        [Description("Select the direction you would like the slide transition to go in."), Category("Behavior Settings")]
        public Transition Transition { get { return (Transition)GetValue(TransitionProperty); } set { SetValue(TransitionProperty, value); } }

        public static readonly DependencyProperty TransitionProperty = DependencyProperty.Register("Transition", typeof(Transition),
            typeof(AnimatedContentControl), new PropertyMetadata(Transition.LeftWithFade));

        [Description("Seconds for the transition.  Example: 0.5 for half a second, 1 for a second, etc..."), Category("Behavior Settings")]
        public double SlideTime { get { return (double)GetValue(SlideTimeProperty); } set { SetValue(SlideTimeProperty, value); } }
        public static readonly DependencyProperty SlideTimeProperty = DependencyProperty.Register("SlideTime", typeof(double),
            typeof(AnimatedContentControl), new PropertyMetadata(0.25));

        Shape m_paintArea = null;
        ContentPresenter m_mainContent = null;

        public event ContentAnimatedEvent ContentAnimated;
        private static ControlTemplate defaultTemplate;

        public bool AllowTransitions { get; set; }

        static AnimatedContentControl()
        {
            ControlTemplate template = new ControlTemplate(typeof(AnimatedContentControl));
            var grid = new FrameworkElementFactory(typeof(Grid));
            var contentHost = new FrameworkElementFactory(typeof(ContentPresenter), "PART_MainContent");
            contentHost.SetValue(ContentProperty, new TemplateBindingExtension(ContentControl.ContentProperty));
            grid.AppendChild(contentHost);
            var paintArea = new FrameworkElementFactory(typeof(Rectangle), "PART_PaintArea");
            paintArea.SetValue(Panel.ZIndexProperty, -1);
            grid.AppendChild(paintArea);

            template.VisualTree = grid;
            defaultTemplate = template;
        }

        public AnimatedContentControl()
        {
            this.SetValue(TemplateProperty, defaultTemplate);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            m_paintArea = Template.FindName("PART_PaintArea", this) as Shape;
            m_mainContent = Template.FindName("PART_MainContent", this) as ContentPresenter;
        }

        public void LoadControl(object content, Transition transition = Transition.Default)
        {
            if (transition != Transition.Default)
            {
                var tempValue = this.Transition;
                this.SetCurrentValue(TransitionProperty, transition);
                this.SetValue(ContentProperty, content);
                this.SetValue(TransitionProperty, tempValue);
            }
            else
            {
                this.SetValue(ContentProperty, content);
            }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (m_paintArea != null && m_mainContent != null && AllowTransitions)
            {
                m_paintArea.Fill = CreateBrushFromVisual(m_mainContent);
                AnimateContentTransition();
            }
            base.OnContentChanged(oldContent, newContent);
        }

        private Brush CreateBrushFromVisual(Visual visual)
        {
            var target = new RenderTargetBitmap((int)this.ActualWidth, (int)this.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            target.Render(visual);
            var brush = new ImageBrush(target);
            brush.Freeze();
            return brush;
        }

        private void AnimateContentTransition()
        {
            var newContentTransform = new TranslateTransform() { X = 0, Y = 0 };
            var oldContentTransform = new TranslateTransform() { X = 0, Y = 0 };
            m_paintArea.RenderTransform = oldContentTransform;
            m_mainContent.RenderTransform = newContentTransform;
            m_paintArea.Visibility = Visibility.Visible;

            EventHandler onExitAnimation = (o, e) =>
            {
                m_paintArea.BeginAnimation(UIElement.OpacityProperty, null);
                m_paintArea.SetValue(UIElement.OpacityProperty, 1.0);
                m_paintArea.Visibility = Visibility.Hidden;
            };

            switch (this.Transition)
            {
                case Transition.Right:
                    newContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(-this.ActualWidth, 0));
                    oldContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(0, this.ActualWidth, onExitAnimation));
                    break;
                case Transition.Left:
                    newContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(this.ActualWidth, 0));
                    oldContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(0, -this.ActualWidth, onExitAnimation));
                    break;
                case Transition.Up:
                    newContentTransform.BeginAnimation(TranslateTransform.YProperty, CreateAnimation(this.ActualHeight, 0));
                    oldContentTransform.BeginAnimation(TranslateTransform.YProperty, CreateAnimation(0, -this.ActualHeight, onExitAnimation));
                    break;
                case Transition.Down:
                    newContentTransform.BeginAnimation(TranslateTransform.YProperty, CreateAnimation(-this.ActualHeight, 0));
                    oldContentTransform.BeginAnimation(TranslateTransform.YProperty, CreateAnimation(0, this.ActualHeight, onExitAnimation));
                    break;
                case Transition.LeftWithFade:
                    newContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(this.ActualWidth, 0));
                    oldContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(0, -this.ActualWidth));
                    m_mainContent.BeginAnimation(UIElement.OpacityProperty, CreateAnimation(0, 1));
                    m_paintArea.BeginAnimation(UIElement.OpacityProperty, CreateAnimation(1, 0, onExitAnimation));
                    break;
                case Transition.RightWithFade:
                    newContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(-this.ActualWidth, 0));
                    oldContentTransform.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(0, this.ActualWidth));
                    m_mainContent.BeginAnimation(UIElement.OpacityProperty, CreateAnimation(0, 1));
                    m_paintArea.BeginAnimation(UIElement.OpacityProperty, CreateAnimation(1, 0, onExitAnimation));
                    break;
                case Transition.Fade:
                    m_mainContent.BeginAnimation(UIElement.OpacityProperty, CreateAnimation(0, 1));
                    m_paintArea.BeginAnimation(UIElement.OpacityProperty, CreateAnimation(1, 0, onExitAnimation));
                    break;
            }


            if (ContentAnimated != null)
            {
                ContentAnimated(this);
            }
        }

        private AnimationTimeline CreateAnimation(double from, double to, EventHandler whenDone = null)
        {
            var duration = new Duration(TimeSpan.FromSeconds(this.SlideTime));
            var anim = new DoubleAnimation(from, to, duration) { AccelerationRatio = 0.9 };

            if (whenDone != null)
                anim.Completed += whenDone;
            anim.Freeze();
            return anim;
        }
    }
}
