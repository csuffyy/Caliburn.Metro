using System;
using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;
using MahApps.Metro.Controls;

namespace Caliburn.Metro
{
    /// <summary>
    /// 窗口管理类
    /// </summary>
    [Export(typeof(IWindowManager))]
    public class MetroWindowManager : WindowManager
    {
        private ResourceDictionary[] resourceDictionaries;

        /// <summary>
        /// Makes sure the view is a window is is wrapped by one.
        /// </summary>
        /// <param name="model">The view model.</param>
        /// <param name="view">The view.</param>
        /// <param name="isDialog">Whethor or not the window is being shown as a dialog.</param>
        /// <returns>The window.</returns>
        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            MetroWindow window = null;
            Window inferOwnerOf;
            if (view is MetroWindow)
            {
                window = CreateCustomWindow(view, true);
                inferOwnerOf = InferOwnerOf(window);
                if (inferOwnerOf != null && isDialog)
                {
                    window.Owner = inferOwnerOf;
                }
            }

            if (window == null)
            {
                window = CreateCustomWindow(view, false);
            }

            ConfigureWindow(window);
            window.SetValue(View.IsGeneratedProperty, true);
            inferOwnerOf = InferOwnerOf(window);
            if (inferOwnerOf != null)
            {
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                window.Owner = inferOwnerOf;
            }
            else
            {
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            //TODO：设置窗体的ViewModel
            window.DataContext = model;

            return window;
        }

        /// <summary>
        /// 窗口配置（虚方法，用于继承）
        /// </summary>
        /// <param name="window">要配置的窗体</param>
        public virtual void ConfigureWindow(MetroWindow window)
        {
        }

        /// <summary>
        /// 创建自定义窗口
        /// </summary>
        /// <param name="view">界面</param>
        /// <param name="viewIsMetroWindow">界面是否是MetroWindow类型的窗口</param>
        /// <returns>MetroWindow类型的窗口</returns>
        public virtual MetroWindow CreateCustomWindow(object view, bool viewIsMetroWindow)
        {
            MetroWindow result;
            if (viewIsMetroWindow)
            {
                result = view as MetroWindow;
            }
            else
            {
                result = new MetroWindow
                {
                    Content = view
                };
            }

            AddMetroResources(result);
            return result;
        }

        /// <summary>
        /// 为窗口添加资源
        /// </summary>
        /// <param name="window">窗口</param>
        private void AddMetroResources(MetroWindow window)
        {
            resourceDictionaries = LoadResources();

            foreach (var resourceDictionary in resourceDictionaries)
            {
                window.Resources.MergedDictionaries.Add(resourceDictionary);
            }
        }

        /// <summary>
        /// 加载资源
        /// </summary>
        /// <returns>资源字典</returns>
        private static ResourceDictionary[] LoadResources()
        {
            return new[]
            {
                new ResourceDictionary
                {
                    Source =
                        new Uri(
                            "pack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml",
                            UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source =
                        new Uri(
                            "pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml",
                            UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source =
                        new Uri(
                            "pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml",
                            UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source =
                        new Uri(
                            "pack://application:,,,/MahApps.Metro;component/Styles/Controls.AnimatedSingleRowTabControl.xaml",
                            UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source =
                        new Uri(
                            "pack://application:,,,/Caliburn.Metro.Core;component/Resources/Icons.xaml",
                            UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = 
                        new Uri(
                            "pack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml",
                            UriKind.RelativeOrAbsolute)
                }
            };
        }
    }
}