using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ZalandoShopSearch.Services;
using ZalandoShopSearch.Views;

namespace ZalandoShopSearch
{
  /// <summary>
  /// Stellt das anwendungsspezifische Verhalten bereit, um die Standardanwendungsklasse zu ergänzen.
  /// </summary>
  sealed partial class App : Application
  {
    /// <summary>
    /// Initialisiert das Singletonanwendungsobjekt. Dies ist die erste Zeile von erstelltem Code
    /// und daher das logische Äquivalent von main() bzw. WinMain().
    /// </summary>
    public App()
    {
      this.InitializeComponent();
      this.Suspending += OnSuspending;
    }

    /// <summary>
    /// Wird aufgerufen, wenn die Anwendung durch den Endbenutzer normal gestartet wird. Weitere Einstiegspunkte
    /// werden z. B. verwendet, wenn die Anwendung gestartet wird, um eine bestimmte Datei zu öffnen.
    /// </summary>
    /// <param name="e">Details über Startanforderung und -prozess.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
      Frame rootFrame = Window.Current.Content as Frame;

      // App-Initialisierung nicht wiederholen, wenn das Fenster bereits Inhalte enthält.
      // Nur sicherstellen, dass das Fenster aktiv ist.
      if (rootFrame == null)
      {
        // Frame erstellen, der als Navigationskontext fungiert und zum Parameter der ersten Seite navigieren
        rootFrame = new Frame();

        rootFrame.NavigationFailed += OnNavigationFailed;

        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
          //TODO: Zustand von zuvor angehaltener Anwendung laden
        }

        // Den Frame im aktuellen Fenster platzieren
        Window.Current.Content = rootFrame;
      }

      if (e.PrelaunchActivated == false)
      {
        if (rootFrame.Content == null)
        {
          // Wenn der Navigationsstapel nicht wiederhergestellt wird, zur ersten Seite navigieren
          // und die neue Seite konfigurieren, indem die erforderlichen Informationen als Navigationsparameter
          // übergeben werden
          rootFrame.Navigate(typeof(MainPage), new ApiClient());  // e.Arguments
        }

        // Register a global back event handler. This can be registered on a per-page-bases if you only have a subset of your pages
        // that needs to handle back or if you want to do page-specific logic before deciding to navigate back on those pages.
        SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;

        // Sicherstellen, dass das aktuelle Fenster aktiv ist
        Window.Current.Activate();
      }
    }

    /// <summary>
    /// Invoked when a user issues a global back on the device.
    /// If the app has no in-app back stack left for the current view/frame the user may be navigated away
    /// back to the previous app in the system's app back stack or to the start screen.
    /// In windowed mode on desktop there is no system app back stack and the user will stay in the app even when the in-app back stack is depleted.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void App_BackRequested(object sender, BackRequestedEventArgs e)
    {
      Frame rootFrame = Window.Current.Content as Frame;
      if (rootFrame == null)
        return;

      // If we can go back and the event has not already been handled, do so.
      if (rootFrame.CanGoBack && e.Handled == false)
      {
        e.Handled = true;
        rootFrame.GoBack();
      }
    }

    /// <summary>
    /// Wird aufgerufen, wenn die Navigation auf eine bestimmte Seite fehlschlägt
    /// </summary>
    /// <param name="sender">Der Rahmen, bei dem die Navigation fehlgeschlagen ist</param>
    /// <param name="e">Details über den Navigationsfehler</param>
    void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
      throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }

    /// <summary>
    /// Wird aufgerufen, wenn die Ausführung der Anwendung angehalten wird.  Der Anwendungszustand wird gespeichert,
    /// ohne zu wissen, ob die Anwendung beendet oder fortgesetzt wird und die Speicherinhalte dabei
    /// unbeschädigt bleiben.
    /// </summary>
    /// <param name="sender">Die Quelle der Anhalteanforderung.</param>
    /// <param name="e">Details zur Anhalteanforderung.</param>
    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
      var deferral = e.SuspendingOperation.GetDeferral();
      //TODO: Anwendungszustand speichern und alle Hintergrundaktivitäten beenden
      deferral.Complete();
    }
  }
}
