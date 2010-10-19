// Type: System.Windows.Forms.Application
// Assembly: System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\System.Windows.Forms.dll

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms
{
    /// <summary>
    /// Provides static methods and properties to manage an application, such as methods to start and stop an application, to process Windows messages, and properties to get information about an application. This class cannot be inherited.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    public sealed class Application
    {
        #region Delegates

        /// <summary>
        /// Represents a method that will check whether the hosting environment is still sending messages.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public delegate bool MessageLoopCallback();

        #endregion

        static Application();
        private Application();

        /// <summary>
        /// Gets a value indicating whether the caller can quit this application.
        /// </summary>
        /// 
        /// <returns>
        /// true if the caller can quit this application; otherwise, false.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public static bool AllowQuit { get; }

        /// <summary>
        /// Gets the registry key for the application data that is shared among all users.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:Microsoft.Win32.RegistryKey"/> representing the registry key of the application data that is shared among all users.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static RegistryKey CommonAppDataRegistry { get; }

        /// <summary>
        /// Gets the path for the application data that is shared among all users.
        /// </summary>
        /// 
        /// <returns>
        /// The path for the application data that is shared among all users.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static string CommonAppDataPath { get; }

        /// <summary>
        /// Gets the company name associated with the application.
        /// </summary>
        /// 
        /// <returns>
        /// The company name.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static string CompanyName { get; }

        /// <summary>
        /// Gets or sets the culture information for the current thread.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Globalization.CultureInfo"/> representing the culture information for the current thread.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlThread"/></PermissionSet>
        public static CultureInfo CurrentCulture { get; set; }

        /// <summary>
        /// Gets or sets the current input language for the current thread.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Windows.Forms.InputLanguage"/> representing the current input language for the current thread.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public static InputLanguage CurrentInputLanguage { get; set; }

        /// <summary>
        /// Gets the path for the executable file that started the application, including the executable name.
        /// </summary>
        /// 
        /// <returns>
        /// The path and executable name for the executable file that started the application.This path will be different depending on whether the Windows Forms application is deployed using ClickOnce. ClickOnce applications are stored in a per-user application cache in the C:\Documents and Settings\username directory. For more information, see Accessing Local and Remote Data in ClickOnce Applications.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static string ExecutablePath { get; }

        /// <summary>
        /// Gets the path for the application data of a local, non-roaming user.
        /// </summary>
        /// 
        /// <returns>
        /// The path for the application data of a local, non-roaming user.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static string LocalUserAppDataPath { get; }

        /// <summary>
        /// Gets a value indicating whether a message loop exists on this thread.
        /// </summary>
        /// 
        /// <returns>
        /// true if a message loop exists; otherwise, false.
        /// </returns>
        /// <filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static bool MessageLoop { get; }

        /// <summary>
        /// Gets a collection of open forms owned by the application.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.Forms.FormCollection"/> containing all the currently open forms owned by this application.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Window="AllWindows"/></PermissionSet>
        public static FormCollection OpenForms { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; }

        /// <summary>
        /// Gets the product name associated with this application.
        /// </summary>
        /// 
        /// <returns>
        /// The product name.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static string ProductName { get; }

        /// <summary>
        /// Gets the product version associated with this application.
        /// </summary>
        /// 
        /// <returns>
        /// The product version.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static string ProductVersion { get; }

        /// <summary>
        /// Gets a value specifying whether the current application is drawing controls with visual styles.
        /// </summary>
        /// 
        /// <returns>
        /// true if visual styles are enabled for controls in the client area of application windows; otherwise, false.
        /// </returns>
        public static bool RenderWithVisualStyles { get; }

        /// <summary>
        /// Gets or sets the format string to apply to top-level window captions when they are displayed with a warning banner.
        /// </summary>
        /// 
        /// <returns>
        /// The format string to apply to top-level window captions.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public static string SafeTopLevelCaptionFormat { get; set; }

        /// <summary>
        /// Gets the path for the executable file that started the application, not including the executable name.
        /// </summary>
        /// 
        /// <returns>
        /// The path for the executable file that started the application.This path will be different depending on whether the Windows Forms application is deployed using ClickOnce. ClickOnce applications are stored in a per-user application cache in the C:\Documents and Settings\username directory. For more information, see Accessing Local and Remote Data in ClickOnce Applications.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static string StartupPath { get; }

        /// <summary>
        /// Gets or sets whether the wait cursor is used for all open forms of the application.
        /// </summary>
        /// 
        /// <returns>
        /// true is the wait cursor is used for all open forms; otherwise, false.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public static bool UseWaitCursor { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        /// <summary>
        /// Gets the path for the application data of a user.
        /// </summary>
        /// 
        /// <returns>
        /// The path for the application data of a user.
        /// </returns>
        /// <filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static string UserAppDataPath { get; }

        /// <summary>
        /// Gets the registry key for the application data of a user.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:Microsoft.Win32.RegistryKey"/> representing the registry key for the application data specific to the user.
        /// </returns>
        /// <filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static RegistryKey UserAppDataRegistry { get; }

        /// <summary>
        /// Gets a value that specifies how visual styles are applied to application windows.
        /// </summary>
        /// 
        /// <returns>
        /// A bitwise combination of the <see cref="T:System.Windows.Forms.VisualStyles.VisualStyleState"/> values.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public static VisualStyleState VisualStyleState { get; set; }

        /// <summary>
        /// Registers a callback for checking whether the message loop is running in hosted environments.
        /// </summary>
        /// <param name="callback">The method to call when Windows Forms needs to check if the hosting environment is still sending messages.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void RegisterMessageLoop(Application.MessageLoopCallback callback);

        /// <summary>
        /// Unregisters the message loop callback made with <see cref="M:System.Windows.Forms.Application.RegisterMessageLoop(System.Windows.Forms.Application.MessageLoopCallback)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void UnregisterMessageLoop();

        /// <summary>
        /// Adds a message filter to monitor Windows messages as they are routed to their destinations.
        /// </summary>
        /// <param name="value">The implementation of the <see cref="T:System.Windows.Forms.IMessageFilter"/> interface you want to install. </param><filterpriority>1</filterpriority>
        public static void AddMessageFilter(IMessageFilter value);

        /// <summary>
        /// Runs any filters against a window message, and returns a copy of the modified message.
        /// </summary>
        /// 
        /// <returns>
        /// True if the filters were processed; otherwise, false.
        /// </returns>
        /// <param name="message">The Windows event message to filter. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static bool FilterMessage(ref Message message);

        /// <summary>
        /// Processes all Windows messages currently in the message queue.
        /// </summary>
        /// <filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static void DoEvents();

        /// <summary>
        /// Enables visual styles for the application.
        /// </summary>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static void EnableVisualStyles();

        /// <summary>
        /// Informs all message pumps that they must terminate, and then closes all application windows after the messages have been processed.
        /// </summary>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void Exit();

        /// <summary>
        /// Informs all message pumps that they must terminate, and then closes all application windows after the messages have been processed.
        /// </summary>
        /// <param name="e">Returns whether any <see cref="T:System.Windows.Forms.Form"/> within the application cancelled the exit.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void Exit(CancelEventArgs e);

        /// <summary>
        /// Exits the message loop on the current thread and closes all windows on the thread.
        /// </summary>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static void ExitThread();

        /// <summary>
        /// Initializes OLE on the current thread.
        /// </summary>
        /// 
        /// <returns>
        /// One of the <see cref="T:System.Threading.ApartmentState"/> values.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public static ApartmentState OleRequired();

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Application.ThreadException"/> event.
        /// </summary>
        /// <param name="t">An <see cref="T:System.Exception"/> that represents the exception that was thrown. </param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static void OnThreadException(Exception t);

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Application.Idle"/> event in hosted scenarios.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> objects to pass to the <see cref="E:System.Windows.Forms.Application.Idle"/> event.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void RaiseIdle(EventArgs e);

        /// <summary>
        /// Removes a message filter from the message pump of the application.
        /// </summary>
        /// <param name="value">The implementation of the <see cref="T:System.Windows.Forms.IMessageFilter"/> to remove from the application. </param><filterpriority>1</filterpriority>
        public static void RemoveMessageFilter(IMessageFilter value);

        /// <summary>
        /// Shuts down the application and starts a new instance immediately.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">Your code is not a Windows Forms application. You cannot call this method in this context.</exception>
        public static void Restart();

        /// <summary>
        /// Begins running a standard application message loop on the current thread, without a form.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">A main message loop is already running on this thread. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static void Run();

        /// <summary>
        /// Begins running a standard application message loop on the current thread, and makes the specified form visible.
        /// </summary>
        /// <param name="mainForm">A <see cref="T:System.Windows.Forms.Form"/> that represents the form to make visible. </param><exception cref="T:System.InvalidOperationException">A main message loop is already running on the current thread. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static void Run(Form mainForm);

        /// <summary>
        /// Begins running a standard application message loop on the current thread, with an <see cref="T:System.Windows.Forms.ApplicationContext"/>.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Windows.Forms.ApplicationContext"/> in which the application is run. </param><exception cref="T:System.InvalidOperationException">A main message loop is already running on this thread. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static void Run(ApplicationContext context);

        /// <summary>
        /// Sets the application-wide default for the UseCompatibleTextRendering property defined on certain controls.
        /// </summary>
        /// <param name="defaultValue">The default value to use for new controls. If true, new controls that support UseCompatibleTextRendering use the GDI+ based <see cref="T:System.Drawing.Graphics"/> class for text rendering; if false, new controls use the GDI based <see cref="T:System.Windows.Forms.TextRenderer"/> class.</param><exception cref="T:System.InvalidOperationException">You can only call this method before the first window is created by your Windows Forms application. </exception>
        public static void SetCompatibleTextRenderingDefault(bool defaultValue);

        /// <summary>
        /// Suspends or hibernates the system, or requests that the system be suspended or hibernated.
        /// </summary>
        /// 
        /// <returns>
        /// true if the system is being suspended, otherwise, false.
        /// </returns>
        /// <param name="state">A <see cref="T:System.Windows.Forms.PowerState"/> indicating the power activity mode to which to transition. </param><param name="force">true to force the suspended mode immediately; false to cause Windows to send a suspend request to every application. </param><param name="disableWakeEvent">true to disable restoring the system's power status to active on a wake event, false to enable restoring the system's power status to active on a wake event. </param><filterpriority>1</filterpriority>
        public static bool SetSuspendState(PowerState state, bool force, bool disableWakeEvent);

        /// <summary>
        /// Instructs the application how to respond to unhandled exceptions.
        /// </summary>
        /// <param name="mode">An <see cref="T:System.Windows.Forms.UnhandledExceptionMode"/> value describing how the application should behave if an exception is thrown without being caught.</param><exception cref="T:System.InvalidOperationException">You cannot set the exception mode after the application has created its first window.</exception>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void SetUnhandledExceptionMode(UnhandledExceptionMode mode);

        /// <summary>
        /// Instructs the application how to respond to unhandled exceptions, optionally applying thread-specific behavior.
        /// </summary>
        /// <param name="mode">An <see cref="T:System.Windows.Forms.UnhandledExceptionMode"/> value describing how the application should behave if an exception is thrown without being caught.</param><param name="threadScope">true to set the thread exception mode; otherwise, false.</param><exception cref="T:System.InvalidOperationException">You cannot set the exception mode after the application has created its first window.</exception>
        public static void SetUnhandledExceptionMode(UnhandledExceptionMode mode, bool threadScope);

        /// <summary>
        /// Occurs when the application is about to shut down.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public static event EventHandler ApplicationExit;

        /// <summary>
        /// Occurs when the application finishes processing and is about to enter the idle state.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public static event EventHandler Idle;

        /// <summary>
        /// Occurs when the application is about to enter a modal state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static event EventHandler EnterThreadModal;

        /// <summary>
        /// Occurs when the application is about to leave a modal state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static event EventHandler LeaveThreadModal;

        /// <summary>
        /// Occurs when an untrapped thread exception is thrown.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public static event ThreadExceptionEventHandler ThreadException;

        /// <summary>
        /// Occurs when a thread is about to shut down. When the main thread for an application is about to be shut down, this event is raised first, followed by an <see cref="E:System.Windows.Forms.Application.ApplicationExit"/> event.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public static event EventHandler ThreadExit;
    }
}
