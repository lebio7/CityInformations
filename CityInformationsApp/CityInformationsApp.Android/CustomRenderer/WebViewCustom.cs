using Android.Views;
using Android.Webkit;
using CityInformationsApp.Utils.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IWebViewCustom), typeof(CityInformationsApp.Droid.CustomRenderer.WebViewCustom))]

namespace CityInformationsApp.Droid.CustomRenderer
{
#pragma warning disable CS0618
    public class WebViewCustom : WebViewRenderer
    {
        private MapJavascriptRun mapJavascriptRun = null;
        private IWebViewCustom mapWebView = null;

        public override bool OnTouchEvent(MotionEvent e)
        {
            RequestDisallowInterceptTouchEvent(true);
            return false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            mapWebView = e.NewElement as IWebViewCustom;
            mapJavascriptRun = new MapJavascriptRun(mapWebView);

            Control.SetWebChromeClient(new MyWebClient());
            Control.Settings.JavaScriptEnabled = true;
            Control.Settings.UseWideViewPort = true;
            Control.Settings.DomStorageEnabled = true;
            Control.Settings.LoadWithOverviewMode = true;
            Control.Settings.SaveFormData = true;
            Control.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
            Control.SetLayerType(LayerType.Hardware, null);
            Control.AddJavascriptInterface(mapJavascriptRun, "CSharp");
            Control.Touch += WebView_Touch;
            SetNativeControl(Control);
        }

        private void WebView_Touch(object sender, TouchEventArgs e)
        {
            e.Handled = false;
            base.OnTouchEvent(e.Event);
            OnTouchEvent(e.Event);
        }

        public class MyWebClient : WebChromeClient
        {

        }
    }
}