﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Library {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Common_Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Common_Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Common.Library.Common.Resources", typeof(Common_Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The argument has an error.
        /// </summary>
        internal static string ArgumentException {
            get {
                return ResourceManager.GetString("ArgumentException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The argument is null.
        /// </summary>
        internal static string ArgumentNull {
            get {
                return ResourceManager.GetString("ArgumentNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Directory not found.
        /// </summary>
        internal static string DirectoryNotFound {
            get {
                return ResourceManager.GetString("DirectoryNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ||.
        /// </summary>
        internal static string ErrorLogSeparation {
            get {
                return ResourceManager.GetString("ErrorLogSeparation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The IO has an error.
        /// </summary>
        internal static string IOException {
            get {
                return ResourceManager.GetString("IOException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The tarjet has an error.
        /// </summary>
        internal static string TargetException {
            get {
                return ResourceManager.GetString("TargetException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The tarjet invocation has an error.
        /// </summary>
        internal static string TargetInvocationException {
            get {
                return ResourceManager.GetString("TargetInvocationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not have privilegies.
        /// </summary>
        internal static string Unauthorized {
            get {
                return ResourceManager.GetString("Unauthorized", resourceCulture);
            }
        }
    }
}